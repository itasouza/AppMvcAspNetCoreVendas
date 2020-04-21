using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.App.ViewModels
{
    public class EntityViewModel
    {
        [Key]
        public Guid Id { get; set; }


        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        [DisplayName("DataCadastro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [ScaffoldColumn(false)]
        public DateTime? DataCadastro { get; set; }


        [DisplayName("DataAlteracao")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [ScaffoldColumn(false)]
        public DateTime? DataAlteracao { get; set; }

    }
}
