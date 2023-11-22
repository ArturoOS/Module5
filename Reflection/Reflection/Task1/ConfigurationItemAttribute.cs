using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Task1
{
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
