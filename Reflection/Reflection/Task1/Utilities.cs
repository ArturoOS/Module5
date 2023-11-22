using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Task1
{
	public static class Utilities
	{
		public static IEnumerable<PropertyInfo> GetProperties(object obj)
		{
			return obj.GetType()
			   .GetProperties(BindingFlags.Instance | BindingFlags.Public);
			   //.Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(ConfigurationItemAttribute)));
		}
	}
}
