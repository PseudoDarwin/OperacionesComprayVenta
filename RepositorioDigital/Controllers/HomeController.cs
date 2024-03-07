using RepositorioDigital.Models;
using RepositorioDigital.Permisos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepositorioDigital.Controllers
{
    [ValidarSesion]
    public class HomeController : Controller
    {
        private static string conexion = ConfigurationManager.ConnectionStrings["cadena"].ToString();
        public ActionResult Index()
        {
            if (Convert.ToString(Session["usuario"]) == string.Empty)
            {
                return RedirectToAction("ViewLogin", "Login");
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

        public ActionResult DescargarArchivo(string nombreArchivo)
        {
            string ruta="";

            using (SqlConnection oconexion = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand(@"select RutaArchivo from Archivo  where TituloArchivo = '" + nombreArchivo+"'", oconexion);
                oconexion.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ruta = Convert.ToString(dr["RutaArchivo"]);
                    }
                }
            }
             nombreArchivo = Path.GetFileName(ruta);
            if (System.IO.File.Exists(ruta))
            {
                return File(ruta, "application/octet-stream", nombreArchivo);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}