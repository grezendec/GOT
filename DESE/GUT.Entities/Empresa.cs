using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUT.Entities
{

    [Serializable]
    public class Empresa : EntityBase<int>
    {

        #region Propriedades

        [Required]
        [Display(Name = "Descrição da Empresa")]
        [StringLength(200, ErrorMessage = "O nome da empresa deve ser informado!")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Descrição Abreviada da Empresa")]
        [StringLength(50, ErrorMessage = "A descrição abreviada deve ser informada!")]
        public string NomeAbreviado { get; set; }

        [Required]
        [Display(Name = "CNPJ da Empresa")]
        [StringLength(20, ErrorMessage = "O CNPJ da empresa deve ser informado!")]
        public string Cnpj { get; set; }

        [Required]
        [Display(Name = "Inscrição Estadual da Empresa")]
        [StringLength(20, ErrorMessage = "A Inscrição Estadual da empresa deve ser informada!")]
        public string InscricaoEstadual { get; set; }

        [Display(Name = "Indicador de Empresa do Grupo Petrobras")]
        public bool IsPetrobras { get; set; }

        #endregion Propriedades

    }

}
