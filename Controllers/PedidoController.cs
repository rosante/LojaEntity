using System.Collections.Generic;
using System.Linq;
using LojaEF.Dados;
using LojaEF.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaEF.Controllers
{
    
    [Route("api/[controller]")]
    public class PedidoController:Controller
    {
    
        Pedido Pedido = new Pedido();
        readonly LojaContexto contexto;

        public PedidoController(LojaContexto contexto){
            this.contexto = contexto;
        }



        [HttpGet]
        public IEnumerable<Pedido>Listar(){

            return contexto.Pedido.ToList();
            
        }
        [HttpGet("{id}")]
        public Pedido Listar(int id){

            return contexto.Pedido.Where(x=>x.IdPedido==id).FirstOrDefault();
            
        }

        [HttpPost]
        public void Cadastrar([FromBody] Pedido ped){

            contexto.Pedido.Add(ped);
            contexto.SaveChanges();
            
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,[FromBody] Pedido Pedido)
        {
            if (Pedido==null || Pedido.IdPedido!=id){
                return BadRequest();
            }
            var ped = contexto.Pedido.FirstOrDefault(x=>x.IdPedido==id);
            if(ped==null)
            return NotFound();

            ped.IdPedido= Pedido.IdPedido;
            ped.IdCliente= Pedido.IdCliente;
            ped.IdProduto= Pedido.IdProduto;
            ped.Produto= Pedido.Produto;
            ped.Cliente= Pedido.Cliente;
            ped.Quantidade= Pedido.Quantidade;

            contexto.Pedido.Update(ped);
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