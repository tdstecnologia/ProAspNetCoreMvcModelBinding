using Microsoft.AspNetCore.Mvc;

namespace ProAspNetCoreMvcModelBinding.Models
{
    [Bind(nameof(City))]
    public class AddressSummary
    {
        public string City { get; set; }
        public string Country { get; set; }
    }
}
