using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConfigurationProviderDLL
{
    public class DLLFileConfigurationProvider
    {
		[ConfigurationItem("StringValue", "File")]
		public string SettingString { get; set; }

		[ConfigurationItem("IntValue", "File")]
		public int SettingInteger { get; set; }

		[ConfigurationItem("DateValue", "File")]
		public DateTime SettingDate { get; set; }

		[ConfigurationItem("FloatValue", "File")]
		public float SettingFloat { get; set; }

		public DLLFileConfigurationProvider(string SettingString, int SettingInteger, DateTime SettingDate, float SettingFloat) 
		{
			this.SettingString = SettingString;
			this.SettingInteger = SettingInteger;
			this.SettingDate = SettingDate;
			this.SettingFloat = SettingFloat;
		}
		public void ToStringRef(string value) 
		{
			Console.WriteLine("Inside DLL by reflection:" + value);
		}
	}

	[AttributeUsage(AttributeTargets.Property)]
	public class ConfigurationItemAttribute : Attribute
	{
		string settingName { get; set; }
		string providerType { get; set; }
		public ConfigurationItemAttribute(string settingName, string providerType)
		{
			this.settingName = settingName;
			this.providerType = providerType;
		}
	}
}
