using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUT.Entities
{

    [Serializable]
    public class ItemGut : ICloneable
    {
        #region Variaveis

#pragma warning disable 0169
        private DateTime Modificado;
#pragma warning restore 0169

        #endregion

        #region Construtor

        public ItemGut()
        {
            NotaFiscal = new List<NotaFiscal>();
        }

        #endregion

        #region Propriedades

        public string Identificador
        {
            get
            {
                return string.Format("{0}_{1}_{2}", GuiaUnicaTransporte.Id, NumeroRT, ItemRT);
            }
        }

        [Required]
        [Display(Name = "Guia Única de Transporte")]
        public GuiaUnicaTransporte GuiaUnicaTransporte { get; set; }

        [Required]
        [Display(Name = "Número da Requisição de Transporte")]
        public int NumeroRT { get; set; }

        [Required]
        [Display(Name = "Item da Requisição de Transporte")]
        public int ItemRT { get; set; }

        [Required]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Required]
        [Display(Name = "Unidade de Medida")]
        public UnidadeMedida Unidade { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "A descrição da RT deve ser informada!")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Indicador de descrição de item padrão da GUT")]
        public bool IsDescricaoPadrao { get; set; }

        [Required]
        [Display(Name = "Responsabilidade da Nota Fiscal")]
        public bool ResponsabilidadeNF { get; set; }

        [Required]
        [Display(Name = "Responsabilidade do Transporte")]
        public bool ResponsabilidadeTransporte { get; set; }

        [Required]
        [Display(Name = "Empresa Responsável pela Nota Fiscal")]
        public Empresa EmpresaResponsavel { get; set; }

        [Display(Name = "Nota Fiscal")]
        public IList<NotaFiscal> NotaFiscal { get; set; }

        #endregion Propriedades

        #region Metodos

        public virtual object Clone()
        {
            return base.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (!(obj is ItemGut)) return false;

            var item = obj as ItemGut;

            if ((item.GuiaUnicaTransporte == null && GuiaUnicaTransporte == null) && (item.NumeroRT == 0 && NumeroRT == 0) && (item.ItemRT == 0 && ItemRT == 0))
            {
                return this == obj;
            }

            return (item.GuiaUnicaTransporte.Id == GuiaUnicaTransporte.Id && item.NumeroRT == NumeroRT && item.ItemRT == ItemRT);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

    }

}
