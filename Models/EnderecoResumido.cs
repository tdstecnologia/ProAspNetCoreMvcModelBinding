using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProAspNetCoreMvcModelBinding.Models
{
    [Bind(nameof(Cidade))]
    public class EnderecoResumido
    {
        public string Cidade { get; set; }

        [BindNever]
        public string Pais { get; set; }
    }
}
