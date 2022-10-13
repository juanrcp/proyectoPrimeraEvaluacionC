using Microsoft.AspNetCore.Mvc;
using proyectoFinalEvaluacionC.Models;
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

        public IActionResult Index(ConexionPostgreSQL conexionPostgreSQL)
        {
            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Entra en Index");

            //CONSTANTES
            const string HOST = VariablesConexionPostgreSQL.HOST;
            const string PORT = VariablesConexionPostgreSQL.PORT;
            const string USER = VariablesConexionPostgreSQL.USER;
            const string PASS = VariablesConexionPostgreSQL.PASS;
            const string DB = VariablesConexionPostgreSQL.DB;

            //Se genera una conexión a PostgreSQL y validamos que esté abierta fuera del método
            var estadoGenerada = "";
            NpgsqlConnection conexionGenerada = new NpgsqlConnection();

            List<AlumnoDTO> listAlumnoDTO = new List<AlumnoDTO>();
            List<AsignaturaAlumnoDTOs> listAsignaturaDTO = new List<AsignaturaAlumnoDTOs>();

            //NpgsqlCommand consulta = new NpgsqlCommand();
            conexionGenerada = conexionPostgreSQL.GeneraConexion(HOST, PORT, DB, USER, PASS);
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Estado conexión generada: " + estadoGenerada);

            //Se realiza la consulta y se guarda una lista de alumnosDTO
            listAlumnoDTO = ConsultasPostgreSQL.ConsultaSelectPostgreSQL(conexionGenerada);
            int cont = listAlumnoDTO.Count();
            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Lista compuesta por: " + cont + " alumnos");

            listAsignaturaDTO = ConsultasPostgreSQL.ConsultaSelectPostgreSQL2(conexionGenerada);

            foreach (AsignaturaAlumnoDTOs s in listAsignaturaDTO)
            {
                System.Console.WriteLine("Datos alumno: " + s.nombre + " " + s.nombreAsignatura);

            }

            ConsultasPostgreSQL.InsercionAlumnoPostgreSQL(conexionGenerada);

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