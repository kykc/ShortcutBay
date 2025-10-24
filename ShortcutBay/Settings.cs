using System.Text.Json;
using System.Text.Json.Serialization;

namespace ShortcutBay
{
    public class Settings
    {
        public string DbPath { get; set; } = "db";
        public string AppName { get; private set; } = "ShortcutBay";
        public string Version { get; private set; } = "3.0";

        public Dictionary<string, Point> MainFormPositions { get; set; } = new();
        public bool WasStartedBefore { get; set; } = false;
        public bool AlwaysOnTop { get; set; } = false;
        public bool ExcludeFullScreen { get; set; } = true;
        public bool HideOnLostFocus { get; set; } = false;
        public string ShortcutKey { get; set; } = "CtrlQ";

        public void Save()
        {
            using var fileStream = new FileStream(Path.Join("settings.json"), FileMode.OpenOrCreate, FileAccess.Write);
            string settingsJson = JsonSerializer.Serialize<Settings>(this, SettingsJsonGenerationContext.Default.Settings);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.Write(settingsJson);
            streamWriter.Flush();
        }

        public static Settings? Load()
        {
            var exeDir = Path.GetDirectoryName(System.Environment.ProcessPath);

            if (exeDir != null)
            {
                using var fileStream = new FileStream(Path.Join("settings.json"), FileMode.OpenOrCreate, FileAccess.Read);

                using var streamReader = new StreamReader(fileStream);
                var json = streamReader.ReadToEnd();
                try
                {
                    return JsonSerializer.Deserialize<Settings>(json, SettingsJsonGenerationContext.Default.Settings);

                }
                catch (Exception e)
                {
                    // TODO: log exception
                }
            }

            return null;
        }
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Settings))]
    public partial class SettingsJsonGenerationContext: JsonSerializerContext { }
}
