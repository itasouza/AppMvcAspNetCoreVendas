using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.App.ViewModels
{
    public class CabPedidoViewModel : EntityViewModel
    {

        [DisplayName("Observações Pedido")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} caracteres e {1}", MinimumLength = 2)]
        public string Observacoes { get; set; }

        public int ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public ICollection<DetPedidoViewModel> DetPedido { get; set; }

    }
}
