using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Sol.PuntoVenta.Data.Connections;
using Sol.PuntoVenta.Entidades;
using System.Data;

namespace Sol.PuntoVenta.Data.Datos
{
    public class PuntoVentaData
    {
        private readonly ConnectionStrings connection;
        public PuntoVentaData(IOptions<ConnectionStrings> options)
        {
            connection = options.Value;
        }

        /// <summary>
        /// Metodo que muestra un listado
        /// </summary>
        /// <param name="generico"></param>
        /// <returns></returns>
        public async Task<GoResponses<List<E_PuntoVenta>>> GetListPuntoVenta(Generico generico)
        {
            GoResponses<List<E_PuntoVenta>> listPuntoVetna = new GoResponses<List<E_PuntoVenta>>();
            List<E_PuntoVenta> venta = new List<E_PuntoVenta>();
            try
            {
                using (var conexion = new SqlConnection(connection.CadenaSQL))
                {
                    await conexion.OpenAsync();
                    SqlCommand cmd = new SqlCommand("[dbo].[SPC_LISTADO_PUNTO_VENTA]", conexion);
                    cmd.Parameters.AddWithValue("@pi_Texto", generico.Text);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            venta.Add(new E_PuntoVenta()
                            {
                                Id_PuntoVenta = Convert.ToInt16(reader["Id_PuntoVenta"]),
                                Descripcion_PuntoVenta = reader["Descripcion_PuntoVenta"].ToString(),
                                Estatus = Convert.ToBoolean(reader["Estatus"])

                            });
                          
                        }
                    }
                    listPuntoVetna.Data = venta;
                }
                listPuntoVetna.MensajeSucces = "OK";
                listPuntoVetna.IsSuccess = true;

            }
            catch (Exception ex)
            {
                listPuntoVetna.Data = null;
                listPuntoVetna.MensajeSucces = "";
                listPuntoVetna.IsSuccess = false;
                listPuntoVetna.MensajeSucces = ex.ToString();
                listPuntoVetna.IsError = true;
                //throw new Exception(ex.ToString());
            }

            return listPuntoVetna;
        }

        /// <summary>
        /// Inserta y actualiza un punto de venta
        /// </summary>
        /// <param name="puntoVenta"></param>
        /// <returns></returns>
        public async Task<GoResponses<E_PuntoVenta>> InsertUpdatePuntoVenta(E_PuntoVenta puntoVenta) 
        {
            GoResponses<E_PuntoVenta> RpuntoVenta = new GoResponses<E_PuntoVenta>();
            E_PuntoVenta e_Punto = new E_PuntoVenta();
            try
            {
                using (var conexion = new SqlConnection(connection.CadenaSQL))
                {
                    await conexion.OpenAsync();
                    SqlCommand cmd = new SqlCommand("[dbo].[SPI_PUNTO_VENTA]", conexion);
                    cmd.Parameters.AddWithValue("@pi_Id_PuntoVenta", puntoVenta.Id_PuntoVenta);
                    cmd.Parameters.AddWithValue("@pi_Descripcion_PuntoVenta", puntoVenta.Descripcion_PuntoVenta);
                    cmd.Parameters.AddWithValue("@pi_Estatus", puntoVenta.Estatus);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                             e_Punto = new E_PuntoVenta()
                            {
                                Id_PuntoVenta = Convert.ToInt16(reader["Id_PuntoVenta"]),
                                Descripcion_PuntoVenta = reader["Descripcion_PuntoVenta"].ToString(),
                                Estatus = Convert.ToBoolean(reader["Estatus"])

                            };
                           

                        }
                    }
                }
                RpuntoVenta.MensajeSucces = "OK";
                RpuntoVenta.IsSuccess = true;
                RpuntoVenta.Data = e_Punto;

            }
            catch (Exception ex)
            {
                RpuntoVenta.Data = null;
                RpuntoVenta.MensajeSucces = "";
                RpuntoVenta.IsSuccess = false;
                RpuntoVenta.MensajeSucces = ex.ToString();
                RpuntoVenta.IsError = true;
                //throw new Exception(ex.ToString());
            }

            return RpuntoVenta;

        }


        /// <summary>
        /// Elimina un punto de venta con una eliminacion logico
        /// </summary>
        /// <param name="puntoVenta"></param>
        /// <returns></returns>
        public async Task<GoResponses<bool>> EliminarPuntoVenta(Generico puntoVenta) 
        {
            GoResponses<bool> listPuntoVetna = new GoResponses<bool>();
            try
            {
                using (var conexion = new SqlConnection(connection.CadenaSQL))
                {
                    await conexion.OpenAsync();
                    SqlCommand cmd = new SqlCommand("[dbo].[SPE_PUNTO_VENTA]", conexion);
                    cmd.Parameters.AddWithValue("@pi_Id_PuntoVenta", puntoVenta.Id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            listPuntoVetna.Data = Convert.ToBoolean(reader["RESULTADO"]);
                        }
                    }
                }
                listPuntoVetna.MensajeSucces = "OK";
                listPuntoVetna.IsSuccess = true;

            }
            catch (Exception ex)
            {
                listPuntoVetna.Data = false;
                listPuntoVetna.MensajeSucces = "";
                listPuntoVetna.IsSuccess = false;
                listPuntoVetna.MensajeSucces = ex.ToString();
                listPuntoVetna.IsError = true;
                //throw new Exception(ex.ToString());
            }

            return listPuntoVetna;

        }
    }
}
