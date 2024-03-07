using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using RepositorioDigital.Models;

namespace RepositorioDigital.Controllers
{
    public class LoginController : Controller
    {
        private static string conexion = ConfigurationManager.ConnectionStrings["cadena"].ToString();
        // GET: Login
        public ActionResult ViewLogin()
        {
            Session["usuario"] = string.Empty;
            Session["tipouser"] = 0;
            return View();
        }

        [HttpPost]
        public ActionResult ViewLogin(ModelUsuario oUsuario)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("IniciarSesion", cn);
                cmd.Parameters.AddWithValue("@Usuario", oUsuario.nombreuser);
                cmd.Parameters.AddWithValue("@contra", oUsuario.contra);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                try
                {
                    oUsuario.iduser = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
                catch (Exception ex)
                {
                    oUsuario.iduser = 0;
                    Console.WriteLine(ex.Message);
                }


            }

            if (oUsuario.iduser != 0)
            {
                Session["usuario"] = oUsuario;
                Session["tipouser"] = TipoUser(oUsuario.nombreuser);
                RepositorioDigital.Utilidades.VariablesPublicas.usuario = oUsuario.nombreuser;
                RepositorioDigital.Utilidades.VariablesPublicas.tipouser = Convert.ToString(TipoUser(oUsuario.nombreuser));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["MensajeLogin"] = " Usuario o contraseña erroneos";
                return View();
            }


        }

        int TipoUser(string usuario)
        {
            int tipo = 0;
            using (SqlConnection oconexcion = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("ComprobartipoUser", oconexcion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                oconexcion.Open();
                cmd.ExecuteNonQuery();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        tipo = Convert.ToInt32(dr["Tipo"]);
                    }
                }
            }
            return tipo;
        }

    }
}