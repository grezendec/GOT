using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUT.Entities
{
    [Serializable]
    public class UnidadeMedida : EntityBase<int>
    {

        #region Propriedades

        [Display(Name = "Descrição da Unidade de Medida")]
        public string Descricao { get; set; }

        [Display(Name = "Sigla da Unidade de Medida")]
        public string Sigla { get; set; }

        [Display(Name = "Abreviação da Unidade de Medida")]
        public string Nome { get; set; }

        #endregion Propriedades

    }
}
