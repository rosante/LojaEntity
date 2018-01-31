using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LojaEF.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        
        [Required(ErrorMessage="Esse Campo não pode ficar nulo")]
        [StringLength(50,MinimumLength=2)]
        public string Nome { get; set; }
        
        [Required(ErrorMessage="Esse Campo não pode ficar nulo")]
        [DataType(DataType.Text)]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage="Esse Campo não pode ficar nulo")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }
        
        [Required(ErrorMessage="Esse Campo não pode ficar nulo")]
        public int Quantidade { get; set; }

        public ICollection<Pedido> Pedido {get; set;}

    }
}