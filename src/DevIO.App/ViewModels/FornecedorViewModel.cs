using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevIO.App.ViewModels
{
    public class FornecedorViewModel :EntityViewModel
    {

        [DisplayName("Nome Fornecedor")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} caracteres e {1}", MinimumLength = 2)]
        public string Nome { get; set; }

        [DisplayName("Documento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} caracteres e {1}", MinimumLength = 11)]
        public string Documento { get; set; }

        [DisplayName("Tipo de Fornecedor")]
        public int TipoFornecedor { get; set; }

        //para formulario de edição e alteração
        public EnderecoViewModel Endereco { get; set; }

        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
        public ICollection<EnderecoViewModel> Enderecos { get; set; }

    }
}
