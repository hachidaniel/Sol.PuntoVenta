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

        public async Task<GoResponses<List<E_PuntoVenta>>> GetListPuntoVenta(Generico generico) 
        {
            return await _puntoVentaData.GetListPuntoVenta(generico);
        }

        public async Task<GoResponses<E_PuntoVenta>> InsertUpdatePuntoVenta(E_PuntoVenta puntoVenta) 
        {
            return await _puntoVentaData.InsertUpdatePuntoVenta(puntoVenta);
        }


        public async Task<GoResponses<bool>> EliminarPuntoVenta(Generico puntoVenta) 
        {
            return await _puntoVentaData.EliminarPuntoVenta(puntoVenta);
        }
    }
}
