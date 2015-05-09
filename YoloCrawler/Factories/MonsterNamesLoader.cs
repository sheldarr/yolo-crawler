namespace YoloCrawler.Factories
{
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    internal static class MonsterNamesLoader
    {
        private const string MonsterNamesFileName = "monsterNames.json";

        public static List<string> Load()
        {
            using (var streamReader = new StreamReader(MonsterNamesFileName))
            {
                var json = streamReader.ReadToEnd();
                var monsters = JsonConvert.DeserializeObject<List<string>>(json);

                return monsters;
            }
        }
    }
}