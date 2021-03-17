using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace MultiLanguageDemo {
    public class LocalizationExtension : Binding {
        private string _name;

        public string Name {
            get => _name;
            set {
                _name = value;
                Path = new PropertyPath($"{nameof(Strings)}.{_name}");
            }
        }

        private bool _raiseCultureChanged = false;
        public bool RaiseCultureChanged {
            get => _raiseCultureChanged;
            set {
                _raiseCultureChanged = value;
                Path = _raiseCultureChanged ? new PropertyPath(nameof(LanguageProvider.Current.Language)) : null;
            }
        }

        // from xaml element
        public LocalizationExtension() => Initialize();

        // from markup
        public LocalizationExtension(string name) {
            Initialize();

            Name = name;
        }

        private void Initialize() {
            Source = LanguageProvider.Current;
            Mode = BindingMode.OneWay;
            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        }
    }
}
