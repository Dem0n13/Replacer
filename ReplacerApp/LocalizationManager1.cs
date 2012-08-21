using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;

namespace Dem0n13.Replacer.App
{
    internal class LocalizationManager1
    {
        private readonly Dictionary<Control, string> _resourceMap = new Dictionary<Control, string>();
        private readonly ComponentResourceManager _componentResourceManager; 

        public LocalizationManager1(Form form)
        {
            _componentResourceManager = new ComponentResourceManager(typeof (MainForm));
            GetAllControls(form);
        }

        public void SetLocale(string locale)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(locale);
            foreach (var control in _resourceMap.Keys)
            {
                UpdateControl(control);
            }
        }

        public void SetDefaultResource(Control control)
        {
            SetResource(control, control.Name);
        }

        public void SetResource(Control control, string resourceKey)
        {
            if (_resourceMap.ContainsKey(control))
            {
                _resourceMap[control] = resourceKey;
                UpdateControl(control);
            }
        }

        public bool IsDefaultResource(Control control)
        {
            return _resourceMap.ContainsKey(control) && string.Equals(control.Name, _resourceMap[control]);
        }

        public string GetResource(Control control)
        {
            return _resourceMap.ContainsKey(control) ? _resourceMap[control] : null;
        }

        public string GetResourceString(string key)
        {
            return _componentResourceManager.GetString(key);
        }

        private void GetAllControls(Control owner)
        {
            foreach (var childObj in owner.Controls)
            {
                var control = childObj as Control;
                if (control == null) continue;

                _resourceMap.Add(control, control.Name);
                if (control.HasChildren)
                    GetAllControls(control);
            }
        }

        private void UpdateControl(Control control)
        {
            _componentResourceManager.ApplyResources(control, _resourceMap[control]);
            _componentResourceManager.GetString(_resourceMap[control]);
        }
    }
}
