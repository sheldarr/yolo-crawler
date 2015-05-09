namespace YoloCrawler
{
    using System.IO;
    using Newtonsoft.Json;

    internal static class KeyMappingLoader
    {
        private const string KeyMappingFileName = "keyMapping.json";

        public static KeyMapping Load()
        {
            using (var streamReader = new StreamReader(KeyMappingFileName))
            {
                var json = streamReader.ReadToEnd();
                var keyMapping = JsonConvert.DeserializeObject<KeyMapping>(json);

                return keyMapping;
            }
        }
    }
}