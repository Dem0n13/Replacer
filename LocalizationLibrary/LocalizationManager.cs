using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using LocalizationLibrary.Hyper;

namespace Dem0n13.LocalizationLibrary
{
    public class LocalizationManager
    {
        private bool CultureValid
        {
            get { return Thread.CurrentThread.CurrentUICulture.Name == _cultureName; }
        }

        private readonly Dictionary<object, Dictionary<PropertyDescriptor, string>> _targetsMap =
            new Dictionary<object, Dictionary<PropertyDescriptor, string>>();

        private readonly Dictionary<string, string> _defaultStrings = new Dictionary<string, string>();
        private Dictionary<string, string> _languageStrings = new Dictionary<string, string>();
        private Dictionary<string, string> _cultureStrings = new Dictionary<string, string>();

        private readonly string _resourcePath;

        private string _languageName;
        private string _cultureName;

        public LocalizationManager(string resourceName, string baseDir = "")
        {
            _resourcePath = Path.Combine(baseDir, resourceName);

            if (!File.Exists(_resourcePath + ".lang"))
            {
                Stream stream = null;
                var st = new StackTrace();
                var mb = st.GetFrame(1).GetMethod();
                if (mb.DeclaringType != null)
                {
                    var namesp = mb.DeclaringType.Namespace;
                    var ass = mb.DeclaringType.Assembly;
                    stream = ass.GetManifestResourceStream(namesp + "." + resourceName + ".lang");
                }

                if (stream == null) throw new IOException();
                _defaultStrings = ParseLangStream(stream);
                stream.Dispose();
            }
            else
            {
                _defaultStrings = ParseLangFile(_resourcePath + ".lang");
            }

            LoadLangPack();
        }

        #region private loading, parsing

        private void LoadLangPack()
        {
            var match = Regex.Match(Thread.CurrentThread.CurrentUICulture.Name, "(\\w+)-?(\\w+)?");
            _languageName = match.Groups.Count == 3 ? match.Groups[1].Value : null;
            _cultureName = Thread.CurrentThread.CurrentUICulture.Name;

            if (_languageName != null)
            {
                var filePath = _resourcePath + "." + _languageName + ".lang";
                _languageStrings = ParseLangFile(filePath);
            }

            if (_cultureName != null)
            {
                var filePath = _resourcePath + "." + _cultureName + ".lang";
                _cultureStrings = ParseLangFile(filePath);
            }
        }


        private static bool TryParseLine(string line, out KeyValuePair<string, string> parsed)
        {
            var split = line.Split(new[] {'=', '"'}, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length == 2)
            {
                parsed = new KeyValuePair<string, string>(split[0], split[1].Replace("\\n", Environment.NewLine));
                return true;
            }
            parsed = new KeyValuePair<string, string>();
            return false;
        }

        private static Dictionary<string, string> ParseLangStream(Stream stream)
        {
            var result = new Dictionary<string, string>();

            using (var streamReader = new StreamReader(stream))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    KeyValuePair<string, string> resultNode;
                    if (TryParseLine(line, out resultNode) && !result.ContainsKey(resultNode.Key))
                        result.Add(resultNode.Key, resultNode.Value);
                }
            }

            return result;
        }

        private static Dictionary<string, string> ParseLangFile(string filePath)
        {
            var result = new Dictionary<string, string>();

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    KeyValuePair<string, string> resultNode;
                    if (TryParseLine(line, out resultNode) && !result.ContainsKey(resultNode.Key))
                        result.Add(resultNode.Key, resultNode.Value);
                }
            }

            return result;
        }

        #endregion

        private void Update(object target)
        {
            foreach (var targetPropertyNode in _targetsMap[target])
            {
                var newValue = GetString(targetPropertyNode.Value);
                if (newValue != null)
                    targetPropertyNode.Key.SetValue(target, newValue);
            }
        }

        public void UpdateAll()
        {
            if (!CultureValid) LoadLangPack();
            
            foreach (var target in _targetsMap.Keys)
                Update(target);
        }

        /// <summary>
        /// Применяет ресурс (переведенную строку) к объекту с заданным свойсвом.
        /// Ресурс определяется по ключу
        /// </summary>
        /// <param name="target">Объект, к которому применяется перевод</param>
        /// <param name="propertyName">Свойство объекта</param>
        /// <param name="resourceKey">Ключ, определяющий ресурс</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="resourceKey" /> must not be null.
        /// </exception>
        /// <exception cref="Exception">
        ///     <p>Property <paramref name="propertyName"/> is not found.</p>
        ///     <p>- or - </p>
        ///     <p>Property <paramref name="propertyName"/> is not string type.</p>
        /// </exception>
        public void ApplyResource(object target, string propertyName, string resourceKey)
        {
            if (!CultureValid) LoadLangPack();

            var property = PropertyDescriptorBuilder.TryCreatePropertyDescriptor(target.GetType(), propertyName);
            if (property == null)
                throw new Exception(string.Format("Property '{0}' is not found", propertyName));
            if (property.PropertyType != typeof (string))
                throw new Exception(string.Format("Property '{0}' is not string type", propertyName));
            if (resourceKey == null)
                throw new ArgumentNullException("resourceKey");

            if (!_targetsMap.ContainsKey(target)) _targetsMap.Add(target, new Dictionary<PropertyDescriptor, string>());
            if (!_targetsMap[target].ContainsKey(property)) _targetsMap[target].Add(property, resourceKey);
            else _targetsMap[target][property] = resourceKey;

            Update(target);
        }

        public void CleanResource(object target, string propertyName)
        {
            var property = PropertyDescriptorBuilder.TryCreatePropertyDescriptor(target.GetType(), propertyName);
            if (property == null)
                throw new Exception(string.Format("Property '{0}' is not found", propertyName));

            if (_targetsMap.ContainsKey(target) && _targetsMap[target].ContainsKey(property))
                _targetsMap[target].Remove(property);
        }

        public bool HasResource(object target, string propertyName)
        {
            var property = PropertyDescriptorBuilder.TryCreatePropertyDescriptor(target.GetType(), propertyName);
            if (property == null)
                throw new Exception(string.Format("Property '{0}' is not found", propertyName));

            return _targetsMap.ContainsKey(target) && _targetsMap[target].ContainsKey(property);
        }

        public string GetString(string key)
        {
            if (!CultureValid) LoadLangPack();

            if (_cultureStrings.ContainsKey(key))
                return _cultureStrings[key];
            if (_languageStrings.ContainsKey(key))
                return _languageStrings[key];
            if (_defaultStrings.ContainsKey(key))
                return _defaultStrings[key];
            Debug.WriteLine("GetString [{0}] returns null", (object)key);
            return null;
        }
    }
}
