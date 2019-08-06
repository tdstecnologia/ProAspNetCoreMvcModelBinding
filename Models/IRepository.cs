using System.Collections.Generic;

namespace ProAspNetCoreMvcModelBinding.Models
{
    public interface IRepository
    {
        IEnumerable<Person> People { get; }
        Person this[int id] { get; set; }
    }
}
