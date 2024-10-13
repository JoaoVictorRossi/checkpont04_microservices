using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using MySqlConnector;
using Newtonsoft.Json;
using StackExchange.Redis;
using web_app_domain;
using web_app_repository;

namespace web_performance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private static ConnectionMultiplexer redis;
        private readonly IProdutoRepository _repository;

        public ProdutoController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetProdutos()
        {

            var produtos = await _repository.ListarProdutos();
            if (produtos == null)
            {
                return NotFound();
            }

            string produtosJson = JsonConvert.SerializeObject(produtos);

            return Ok(produtos);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Produto produto)
        {
            await _repository.SalvarProduto(produto);

            return Ok(new { mensagem = "Produto criao com sucesso!" });
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Produto produto)
        {

            await _repository.AtualizarProduto(produto);

            string key = "getprodutos";
            redis = ConnectionMultiplexer.Connect("localhost:6379");
            IDatabase db = redis.GetDatabase();
            await db.KeyDeleteAsync(key);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.RemoverProduto(id);

            string key = "getprodutos";
            redis = ConnectionMultiplexer.Connect("localhost:6379");
            IDatabase db = redis.GetDatabase();
            await db.KeyDeleteAsync(key);

            return Ok();
        }
    }
}
