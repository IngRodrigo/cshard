using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosLaser
{
    public class ConexionOra
    {
        /// <summary>
        /// Obtener el string de conexión de la BD del JDE a partir del archivo "unixconexion.ini".
        /// </summary>
        public static string ConnectionStringOra = "";

        public static void ObtenerConnectionString()
        {
            try
            {
                //string tipoBase = new cIniArray().IniGet(Principal.pathConexionOra, "Base_Datos", "TIPOBASE");
                //string servidor = new cIniArray().IniGet(Principal.pathConexionOra, "Base_Datos", "SERVER");
                //string usuarioOra = new cIniArray().IniGet(Principal.pathConexionOra, "Base_Datos", "USERID");
                //string password = new cIniArray().IniGet(Principal.pathConexionOra, "Base_Datos", "PASSWORD");
                ConnectionStringOra = "Data Source= Dev-db/dbjde;Persist Security Info=True;User ID=Dughelli;Password=dDUuVZK985cX";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Ejecutar una consulta SQL en la BD del JDE.
        /// </summary>
        /// <param name="SentenciaOra"></param>
        /// <returns></returns>
        public static DataSet EjecutarConsultaOra(string SentenciaOra)
        {
            var ds = new DataSet();
            try
            {
                ObtenerConnectionString();
                using (var conexionOra = new OracleConnection(ConnectionStringOra))
                {
                    conexionOra.Open();
                    var comando = new OracleCommand(SentenciaOra, conexionOra);
                    comando.CommandType = CommandType.Text;
                    var da = new OracleDataAdapter();
                    da.SelectCommand = comando;
                    da.Fill(ds);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        /// <summary>
        /// Ejecutar un comando Insert, Update o Delete en la BD del NAF.
        /// </summary>
        /// <param name="SentenciaOra"></param>
        public static void EjecutarComandoOra(string SentenciaOra)
        {
            try
            {
                ObtenerConnectionString();
                using (var conexionOra = new OracleConnection(ConnectionStringOra))
                {
                    conexionOra.Open();
                    var comando = new OracleCommand(SentenciaOra, conexionOra);
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Ejecutar un comando Insert, Update o Delete en la BD del NAF, dentro de una Transacción.
        /// </summary>
        /// <param name="SentenciaOra"></param>
        /// <param name="oraConn"></param>
        public static void EjecutarComandoOra(string SentenciaOra, OracleConnection oraConn)
        {
            try
            {
                var comando = new OracleCommand(SentenciaOra, oraConn);
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
