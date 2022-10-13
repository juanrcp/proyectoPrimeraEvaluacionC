using Npgsql;

namespace proyectoFinalEvaluacionC.Models.DTOs.ADTO
{
    public class ReaderaListDTO
    {
        public static List<ProductoDTO> ReaderAListAlumnoDTO(NpgsqlDataReader resultadoConsulta)
        {
            List<ProductoDTO> listProductos = new List<ProductoDTO>();
            while (resultadoConsulta.Read())
            {
                listProductos.Add(new ProductoDTO(
                    (int)Int64.Parse(resultadoConsulta[0].ToString()),
                    resultadoConsulta[1].ToString(),
                    resultadoConsulta[2].ToString(),
                    resultadoConsulta[3].ToString(),
                    resultadoConsulta[4].ToString(),
                    resultadoConsulta[5].ToString(),
                    resultadoConsulta[6].ToString(),
                    resultadoConsulta[7].ToString(),
                    resultadoConsulta[8].ToString(),
                    resultadoConsulta[9].ToString()
                    )
                    );

            }
            return listProductos;
        }
    }
}
