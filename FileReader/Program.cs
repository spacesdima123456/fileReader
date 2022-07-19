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
                Console.WriteLine("Create object: " + MakeObject(args[0]));
            }
        }

        public static object MakeObject(string path)
        {
            var lines = ReadIniFile(path);
            return ToObjIniFile<TestIniObj>(lines);
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
                    if (!string.IsNullOrEmpty(line.Value))
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



