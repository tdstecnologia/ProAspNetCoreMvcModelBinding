using System.Collections.Generic;

namespace ProAspNetCoreMvcModelBinding.Models
{
    public interface IRepository
    {
        IEnumerable<Pessoa> Pessoa { get; }
        Pessoa this[int id] { get; set; }
    }
}
