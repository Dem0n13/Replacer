using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace LocalizationLibrary.Hyper
{
    /// <summary>
    /// The class help to get perfomance PropertyDescriptor from your class type. 
    /// Original code: Marc Gravell
    /// Change history:
    /// 20 Apr 2007 Marc Gravell        Renamed
    /// 21 Aug 2012 Dmitry Statsenko    Reorganized, kept property-part code only, add overload method
    /// </summary>
    public class PropertyDescriptorBuilder
    {
        private static readonly Dictionary<PropertyInfo, PropertyDescriptor> CachedProperties =
            new Dictionary<PropertyInfo, PropertyDescriptor>();

        private static readonly ModuleBuilder ModuleBuilder;
        private static int _counter;

        static PropertyDescriptorBuilder()
        {
            var assemblyName = new AssemblyName("Hyper.ComponentModel.dynamic");
            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder = assemblyBuilder.DefineDynamicModule("Hyper.ComponentModel.dynamic.dll");
        }

        public static PropertyDescriptor TryCreatePropertyDescriptor(Type objType, string propertyName)
        {
            var descriptorCollection = TypeDescriptor.GetProperties(objType); //TODO очень медленно
            var descriptor = descriptorCollection.Find(propertyName, false);
            TryCreatePropertyDescriptor(ref descriptor);
            return descriptor;
        }

        public static bool TryCreatePropertyDescriptor(ref PropertyDescriptor descriptor)
        {
            try
            {
                PropertyInfo property = descriptor.ComponentType.GetProperty(descriptor.Name);
                if (property == null || property.DeclaringType == null) return false;
                lock (CachedProperties)
                {
                    PropertyDescriptor foundBuiltAlready;
                    if (CachedProperties.TryGetValue(property, out foundBuiltAlready))
                    {
                        descriptor = foundBuiltAlready;
                        return true;
                    }

                    string name = "_c" + Interlocked.Increment(ref _counter);
                    TypeBuilder tb = ModuleBuilder.DefineType(name,
                                                              TypeAttributes.Sealed | TypeAttributes.NotPublic |
                                                              TypeAttributes.Class | TypeAttributes.BeforeFieldInit |
                                                              TypeAttributes.AutoClass | TypeAttributes.Public,
                                                              typeof (ChainingPropertyDescriptor));

                    // ctor calls base
                    ConstructorBuilder cb =
                        tb.DefineConstructor(
                            MethodAttributes.HideBySig | MethodAttributes.Public | MethodAttributes.SpecialName |
                            MethodAttributes.RTSpecialName, CallingConventions.Standard,
                            new[] {typeof (PropertyDescriptor)});
                    ILGenerator il = cb.GetILGenerator();
                    il.Emit(OpCodes.Ldarg_0);
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Call,
                            typeof (ChainingPropertyDescriptor).GetConstructor(
                                BindingFlags.NonPublic | BindingFlags.Instance, null,
                                new[] {typeof (PropertyDescriptor)}, null));
                    il.Emit(OpCodes.Ret);

                    MethodBuilder mb;
                    MethodInfo baseMethod;
                    if (property.CanRead)
                    {
                        // obtain the implementation that we want to override
                        baseMethod = typeof (ChainingPropertyDescriptor).GetMethod("GetValue");
                        // create a new method that accepts an object and returns an object (as per the base)
                        mb = tb.DefineMethod(baseMethod.Name,
                                             MethodAttributes.HideBySig | MethodAttributes.Public |
                                             MethodAttributes.Virtual | MethodAttributes.Final,
                                             baseMethod.CallingConvention, baseMethod.ReturnType,
                                             new[] {typeof (object)});
                        // start writing IL into the method
                        il = mb.GetILGenerator();
                        if (property.DeclaringType.IsValueType)
                        {
                            // upbox the object argument into our known (instance) struct type
                            LocalBuilder lb = il.DeclareLocal(property.DeclaringType);
                            il.Emit(OpCodes.Ldarg_1);
                            il.Emit(OpCodes.Unbox_Any, property.DeclaringType);
                            il.Emit(OpCodes.Stloc_0);
                            il.Emit(OpCodes.Ldloca_S, lb);
                        }
                        else
                        {
                            // cast the object argument into our known class type
                            il.Emit(OpCodes.Ldarg_1);
                            il.Emit(OpCodes.Castclass, property.DeclaringType);
                        }
                        // call the "get" method
                        il.Emit(OpCodes.Callvirt, property.GetGetMethod());

                        if (property.PropertyType.IsValueType)
                        {
                            // box it from the known (value) struct type
                            il.Emit(OpCodes.Box, property.PropertyType);
                        }
                        // return the value
                        il.Emit(OpCodes.Ret);
                        // signal that this method should override the base
                        tb.DefineMethodOverride(mb, baseMethod);
                    }

                    bool supportsChangeEvents = descriptor.SupportsChangeEvents, isReadOnly = descriptor.IsReadOnly;

                    // override SupportsChangeEvents
                    baseMethod = typeof (ChainingPropertyDescriptor).GetProperty("SupportsChangeEvents").GetGetMethod();
                    mb = tb.DefineMethod(baseMethod.Name,
                                         MethodAttributes.HideBySig | MethodAttributes.Public | MethodAttributes.Virtual |
                                         MethodAttributes.Final | MethodAttributes.SpecialName,
                                         baseMethod.CallingConvention, baseMethod.ReturnType, Type.EmptyTypes);
                    il = mb.GetILGenerator();
                    il.Emit(supportsChangeEvents ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0);
                    il.Emit(OpCodes.Ret);
                    tb.DefineMethodOverride(mb, baseMethod);

                    // override IsReadOnly
                    baseMethod = typeof (ChainingPropertyDescriptor).GetProperty("IsReadOnly").GetGetMethod();
                    mb = tb.DefineMethod(baseMethod.Name,
                                         MethodAttributes.HideBySig | MethodAttributes.Public | MethodAttributes.Virtual |
                                         MethodAttributes.Final | MethodAttributes.SpecialName,
                                         baseMethod.CallingConvention, baseMethod.ReturnType, Type.EmptyTypes);
                    il = mb.GetILGenerator();

                    il.Emit(isReadOnly ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0);

                    il.Emit(OpCodes.Ret);
                    tb.DefineMethodOverride(mb, baseMethod);

                    // for classes, implement write (would be lost in unbox for structs)
                    if (!property.DeclaringType.IsValueType)
                    {
                        if (!isReadOnly && property.CanWrite)
                        {
                            // override set method
                            baseMethod = typeof (ChainingPropertyDescriptor).GetMethod("SetValue");
                            mb = tb.DefineMethod(baseMethod.Name,
                                                 MethodAttributes.HideBySig | MethodAttributes.Public |
                                                 MethodAttributes.Virtual | MethodAttributes.Final,
                                                 baseMethod.CallingConvention, baseMethod.ReturnType,
                                                 new[] {typeof (object), typeof (object)});
                            il = mb.GetILGenerator();
                            il.Emit(OpCodes.Ldarg_1);
                            il.Emit(OpCodes.Castclass, property.DeclaringType);
                            il.Emit(OpCodes.Ldarg_2);
                            il.Emit(property.PropertyType.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass,
                                    property.PropertyType);
                            il.Emit(OpCodes.Callvirt, property.GetSetMethod());
                            il.Emit(OpCodes.Ret);
                            tb.DefineMethodOverride(mb, baseMethod);
                        }

                        if (supportsChangeEvents)
                        {
                            EventInfo ei = property.DeclaringType.GetEvent(property.Name + "Changed");
                            if (ei != null)
                            {
                                baseMethod = typeof (ChainingPropertyDescriptor).GetMethod("AddValueChanged");
                                mb = tb.DefineMethod(baseMethod.Name,
                                                     MethodAttributes.HideBySig | MethodAttributes.Public |
                                                     MethodAttributes.Virtual | MethodAttributes.Final |
                                                     MethodAttributes.SpecialName, baseMethod.CallingConvention,
                                                     baseMethod.ReturnType,
                                                     new[] {typeof (object), typeof (EventHandler)});
                                il = mb.GetILGenerator();
                                il.Emit(OpCodes.Ldarg_1);
                                il.Emit(OpCodes.Castclass, property.DeclaringType);
                                il.Emit(OpCodes.Ldarg_2);
                                il.Emit(OpCodes.Callvirt, ei.GetAddMethod());
                                il.Emit(OpCodes.Ret);
                                tb.DefineMethodOverride(mb, baseMethod);

                                baseMethod = typeof (ChainingPropertyDescriptor).GetMethod("RemoveValueChanged");
                                mb = tb.DefineMethod(baseMethod.Name,
                                                     MethodAttributes.HideBySig | MethodAttributes.Public |
                                                     MethodAttributes.Virtual | MethodAttributes.Final |
                                                     MethodAttributes.SpecialName, baseMethod.CallingConvention,
                                                     baseMethod.ReturnType,
                                                     new[] {typeof (object), typeof (EventHandler)});
                                il = mb.GetILGenerator();
                                il.Emit(OpCodes.Ldarg_1);
                                il.Emit(OpCodes.Castclass, property.DeclaringType);
                                il.Emit(OpCodes.Ldarg_2);
                                il.Emit(OpCodes.Callvirt, ei.GetRemoveMethod());
                                il.Emit(OpCodes.Ret);
                                tb.DefineMethodOverride(mb, baseMethod);
                            }
                        }
                    }

                    PropertyDescriptor newDesc =
                        tb.CreateType().GetConstructor(new[] {typeof (PropertyDescriptor)})
                            .Invoke(new object[] {descriptor}) as PropertyDescriptor;
                    if (newDesc == null) return false;

                    descriptor = newDesc;
                    CachedProperties.Add(property, descriptor);
                    return true;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return false;
            }
        }
    }
}