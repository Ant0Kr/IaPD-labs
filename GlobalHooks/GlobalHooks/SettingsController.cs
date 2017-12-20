using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace GlobalHooks
{
    public class SettingsController
    {
        private const string FileName = "./settings.txt";
        public Settings UpdateProgram()
        {
            try
            {
                using (var streamReader = new StreamReader(FileName))
                {
                    return JsonConvert.DeserializeObject<Settings>(Decode(streamReader.ReadToEnd()));
                }
            }
            catch (Exception)
            {
                return new Settings();
            }
        }

        public void SaveConfig(Settings config)
        {
            using (var streamWriter = new StreamWriter(FileName, false))
            {
                streamWriter.Write(Encode(JsonConvert.SerializeObject(config)));
            }
        }

        private static string Encode(string content)
        {
            var tempList = content.ToList();
            for (var i = 0; i < tempList.Count; i++)
            {
                tempList[i] = (char)(tempList[i] + 1);
            }
            return string.Join("", tempList);
        }

        private static string Decode(string content)
        {
            var tempList = content.ToList();
            for (var i = 0; i < tempList.Count; i++)
            {
                tempList[i] = (char)(tempList[i] - 1);
            }
            return string.Join("", tempList);
        }
    }
}
