using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Business.Models
{
    public class CabPedido:Entity
    {      
        public string Observacoes { get; set; }
        public bool Ativo { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public Guid ClienteId { get; set; }
        public  Cliente Cliente { get; set; }
        public  ICollection<DetPedido> DetPedido { get; set; }
    }
}
