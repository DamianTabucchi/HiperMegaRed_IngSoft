using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HiperMegaRed.Services
{
    public class Language
    {
        private static Language _instance = new Language();
        private Dictionary<string, Dictionary<string, string>> _translations;
        private string _currentLanguage = "Spanish";
        private List<ILanguageObserver> _observers = new List<ILanguageObserver>();

        private Language()
        {
            LoadTranslationsFromFile(); // Load translations from a JSON file.
        }
        public static Language Instance => _instance;
        

        public void RegisterObserver(ILanguageObserver observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
        }

        public void RemoveObserver(ILanguageObserver observer)
        {
            _observers.Remove(observer);
        }

        public void ChangeLanguage(string language)
        {
            if (_translations.ContainsKey(language))
            {
                _currentLanguage = language;
                NotifyObservers();
            }
        }

        public string Translate(string key)
        {
            if (_translations.ContainsKey(_currentLanguage) && _translations[_currentLanguage].ContainsKey(key))
                return _translations[_currentLanguage][key];
            return key; // Return the key if no translation found.
        }

        private void NotifyObservers()
        {
            foreach (var observer in _observers)
                observer.UpdateLanguage();
        }

        private void LoadTranslationsFromFile()
        {
            var jsonString = File.ReadAllText("C:/Users/SF_Bl/source/repos/HiperMegaRed_IngSoft/idiomas.json");
            _translations = JsonConvert.DeserializeObject(jsonString, typeof(Dictionary<string, Dictionary<string, string>>)) as Dictionary<string, Dictionary<string, string>>;

            //_translations = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(jsonString);
            // Load translations from JSON into _translations dictionary.
        }
    }
}
