using System.Net;

namespace HospitalAppointment.Models.ReturnModels
{
    public class ReturnModel<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public T? Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public override string ToString()
        {
            return $"Message: {Message}, " +
                   $"Başarılı Mı: {Success}, " +
                   $"Veri: {Data}, " +
                   $"Statü Kodu: {StatusCode}";
        }
    }
}
