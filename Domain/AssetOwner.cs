using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class AssetOwner: Entity
{
    public AssetOwner()
    {
        
    }
    public AssetOwner(string fullName)
    {
        FullName = fullName;
    }
    public string FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Department { get; set; }

}
