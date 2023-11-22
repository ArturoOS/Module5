using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Task1
{
	public class FileConfigurationProvider
	{
		[ConfigurationItem("StringValue", "File")]
		public string SettingString { get; set; }

		[ConfigurationItem("IntValue", "File")]
		public int SettingInteger { get; set; }

		[ConfigurationItem("DateValue", "File")]
		public DateTime SettingDate { get; set; }

		[ConfigurationItem("FloatValue", "File")]
		public float SettingFloat { get; set; }

	}
}
