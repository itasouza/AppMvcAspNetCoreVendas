using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.App.ViewModels
{
    public class EnderecoViewModel : EntityViewModel
    {

        [DisplayName("Nome do Logradouro")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} caracteres e {1}", MinimumLength = 2)]
        public string Logradouro { get; set; }



        [DisplayName("Número")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} caracteres e {1}", MinimumLength = 2)]
        public string Numero { get; set; }


        [DisplayName("Complemento")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} caracteres e {1}", MinimumLength = 2)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Complemento { get; set; }



        [DisplayName("Cep")]
        [StringLength(8, ErrorMessage = "O campo {0} precisa ter entre {2} caracteres e {1}", MinimumLength =8)]
        public string Cep { get; set; }




        [DisplayName("Bairro")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} caracteres e {1}", MinimumLength = 2)]
        public string Bairro { get; set; }



        [DisplayName("Cidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} caracteres e {1}", MinimumLength = 2)]
        public string Cidade { get; set; }



        [DisplayName("Estado")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(2, ErrorMessage = "O campo {0} precisa ter entre {2} caracteres e {1}", MinimumLength = 2)]
        public string Estado { get; set; }



        /*EF relacionamento*/

        public Guid? ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }

        public Guid? FornecedorId { get; set; }
        public FornecedorViewModel Fornecedor { get; set; }

    }
}
