using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Seminar9
{
    public class ReflectionExample
    {
        public static string SaveClassToString(TestClass obj)
        {
            StringBuilder sb = new StringBuilder();

            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                string propertyName = property.Name;
                object propertyValue = property.GetValue(obj);

                sb.AppendLine($"{propertyName}: {propertyValue}");
            }

            return sb.ToString();
        }

        public static TestClass LoadClassFromString(string data)
        {
            TestClass obj = new TestClass();

            string[] lines = data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                string[] parts = line.Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

                string propertyName = parts[0];
                string propertyValue = parts[1];

                PropertyInfo property = obj.GetType().GetProperty(propertyName);

                if (property != null)
                {
                    Type propertyType = property.PropertyType;

                    if (propertyType == typeof(int))
                    {
                        property.SetValue(obj, int.Parse(propertyValue));
                    }
                    else if (propertyType == typeof(string))
                    {
                        property.SetValue(obj, propertyValue);
                    }
                    else if (propertyType == typeof(decimal))
                    {
                        property.SetValue(obj, decimal.Parse(propertyValue));
                    }
                    else if (propertyType == typeof(char[]))
                    {
                        property.SetValue(obj, propertyValue.ToCharArray());
                    }
                }
            }

            return obj;
        }
    }
}
