namespace RMMVResourceManager
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    using Newtonsoft.Json;

    public class Configuration
    {
        public string LastProject { get; set; }

        public string[] DirectoryIgnoreList { get; set; } = { ".git", ".vscode", ".idea" };

        public string[] FileTypeIgnoreList { get; set; } = { "" };

        public static Configuration Instance { get; set; } = new Configuration();

        public static void LoadConfig()
        {
            if (File.Exists("config.json"))
            {
                try
                {
                    Instance = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText("config.json"));
                }
                catch
                {
                    Instance = new Configuration();
                    Instance.Serialize();
                }
            }
        }

        public void Serialize()
        {
            try
            {
                File.WriteAllText("config.json", JsonConvert.SerializeObject(this, Formatting.Indented));
            }
            catch (Exception)
            {
                MessageBox.Show("Could not create config.json!");
            }
        }
    }
}