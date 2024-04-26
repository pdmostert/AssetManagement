using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
/// <summary>
/// Base Class for all Domain Models to inherit from as well as gain Id property, this class is abstract so that it cant be instantiated.
/// </summary>
public abstract class Entity
{
    public Guid Id { get; set; }

    public Entity()
    {
        Id = Guid.NewGuid();
    }


}
