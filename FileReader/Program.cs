using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileReader.Models;

namespace FileReader
{
   public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                var lines = ReadIniFile(args[0]);
                var objIniFile = ToObjIniFile<TestIniObj>(lines);
                Console.WriteLine("Create object: " + objIniFile);
            }
        }

        private static T ToObjIniFile<T>(Dictionary<string, string> lines) where T : class, new()
        {
            var type = typeof(T);
            var instance = Activator.CreateInstance(type);
            var properties = typeof(T).GetProperties().ToList();

            foreach (var line in lines)
            {
                var hasProperty = properties.Any(a => a.Name == line.Key);
                if (hasProperty)
                {
                    var property = type.GetProperty(line.Key);

                    if (string.IsNullOrEmpty(line.Value))
                        throw new ArgumentException("The argument cannot be empty or null", line.Key);
                    
                    property?.SetValue(instance, Convert.ChangeType(line.Value, property.PropertyType), null);
                }
            }
            return (T)Convert.ChangeType(instance, typeof(T));
        }

        private static Dictionary<string, string> ReadIniFile(string path)=> 
            File.ReadAllLines(path)
                .Where(w => w != string.Empty)
                .ToDictionary(s => s.Split('=')[0].Trim(), s => s.Split('=')[1].Trim());
    }
}  



