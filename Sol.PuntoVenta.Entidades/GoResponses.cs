namespace Sol.PuntoVenta.Entidades
{
    public class GoResponses<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError { get; set; } = false;
        public string? MensajeSucces { get; set; }
        public string? MensajeErrors { get; set; }
    }
}
