using System;
using System.ComponentModel.DataAnnotations;

namespace GUT.Entities
{
    [Serializable]
    public class Usuario : EntityBase<string>
    {
        #region Propriedades

        [Display(Name = "Nome do Usuário")]
        public virtual string Nome { get; set; }

        [Display(Name = "Nome de Guerra do Usuário")]
        public virtual string Guerra { get; set; }

        [Display(Name = "Chave do Usuário")]
        public virtual string Chave { get; set; }

        [Display(Name = "Cargo do Usuário")]
        public virtual string Cargo { get; set; }

        [Display(Name = "Lotação do Usuário")]
        public virtual string Lotacao { get; set; }

        [Display(Name = "Email do Usuário")]
        public virtual string Email { get; set; }

        [Display(Name = "Indicador de Gerente")]
        public virtual bool IsGerente { get; set; }

        #endregion Propriedades
    }
}
