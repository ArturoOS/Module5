using Reflection.Task1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class Program
    {
		static void Main(string[] args) 
		{
			FileConfigurationProvider fileConfigurationProvider = new FileConfigurationProvider()
			{
				SettingString = "string",
				SettingInteger = 1,
				SettingDate = DateTime.Now,
				SettingFloat = (float)0.335
			};
			ConfigurationComponentBase.SaveInConfig(fileConfigurationProvider);
			var dic = ConfigurationComponentBase.GetInConfig();

			var cmConfigurationProvider = new ConfigurationManagerConfigurationProvider()
			{
				SettingString = "string",
				SettingInteger = 1,
				SettingDate = DateTime.Now,
				SettingFloat = (float)0.335
			};
			ConfigurationComponentBase.SaveInJson(cmConfigurationProvider);
			var dicJson = ConfigurationComponentBase.GetInJson();

			//USING REFLEXION FILE
			var dll = Assembly.LoadFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\FileConfigurationProviderDLL\bin\Debug\FileConfigurationProviderDLL.dll");
			Type dllFileConfigurationProvider = dll.GetType("FileConfigurationProviderDLL.DLLFileConfigurationProvider");
			var instance = Activator.CreateInstance(dllFileConfigurationProvider, "stringValue", 5, DateTime.Now, (float)9.9);
			dllFileConfigurationProvider.InvokeMember("ToStringRef", BindingFlags.InvokeMethod, null, instance, new object[] { @"Reflection" });

			ConfigurationComponentBase.SaveInConfig(instance);

		}
	}
}
