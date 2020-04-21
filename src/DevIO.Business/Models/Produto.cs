using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Business.Models
{
    public class Produto:Entity
    {

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataValidade { get; set; }
        public bool ProdutoPromocao { get; set; }
        public bool Ativo { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }


        public Guid FornecedorId { get; set; }
        public  Fornecedor Fornecedor { get; set; }

        public  ICollection<DetPedido> DetPedido { get; set; }
    }
}
