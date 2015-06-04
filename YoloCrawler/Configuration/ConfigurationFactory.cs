using System;

namespace YoloCrawler.Configuration
{
    using System.IO;
    using Newtonsoft.Json;

    public static class ConfigurationFactory
    {
        public static T FromFile<T>(string bindingsFilePath) where T : Configuration<T>
        {
            if (!File.Exists(bindingsFilePath))
            {
                var defaultConfiguration = Activator.CreateInstance<T>().Default;
                SetupDefaultBindigFile(defaultConfiguration, bindingsFilePath);

                return defaultConfiguration;
            }

            var fileContents = File.ReadAllText(bindingsFilePath);

            var configuration = JsonConvert.DeserializeObject<T>(fileContents);

            if (configuration == null)
            {
                var defaultConfiguration = Activator.CreateInstance<T>().Default;
                SetupDefaultBindigFile(defaultConfiguration, bindingsFilePath);

                return defaultConfiguration;
            }

            return configuration;
        }

        private static void SetupDefaultBindigFile(object configuration, string configFilePath)
        {
            var serializedConfig = JsonConvert.SerializeObject(configuration);

            File.WriteAllText(configFilePath, serializedConfig);
        }
    }
}
