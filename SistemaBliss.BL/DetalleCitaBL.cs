using SistemaBliss.DAL;
using SistemaBliss.EN;
using SistemaElParaisal.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.BL
{
    public class DetalleCitaBL
    {
        //public int Guardar(DetalleCita pDetalleCita, SqlTransaction pTransaccion)
        //{
        //    return DetalleCitaDAL.Guardar(pDetalleCita);
        //}

        //public int Modificar(DetalleCita pDetalleCita)
        //{
        //    return DetalleCitaDAL.Modificar(pDetalleCita);
        //}

        //public int ObtenerPorId(DetalleCita pIdDetalleCita)
        //{
        //    return DetalleCitaDAL.BuscarPorId(pIdDetalleCita);
        //}

        public static List<DetalleCita> Buscar(DetalleCita pDetalleCita)
        {
            List<DetalleCita> lista = new List<DetalleCita>();

            #region Proceso
            using (SqlCommand comando = ComunDB.ObtenerComando())
            {
                byte contador = 0;
                string whereSQL = " ";
                string consulta = @"SELECT TOP 500 dt.IdDetalleCita, dt.IdCita, dt.IdServicio, dt.TiempoEstimado, dt.PrecioUnitario, dt.SubTotal
                                    FROM DetalleCita dt ";

                // Validar filtros
                if (pDetalleCita.IdCita > 0)
                {
                    if (contador > 0)
                        whereSQL += " AND ";

                    contador += 1;
                    whereSQL += " dt.IdCita = @IdCita ";
                    comando.Parameters.AddWithValue("@IdCita", pDetalleCita.IdCita);
                }
                if (pDetalleCita.IdServicio > 0)
                {
                    if (contador > 0)
                        whereSQL += " AND ";

                    contador += 1;
                    whereSQL += " dt.IdCita = @IdCita ";
                    comando.Parameters.AddWithValue("@IdServicio", pDetalleCita.IdServicio);
                }
                // Agregar filtros
                if (whereSQL.Trim().Length > 0)
                {
                    whereSQL = " WHERE " + whereSQL;
                }
                comando.CommandText = consulta + whereSQL;

                SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
                while (reader.Read())
                {
                    DetalleCita obj = new DetalleCita();
                    // Orden de las columnas depende de la Consulta SELECT utilizada
                    obj.IdDetalleCita = reader.GetInt64(0); // Columna [0] cero
                    obj.IdCita = reader.GetInt64(1);  // Columna [1] uno
                    obj.IdServicio = reader.GetByte(2);  // Columna [2] dos
                    obj.TiempoEstimado = reader.GetTimeSpan(3);  // Columna [5] cinco
                    obj.Precio = reader.GetDecimal(4);  // Columna [5] cinco
                    obj.Subtotal = reader.GetDecimal(5);  // Columna [5] cinco
                    lista.Add(obj);
                }
                comando.Connection.Dispose();

            }
            #endregion

            return lista;
        }


    }
}
