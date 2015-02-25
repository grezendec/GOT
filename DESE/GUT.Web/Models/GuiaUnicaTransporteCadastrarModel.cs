using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GUT.Entities;

namespace GUT.Web.Models
{
    public class GuiaUnicaTransporteCadastrarModel
    {
        public GuiaUnicaTransporteCadastrarModel()
        {
            GuiaUnicaTransporte = new GuiaUnicaTransporte { DataEmissao = DateTime.Now };
            Localidades = new List<Localidade>() { new Localidade() { Descricao = "Localidade 01" }, new Localidade() { Descricao = "Localidade 02" } };
            UnidadesMedida = new List<UnidadeMedida>() { new UnidadeMedida { Sigla = "ton" }, new UnidadeMedida { Sigla = "Unid" } };
            Empresas = new List<Empresa>() { new Empresa { NomeAbreviado = "Empresa 01" }, new Empresa { NomeAbreviado = "Empresa 02" } };
        }

        public GuiaUnicaTransporte GuiaUnicaTransporte { get; set; }

        public IList<Localidade> Localidades { get; set; }

        public IList<UnidadeMedida> UnidadesMedida { get; set; }

        public IList<Empresa> Empresas { get; set; }
    }
}