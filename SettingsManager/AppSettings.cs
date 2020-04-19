using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SettingsManager
{
    public class AppSettings
    {
        private static string _settingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json");
        public static AppSettings Instance
        {
            get
            {
                AppSettings instance;
                if (File.Exists(_settingsPath))
                {
                    instance = LoadSettings();
                }
                else
                {
                    throw new Exception("Settings are not setup.");
                }
                
                return instance;
            }
        }

        public static AppSettings LoadOrCreateSettings()
        {
            AppSettings instance;
            if (File.Exists(_settingsPath))
            {
                instance = LoadSettings();
            }
            else
            {
                instance = new AppSettings();
            }

            return instance;
        }

        private static AppSettings LoadSettings()
        {
            string jsonSettings = File.ReadAllText(_settingsPath);
            return JsonSerializer.Deserialize<AppSettings>(jsonSettings);
        }

        public string ProjectLocation { get; set; }
        public string SettingsFileName { get; set; }
        public string SettingsStoreLocation { get; set; }

        public void Save()
        {
            string jsonSettings = JsonSerializer.Serialize<AppSettings>(this);
            File.WriteAllText(_settingsPath, jsonSettings);
        }
    }
}
