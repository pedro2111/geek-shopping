using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekShopping.ProductAPI.Data.ValueObjects
{
    public class ProductVO
    //o VO funciona como o DTO no java, mesma funcionalidade. Invés de expor a entidade para o cliente mandamos o VO ou DTO. Se a entidade mudar, não quebra o cliente.
    {
        public long Id {get; set;}
        public string? Name {get; set;}
        public decimal Price {get; set;}
        public string? Description {get; set;}
        public string? CategoryName {get; set;}
        public string? ImageUrl {get; set;}
    }
}