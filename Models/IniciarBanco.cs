using System.Linq;
using LojaEF.Dados;

namespace LojaEF.Models
{
    public class IniciarBanco
    {
        public static void Inicializar(LojaContexto contexto)
        {
            contexto.Database.EnsureCreated();
            if (contexto.Cliente.Any()){
                return;
            }
            var cliente = new Cliente()
            {Nome="Pedro",Email="pedro@pedro.com",Idade=23};
            contexto.Cliente.Add(cliente);

            var produto = new Produto()
            {Nome="Mouse",Descricao="Mouse Microsoft",Preco=23,Quantidade=7};
            contexto.Produto.Add(produto);

            var pedido = new Pedido()
            {IdCliente=cliente.IdCliente,IdProduto=produto.IdProduto,Quantidade=2};
            contexto.Pedido.Add(pedido);

        }
    }
}