using Microsoft.AspNetCore.Mvc;
using Npgsql;
using proyectoFinalEvaluacionC.Models;
using proyectoFinalEvaluacionC.Models.Conexiones;
using proyectoFinalEvaluacionC.Models.Consultas;
using proyectoFinalEvaluacionC.Models.DTOs;
using proyectoFinalEvaluacionC.Util;
using System.Diagnostics;

namespace proyectoFinalEvaluacionC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(ConexionBaseDatos conexionPostgreSQL)
        {
            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Entra en Index");

            //CONSTANTES
            const string HOST = VariablesBasesDatos.HOST;
            const string PORT = VariablesBasesDatos.PORT;
            const string USER = VariablesBasesDatos.USER;
            const string PASS = VariablesBasesDatos.PASS;
            const string DB = VariablesBasesDatos.DB;

            //Se genera una conexión a PostgreSQL y validamos que esté abierta fuera del método
            var estadoGenerada = "";
            NpgsqlConnection conexionGenerada = new NpgsqlConnection();

            List<ProductoDTO> listProducto = new List<ProductoDTO>();

            conexionGenerada = conexionPostgreSQL.GeneraConexion(HOST, PORT, DB, USER, PASS);
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Estado conexión generada: " + estadoGenerada);

            //Se realiza la consulta y se guarda una lista de alumnosDTO
            listProducto = ConsultaBaseDeDatos.InsertarBBDD(conexionGenerada);
            listProducto = ConsultaBaseDeDatos.ConsultaBBDD(conexionGenerada);

            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index]");

            foreach (ProductoDTO p in listProducto)
            {
                System.Console.WriteLine("Producto: " + p.Id_producto + " " + p.Nombre_producto);

            }

            CierraConexion.Cerrar(conexionGenerada);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}