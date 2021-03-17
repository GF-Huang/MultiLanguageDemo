using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Threading;

namespace MultiLanguageDemo {
    public class LanguageProvider : INotifyPropertyChanged {
        public static LanguageProvider Current { get; } = new LanguageProvider();

        public Strings Strings { get; } = new Strings(); // This is the key for design time display localization.

        private string _language = CultureInfo.CurrentUICulture.Name;
        public string Language {
            get { return _language; }
            set {
                if (_language == value)
                    return;

                _language = value;

                ChangeCulture(CultureInfo.GetCultureInfo(value));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ChangeCulture(CultureInfo cultureInfo) {
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Strings.Culture = cultureInfo;

            RaisePropertyChanged();
        }

        private void RaisePropertyChanged() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
    }
}
