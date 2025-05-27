using Sol.PuntoVenta.Data.Datos;
using Sol.PuntoVenta.Entidades;

namespace Sol.PuntoVenta.Negocio.Negocios
{
    public class PuntoVentaN
    {
        private readonly PuntoVentaData _puntoVentaData;
        public PuntoVentaN(PuntoVentaData puntoVentaData) 
        {
         _puntoVentaData = puntoVentaData;
        }

        public async Task<Response<List<E_PuntoVenta>>> GetListPuntoVenta(Generico generico) 
        {
            return await _puntoVentaData.GetListPuntoVenta(generico);
        }

        public async Task<Response<E_PuntoVenta>> InsertPuntoVenta(E_PuntoVenta puntoVenta) 
        {
            return await _puntoVentaData.InsertPuntoVenta(puntoVenta);
        }


        public async Task<Response<bool>> EliminarPuntoVenta(Generico puntoVenta) 
        {
            return await _puntoVentaData.EliminarPuntoVenta(puntoVenta);
        }
    }
}
