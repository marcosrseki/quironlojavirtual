using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;

namespace Quiron.LojaVirtual.Web.Controllers
{
    //Dentro do webconfig, foi definido que a autenticacao seria pelo controle Autenticacao
    public class AutenticacaoController : Controller
    {
        private AdministradoresRepositorio _repositorio;

        //Dentro do webconfig, foi definido que a autenticacao seria pelo controle Autenticacao e ACTION Login
        //A stringUrl ira vir por GET
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new Administrador());
        }
        
        [HttpPost]
        public ActionResult Login(Administrador administrador, string returnUrl)
        {
            _repositorio = new AdministradoresRepositorio();

            if (ModelState.IsValid)
            {
                Administrador admin = _repositorio.ObterAdministrador(administrador);

                if (admin != null)
                {
                    //Se forem direferentes
                    if (!Equals(administrador.Senha,admin.Senha))
                    {
                        ModelState.AddModelError("", "Senha não confere");
                    }
                    else
                    {
                        //Usuario conectado e se o login é permanente, neste caso ao fechar a pagina tem que logar novamente.
                        FormsAuthentication.SetAuthCookie(admin.Login, false);

                        //Faz todas as validações sobre a url de conexao
                        if (Url.IsLocalUrl(returnUrl)
                            && returnUrl.Length > 1
                            && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//")
                            && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("","Administrador não localizado");
                }
            }
            return View(new Administrador());
        }
    }
}