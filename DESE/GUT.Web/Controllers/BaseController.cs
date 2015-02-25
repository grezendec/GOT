using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GUT.Infra;

namespace GUT.Web.Controllers
{
    public class BaseController : Controller
    {
        public PartialViewResult GritterTemplate()
        {
            return PartialView();
        }

        protected void ExibirMensagem(string titulo, string mensagem, GritterMessage.TipoGritter tipo )
        {
            if (!TempData.ContainsKey("msg"))
            {
                TempData["msg"] = new List<GritterMessage>();
            }
            TempData.Keep("msg");

            var gritter = new GritterMessage(titulo, mensagem, tipo);

            ((IList<GritterMessage>)TempData["msg"]).Add(gritter);
        }

        protected void RemoverMensagem()
        {
            TempData.Remove("msg");
        }
    }
}
