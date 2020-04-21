using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Business.Models
{
    public class Endereco:Entity
    {

        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public bool Ativo { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

        /*EF relacionamento*/

        public Guid? ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public Guid? FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
