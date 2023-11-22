using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Task1
{
	public class ConfigurationManagerConfigurationProvider
	{
		[ConfigurationItem("StringValue", "Configuration Manager")]
		public string SettingString { get; set; }

		[ConfigurationItem("IntValue", "Configuration Manager")]
		public int SettingInteger { get; set; }

		[ConfigurationItem("DateValue", "Configuration Manager")]
		public DateTime SettingDate { get; set; }

		[ConfigurationItem("FloatValue", "Configuration Manager")]
		public float SettingFloat { get; set; }
	}
}
