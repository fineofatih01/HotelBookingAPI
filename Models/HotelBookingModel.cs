namespace HotelBookingAPI.Models
{
    public class HotelBookingModel
    {
        public int Id { get; set; }
        public string Name { get; set; } // PropertyName yerine bu olabilir
        public DateTime BookingDate { get; set; }
        public int RoomNumber { get; set; }
    }
}
