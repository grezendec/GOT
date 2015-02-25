using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUT.Entities
{

    [Serializable]
    public class NotaFiscal : EntityBase<int>
    {

        #region Propriedades

        [Required]
        [StringLength(20, ErrorMessage = "A nota fiscal deve ser informada!")]
        [Display(Name = "Número da Nota Fiscal")]
        public string NumeroNotaFiscal { get; set; }

        [Required]
        [Display(Name = "Data da Nota Fiscal")]
        public DateTime DataNotaFiscal { get; set; }

        #endregion Propriedades

    }

}
