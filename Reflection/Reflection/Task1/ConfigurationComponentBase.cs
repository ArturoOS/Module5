using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Task1
{
	public static class ConfigurationComponentBase
	{
		public static void SaveInConfig(object fConfigurationProvider)
		{
			foreach (var prop in Utilities.GetProperties(fConfigurationProvider))
			{
				Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				config.AppSettings.Settings.Add(prop.Name, prop.GetMethod.Invoke(fConfigurationProvider, null).ToString());
				config.Save(ConfigurationSaveMode.Modified);
				ConfigurationManager.RefreshSection("appSettings");
			}
		}
		public static void SaveInJson(ConfigurationManagerConfigurationProvider cmConfigurationProvider)
		{
			var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(cmConfigurationProvider);
			File.WriteAllText(Environment.CurrentDirectory+ "/app.json", jsonString);
		}
		public static Dictionary<string,string> GetInConfig()
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();
			foreach (string key in ConfigurationManager.AppSettings)
			{
				string value = ConfigurationManager.AppSettings[key];
				dic.Add(key,value);
			}
			return dic;
		}
		public static Dictionary<string, string> GetInJson()
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();
			using (StreamReader r = new StreamReader(Environment.CurrentDirectory + "/app.json"))
			{
				string jsonString = r.ReadToEnd();
				var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigurationManagerConfigurationProvider>(jsonString);

				foreach (var prop in Utilities.GetProperties(obj))
				{
					dic.Add(prop.Name, prop.GetMethod.Invoke(obj, null).ToString());
				}
			}
			
			return dic;
		}
	}
}
