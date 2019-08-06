using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProAspNetCoreMvcModelBinding.Models
{
    //[Bind(nameof(City))]
    public class AddressSummary
    {
        public string City { get; set; }

        //[BindNever]
        public string Country { get; set; }
    }
}
