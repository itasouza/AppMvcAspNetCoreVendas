using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Business.Models
{
    public class DetPedido:Entity
    {


        public int QtdProduto { get; set; }
        public decimal ValorProduto { get; set; }
        public decimal ValorTotalProduto { get; set; }
        public bool Ativo { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }


        public Guid CabPedidoId { get; set; }
        public  CabPedido CabPedido { get; set; }

        public Guid ProdutoId { get; set; }
        public  Produto Produto { get; set; }
    }
}
