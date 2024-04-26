using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence;

/// <summary>
/// Represents the interface for a generic asset database context.
/// </summary>
/// <typeparam name="T">The type of the asset.</typeparam>
public interface IAssetDbContext<T> where T : class
{
    /// <summary>
    /// Loads the asset data from the specified file.
    /// </summary>
    /// <param name="fileName">The name of the file to load.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the loaded asset data.</returns>
    Task<List<T>> Load(string fileName);

    /// <summary>
    /// Saves the asset data to the specified file.
    /// </summary>
    /// <param name="fileName">The name of the file to save.</param>
    /// <param name="data">The asset data to save.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Save(string fileName, List<T> data);
}
