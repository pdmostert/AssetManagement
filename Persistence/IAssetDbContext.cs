using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence;
public interface IAssetDbContext<T> where T : class
{
    Task<List<T>> Load(string fileName);
    Task Save(string fileName, List<T> data);
}
