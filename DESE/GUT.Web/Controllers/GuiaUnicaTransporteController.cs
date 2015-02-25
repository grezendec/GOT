using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GUT.Core.Repositories;
using GUT.Entities;
using GUT.Infra.Security;
using GUT.Web.Models;

namespace GUT.Web.Controllers
{

    [CustomAuthorize(Roles = "GUT_ADMINISTRADOR")]
    public class GuiaUnicaTransporteController : BaseController
    {
        public ActionResult Consultar()
        {
            //var usuarioRepositorio = DependencyResolver.Current.GetService<IRepositorio<Usuario>>();
            //var usuarios = usuarioRepositorio.Listar().ToList();

            return View();
        }

        public ActionResult Cadastrar()
        {
            return View(new GuiaUnicaTransporteCadastrarModel());
        }

    }
}
