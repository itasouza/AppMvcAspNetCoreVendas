using DevIO.App.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.App.ViewModels
{
    public class DetPedidoViewModel : EntityViewModel
    {


        [DisplayName("Qtd. Produto")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int QtdProduto { get; set; }


        [Moeda]
        [DisplayName("Valor Produto")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal ValorProduto { get; set; }


        [Moeda]
        [DisplayName("Valor total produto")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal ValorTotalProduto { get; set; }



        public int CabPedidoId { get; set; }
        public CabPedidoViewModel CabPedido { get; set; }

        public int ProdutoId { get; set; }
        public ProdutoViewModel Produto { get; set; }
    }
}
