using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.IO;
using RepositorioDigital.Models;
using System.Drawing.Drawing2D;
using RepositorioDigital.Permisos;

namespace RepositorioDigital.Controllers
{
    [ValidarSesion]
    public class RepositorioController : Controller
    {
        private static string conexion = ConfigurationManager.ConnectionStrings["cadena"].ToString();
        // GET: Repositorio
        public ActionResult ViewRepositorio()
        {
            if (Convert.ToString(Session["usuario"])== string.Empty)
            {
                return RedirectToAction("ViewLogin", "Login");
            }
            if (Convert.ToInt32(Session["tipouser"]) != 1)
            {
                return RedirectToAction("Index", "Home");
            }

   

            List<ModelRepositorio> repositorios = new List<ModelRepositorio>();
            repositorios = MostrarRepositorio();
            return View(repositorios);

        }

        public List<ModelRepositorio> MostrarRepositorio()
        {
            List<ModelRepositorio> lstRepositorio = new List<ModelRepositorio>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand(@"select * from ViewArchivo ", oconexion);
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ModelRepositorio modelRepositorio = new ModelRepositorio();
                            modelRepositorio.idarchivo = Convert.ToInt32(dr["Id"]);
                            modelRepositorio.titulo = Convert.ToString(dr["Titulo"]);
                            modelRepositorio.materia = Convert.ToString(dr["Materia"]);
                            modelRepositorio.carrera = Convert.ToString(dr["Carrera"]);
                            modelRepositorio.autor = Convert.ToString(dr["Autor"]);
                            modelRepositorio.tipo = Convert.ToString(dr["Tipo"]);

                            lstRepositorio.Add(modelRepositorio);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lstRepositorio = null;
                Console.WriteLine(ex);
            }

            return lstRepositorio;
        }

        [HttpPost]
        public JsonResult AgregarArchivo(string titulo, string materia, string carrera, string autor, string tipo, string ruta)
        {
            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("CrearArchivo", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@titulo", titulo);
                    cmd.Parameters.AddWithValue("@materia", materia);
                    cmd.Parameters.AddWithValue("@carrera", carrera);
                    cmd.Parameters.AddWithValue("@autor", autor);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@ruta", ruta);
                    cmd.Parameters.AddWithValue("@iduser", 2);
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                ;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return Json(new { Error = 1 });
            }


            return Json(new { Error = 0 });
        }

        [HttpPost]
        public JsonResult EditarArchivo(int id, string titulo, string materia, string carrera, string autor, string tipo)
        {
            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("EditarArchivo", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idarchivo", id);
                    cmd.Parameters.AddWithValue("@titulo", titulo);
                    cmd.Parameters.AddWithValue("@materia", materia);
                    cmd.Parameters.AddWithValue("@carrera", carrera);
                    cmd.Parameters.AddWithValue("@autor", autor);
                    cmd.Parameters.AddWithValue("@tipo", tipo);


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
                return Json(new { Error = 1 });
            }
            TempData["MensajeAlerta"] = "Edición de Archivo" + " fue realizado con éxito";
            TempData["MensajeError"] = null;
            return Json(new { Error = 0 });
        }


        [HttpPost]
        public ActionResult EliminarArchivo(ModelRepositorio modelRepositorio)
        {
            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("EliminarArchivo", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idarchivo", modelRepositorio.idarchivo);
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
                return Json(new { Error = 1 });
            }
            TempData["MensajeAlerta"] = "Baja de Archivo" + " fue realizado con éxito";
            TempData["MensajeError"] = null;
            return RedirectToAction("ViewRepositorio", "Repositorio");

        }



        [HttpPost]
        public ActionResult SubirArchivo(HttpPostedFileBase archivo)
        {
            if (archivo != null && archivo.ContentLength > 0)
            {
                try
                {
                    string rutaDestino = @"C:\Repositorio\" + Path.GetFileName(archivo.FileName);
                    archivo.SaveAs(rutaDestino);
                    ViewBag.Mensaje = "Archivo subido correctamente.";
                    TempData["MensajeAlerta"] = "Creación de Archivo" + " fue realizado con éxito";
                    TempData["MensajeError"] = null;
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = "Error al subir el archivo: " + ex.Message;
                    TempData["MensajeAlerta"] = null;
                    TempData["MensajeError"] = "Error";
                }
            }
            else
            {
                ViewBag.Mensaje = "Selecciona un archivo antes de intentar subirlo.";
            }

            return RedirectToAction("ViewRepositorio", "Repositorio");
        }

    }
}