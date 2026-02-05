using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public interface IStorage<T>
    {
        Task SaveAsync(List<T> items);
        List<T> Load();
    }
}
