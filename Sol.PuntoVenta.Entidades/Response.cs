namespace Sol.PuntoVenta.Entidades
{
    public class Response<T>
    {
        public T? Objeto { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError { get; set; } = false;
        public string? MensajeSucces { get; set; }
        public string? MensajeErrors { get; set; }
    }
}
