using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using RepositorioDigital.Models;
using System.Runtime.InteropServices;
using RepositorioDigital.Permisos;

namespace RepositorioDigital.Controllers
{
    [ValidarSesion]
    public class UsuarioController : Controller
    {
        private static string conexion = ConfigurationManager.ConnectionStrings["cadena"].ToString();
        // GET: Usuario
        public ActionResult ViewUsuario()
        {
            if (Convert.ToString(Session["usuario"]) == string.Empty)
            {
                return RedirectToAction("ViewLogin", "Login");
            }
            if (Convert.ToInt32(Session["tipouser"]) != 1)
            {
                return RedirectToAction("Index", "Home");
            }
            List<ModelUsuario> lstuser = new List<ModelUsuario>();
            lstuser = MostrarUsuario();
            return View(lstuser);
        }

        [HttpPost]
        public JsonResult AgregarUsuario(string nombreUsuario, string correo, string contra, string contra2)
        {
            if (nombreUsuario == string.Empty)
            {
                return Json(new { Error = 1 });
            }
            try
            {
                if (contra == contra2)
                {
                    using (SqlConnection oconexion = new SqlConnection(conexion))
                    {
                        SqlCommand cmd = new SqlCommand("CrearUsuario", oconexion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@contra", contra);

                        oconexion.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        TempData["MensajeAlerta"] = "Usario fue agregado con éxito";
                        TempData["MensajeError"] = null;
                    };
                }
                else
                {
                    return Json(new { Error = 2 });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return Json(new { Error = 1 });
            }


            return Json(new { Error = 0 });
        }



        [HttpPost]
        public JsonResult EditarUsuario(int iduser, string nombreUsuario, string correo)
        {
            if (nombreUsuario == string.Empty)
            {
                return Json(new { Error = 1 });
            }
            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("EditarUsuario", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario", iduser);
                    cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                    TempData["MensajeAlerta"] = "Edición de Usuario" + " fue realizado con éxito";
                    TempData["MensajeError"] = null;
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return Json(new { Error = 1 });
            }
            return Json(new { Error = 0 });
        }



        [HttpPost]
        public ActionResult EliminarUsuario(ModelUsuario modelUsuario)
        {
            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("EliminarUsuario", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario", modelUsuario.iduser);
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                };
            }
            catch (Exception e)
            {
                TempData["MensajeAlerta"] = null;
                TempData["MensajeError"] = "Error";
                Console.WriteLine("Error: " + e);

            }
            TempData["MensajeAlerta"] = "Baja de Usuario" + " fue realizado con éxito";
            TempData["MensajeError"] = null;
            return RedirectToAction("ViewUsuario", "Usuario");

        }


        [HttpPost]
        public JsonResult CambiarContra(string idusuario, string contra, string contra2)
        {

            try
            {
                if (contra == contra2)
                {
                    using (SqlConnection oconexion = new SqlConnection(conexion))
                    {
                        SqlCommand cmd = new SqlCommand("CambiarContra", oconexion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idUsuario", idusuario);
                        cmd.Parameters.AddWithValue("@contra", contra);

                        oconexion.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        TempData["MensajeAlerta"] = "Cambio de contraseña" + " fue realizado con éxito";
                        TempData["MensajeError"] = null;
                    };
                }
                else
                {
                    return Json(new { Error = 2 });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return Json(new { Error = 1 });
            }


            return Json(new { Error = 0 });
        }




        public List<ModelUsuario> MostrarUsuario()
        {
            List<ModelUsuario> lstuser = new List<ModelUsuario>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand(@"select * from ViewUsuario ", oconexion);
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ModelUsuario model = new ModelUsuario();
                            model.iduser = Convert.ToInt32(dr["ID"]);
                            model.nombreuser = Convert.ToString(dr["Nombre"]);
                            model.correouser = Convert.ToString(dr["Correo"]);


                            lstuser.Add(model);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lstuser = null;
                Console.WriteLine(ex);
            }

            return lstuser;
        }

    }
}