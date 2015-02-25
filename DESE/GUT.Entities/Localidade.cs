using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUT.Entities
{

    [Serializable]
    public class Localidade : EntityBase<int>
    {

        #region Propriedades

        [Display(Name = "Descrição da Localidade do Material")]
        public string Descricao { get; set; }

        [Display(Name = "CNPJ da Localidade do Material")]
        public Int64 Cnpj { get; set; }

        [Display(Name = "Inscrição Estadual da Localidade do Material")]
        public Int64 InscricaoEstadual { get; set; }

        #endregion Propriedades

    }

}
