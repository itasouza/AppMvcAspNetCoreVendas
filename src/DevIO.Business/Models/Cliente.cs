using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Business.Models
{
    public class Cliente:Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedorCliente TipoCliente { get; set; }
        public bool Ativo { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public ICollection<CabPedido> CabPedido { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
    }
}
