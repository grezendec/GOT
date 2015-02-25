using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUT.Entities
{
    [Serializable]
    public class GuiaUnicaTransporte : EntityBase<int>
    {

        #region Enums

        public enum SituacoesGut
	    {
	        Nova = 1,
            Preenchida = 2,
            Emitida = 3,
            Pendente = 4,
            PendenteAprovacaoTributario = 5,
            NaoConforme = 6,
            Conforme = 7,
            AutorizadoTributario = 8,
            Cancelada = 100, 
            Inutilizada = 101
	    }

        public enum FinalidadesOperacao
        {
            [Display(Name = "Exploração & Producao Marítima")]
            ExploracaoProducaoMaritima = 1,

            [Display(Name = "Manutenção de Equipamentos")]
            ManutencaoEquipamentos = 2
        }

        #endregion Enums


        #region Propriedades


        [Display(Name = "Número da GUT")]
        [StringLength(20)]
        public string Numero { get; set; }

        [Display(Name = "Série da GUT")]
        [StringLength(20)]
        public string Serie { get; set; }

        [Display(Name = "Data da Emissão da GUT")]
        public DateTime DataEmissao { get; set; }

        [Required]
        [Display(Name = "Empresa de Origem do Material")]
        public Localidade Origem { get; set; }

        [Required]
        [Display(Name = "Empresa de Destino do Material")]
        public Localidade Destino { get; set; }

        [Required]
        [Display(Name = "Finalidade da Operação")]
        public FinalidadesOperacao FinalidadeOperacao { get; set; }

        [Display(Name = "Indicador de GUT enviada ao Tributário")]
        public bool EnviadoTributario { get; set; }

        [StringLength(4000)]
        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        [StringLength(200)]
        [Display(Name = "Descrição Padrão dos Itens desta GUT")]
        public string DescricaoPadrao { get; set; }

        [Display(Name = "Situação da GUT")]
        public SituacoesGut Status { get; set; }

        [Display(Name = "Lista de Itens da GUT")]
        public IList<ItemGut> ItensGut { get; set; }


        #endregion Propriedades


        #region Construtor

        public GuiaUnicaTransporte()
        {
            ItensGut = new List<ItemGut>();
        } 

        #endregion Construtor

    }
}
