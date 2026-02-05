using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        
        protected readonly string _filePath;
        protected List<T> _items;
        protected int _nextId = 1;
        protected BaseRepository(IStorage<T> storage)
        {

            _items = new List<T>();
            Load();
        }
        private void Load()
        {
            if (!File.Exists(_filePath))
            {
                return;
                    
            }
            string json = File.ReadAllText(_filePath);
            _items = JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }
        public virtual async Task SaveAsync()
        {
            string json = JsonConvert.SerializeObject(_items, Newtonsoft.Json.Formatting.Indented);
            await File.WriteAllTextAsync(_filePath, json);
        }
        public List<T> GetAll() => _items;
        public void Add(T entity) => _items.Add(entity);
        IEnumerable<T> IRepository<T>.GetAll() => _items;
        public abstract T GetById(int id);
       

        
    }


}
