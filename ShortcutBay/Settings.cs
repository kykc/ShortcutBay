using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ShortcutBay
{
    public class Settings
    {
        [JsonIgnore]
        public string DbPath => Path.Join(DetermineStateLocation(), "db");

        [JsonIgnore]
        public string AppName => "ShortcutBay";

        [JsonIgnore] public string Version => Assembly.GetEntryAssembly()?.GetName()?.Version?.Major.ToString() ?? "";

        public Dictionary<string, Point> MainFormPositions { get; set; } = new();
        public bool WasStartedBefore { get; set; } = false;
        public bool AlwaysOnTop { get; set; } = false;
        public bool ExcludeFullScreen { get; set; } = true;
        public bool HideOnLostFocus { get; set; } = false;
        public string ShortcutKey { get; set; } = "CtrlQ";

        public void Save()
        {
            using var fileStream = new FileStream(Path.Join(DetermineStateLocation(), "settings.json"), FileMode.Truncate, FileAccess.ReadWrite);
            string settingsJson = JsonSerializer.Serialize<Settings>(this, SettingsJsonGenerationContext.Default.Settings);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.Write(settingsJson);
            streamWriter.Flush();
        }

        public static Settings? Load()
        {
            using var fileStream = new FileStream(Path.Join(DetermineStateLocation(), "settings.json"), FileMode.OpenOrCreate, FileAccess.Read);

            using var streamReader = new StreamReader(fileStream);
            var json = streamReader.ReadToEnd();

            if (json.Trim().Length == 0)
            {
                return null;
            }

            try
            {
                return JsonSerializer.Deserialize<Settings>(json, SettingsJsonGenerationContext.Default.Settings);

            }
            catch (Exception e)
            {
                string msg = $"{e.GetType().ToString()} with message {e.Message} when deserializing config";

                Debug.WriteLine($"ERROR: {msg}");
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public static string DetermineStateLocation()
        {
            var chocoLocation = Environment.GetEnvironmentVariable("ChocolateyInstall");
            var selfLocation = Path.GetDirectoryName(System.Environment.ProcessPath);

            bool isChocoPackage = Util.isSubdirectory(selfLocation, chocoLocation);
            bool isPortable = selfLocation != null && File.Exists(Path.Combine(selfLocation, "portable_mode"));

            if (isPortable)
            {
                var result = selfLocation!;
                Directory.CreateDirectory(result);
                return result;
            }
            else if (isChocoPackage)
            {
                var result = Path.Join(chocoLocation, "aupack-data", "shortcutbay.portable");
                Directory.CreateDirectory(result);
                return result;
            }
            else
            {
                var result = Path.Join(Environment.GetEnvironmentVariable("LocalAppData"), "ShortcutBay");
                Directory.CreateDirectory(result);
                return result;
            }
        }
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Settings))]
    public partial class SettingsJsonGenerationContext: JsonSerializerContext { }
}
