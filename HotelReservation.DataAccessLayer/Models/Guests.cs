using System.Collections.Generic;

namespace HotelReservation.DataAccessLayer.Models
{
    public class Guests
    {
        public int GuestId { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

        public virtual ICollection<Reservations> Reservations { get; private set; }

        public Guests()
        {
            Reservations = new HashSet<Reservations>();
        }

        public Guests(string name, string surname, string email, string phone)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
        }
    }
}
