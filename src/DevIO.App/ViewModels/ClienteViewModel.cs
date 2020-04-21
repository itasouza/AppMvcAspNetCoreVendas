using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.App.ViewModels
{
    public class ClienteViewModel : EntityViewModel
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} caracteres e {1}", MinimumLength = 2)]
        public string Nome { get; set; }


        [DisplayName("Documento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} caracteres e {1}", MinimumLength = 14)]
        public string Documento { get; set; }


        [DisplayName("Tipo de Cliente")]
        public int TipoCliente { get; set; }

        //para formulario de edição e alteração
        public EnderecoViewModel Endereco { get; set; }

        public ICollection<CabPedidoViewModel> CabPedido { get; set; }
        public ICollection<EnderecoViewModel> Enderecos { get; set; }
    }
}
