using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public class JsonFileStorage<T> : IStorage<T>
    {
        private readonly string _filePath;

        public JsonFileStorage(string filePath)
        {
            _filePath = filePath;
        }

        public List<T> Load()
        {
            if (!File.Exists(_filePath))
            {
                return new List<T>();
            }
            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }

        public async Task SaveAsync(List<T> items)
        {
            var json = JsonConvert.SerializeObject(items, Newtonsoft.Json.Formatting.Indented);
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}