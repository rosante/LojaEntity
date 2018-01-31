using System.Collections.Generic;
using System.Linq;
using LojaEF.Dados;
using LojaEF.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaEF.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController:Controller
    {
    
        Produto Produto = new Produto();
        readonly LojaContexto contexto;

        public ProdutoController(LojaContexto contexto){
            this.contexto = contexto;
        }



        [HttpGet]
        public IEnumerable<Produto>Listar(){

            return contexto.Produto.ToList();
            
        }
        [HttpGet("{id}")]
        public Produto Listar(int id){

            return contexto.Produto.Where(x=>x.IdProduto==id).FirstOrDefault();
            
        }

        [HttpPost]
        public void Cadastrar([FromBody] Produto pro){

            contexto.Produto.Add(pro);
            contexto.SaveChanges();
            
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,[FromBody] Produto Produto)
        {
            if (Produto==null || Produto.IdProduto!=id){
                return BadRequest();
            }
            var pro = contexto.Produto.FirstOrDefault(x=>x.IdProduto==id);
            if(pro==null)
            return NotFound();

            pro.IdProduto= Produto.IdProduto;
            pro.Nome= Produto.Nome;
            pro.Descricao = Produto.Descricao;
            pro.Preco= Produto.Preco;
            pro.Quantidade= Produto.Quantidade;
            contexto.Produto.Update(pro);
            int rs = contexto.SaveChanges();

            if(rs > 0){
                return Ok();
            }
            else{
                return BadRequest();
            }

        }
    }
}