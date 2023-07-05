using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repository;
using MessagePack.Resolvers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Npgsql.Internal.TypeHandlers.FullTextSearchHandlers;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo ?? throw new ArgumentException(null, nameof(repo));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        //Ienumerable é um tipo de List, mas ele é mais recomendado quando queremos apenas a ler uma lista ou quando a lista é muito grande e não queremos salvá-la toda na memória.
        //Ele não tem metodos para alterar a lista como o List tem, por exemplo, não daria pra fazer algo como nomesList.where(x => x.Contains....)
        {
            var products = await _repo.FindAll();

            if (products == null) return NotFound();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _repo.FindById(id);

            if (product.Id <= 0) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create([FromBody] ProductVO vo) {

            if (vo == null) return BadRequest();

            var product = await _repo.Create(vo);
            return Ok(product);

        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO vo)
        {
            if (vo == null) return BadRequest();

            var product = await _repo.Update(vo);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repo.Delete(id);
            if (!status) return BadRequest();

            return Ok(status);
        }


    }
}
