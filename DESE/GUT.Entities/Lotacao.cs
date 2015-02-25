using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUT.Entities
{
    [Serializable]
    public class Lotacao : EntityBase<int>
    {

        #region Propriedades

        [Display(Name = "Sigla da Lotação")]
        public string Sigla { get; set; }

        [Display(Name = "Orgão Menor da Lotação")]
        public string OrgaoMenor { get; set; }

        [Display(Name = "Descrição da Lotação")]
        public string Descricao { get; set; }

        #endregion Propriedades

    }
}
