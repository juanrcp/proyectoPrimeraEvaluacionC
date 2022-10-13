namespace proyectoFinalEvaluacionC.Models.Conexiones
{
    public class CierraConexion
    {
        public static void Cerrar(NpgsqlConnection conexion)
        {
            conexion.Close();
        }
    }
}
