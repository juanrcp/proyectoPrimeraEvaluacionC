﻿using Npgsql;
using proyectoFinalEvaluacionC.Models.Conexiones;
using proyectoFinalEvaluacionC.Models.DTOs;

namespace proyectoFinalEvaluacionC.Models.Consultas
{
    public class ConsultaBaseDeDatos
    {
       public static List<ProductoDTO> ConsultaBBDD(NpgsqlConnection conexionGenerada)
       {
            List<ProductoDTO> listProductos = new List<ProductoDTO>();

            try
            {
                //Se define y ejecuta la consulta Select
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"dlk_operacional_productos\".\"opr_cat_productos\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                //Paso de DataReader a lista de alumnoDTO
                listProductos = DTOs.ADTO.ReaderaListDTO.ReaderAListAlumnoDTO(resultadoConsulta);

                System.Console.WriteLine("[INFORMACIÓN-ConsultasPostgreSQL-ConsultaSelectPostgreSQL] Cierre conexión y conjunto de datos");
                //conexionGenerada.Close();
                resultadoConsulta.Close();

                }
                catch (Exception e)
                {
                    System.Console.WriteLine("[ERROR-HomeController-Index] Error al ejecutar consulta: " + e);
                    //conexionGenerada.Close();
                    CierraConexion.Cerrar(conexionGenerada);

            }
            return listProductos;            
       }

        public static List<ProductoDTO> InsertarBBDD(NpgsqlConnection conexionGenerada)
        {
            List<ProductoDTO> listProductos = new List<ProductoDTO>();

            try
            {
                //Se define y ejecuta la consulta Select
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"dlk_operacional_productos\".\"opr_cat_productos\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                //Paso de DataReader a lista de alumnoDTO
                listProductos = DTOs.ADTO.ReaderaListDTO.ReaderAListAlumnoDTO(resultadoConsulta);

                System.Console.WriteLine("[INFORMACIÓN-ConsultasPostgreSQL-ConsultaSelectPostgreSQL] Cierre conexión y conjunto de datos");
                //conexionGenerada.Close();
                resultadoConsulta.Close();

            }
            catch (Exception e)
            {
                System.Console.WriteLine("[ERROR-HomeController-Index] Error al ejecutar consulta: " + e);
                //conexionGenerada.Close();
                CierraConexion.Cerrar(conexionGenerada);

            }
            return listProductos;
        }
    }
}
