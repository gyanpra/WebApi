using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string ClientName { get; set; }
        public string Location { get; set; }

    }

    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAll();
        Reservation Get(int id);
        Reservation Add(Reservation item);
        void Remove(int id);
        bool Update(Reservation item);
    }

    public class ReservationRepository : IReservationRepository
    {
        private List<Reservation> data = new List<Reservation>
        {
 new Reservation {ReservationId = 1, ClientName = "Adam",Location = "London"},
 new Reservation {ReservationId = 2,ClientName = "Tim",Location = "New York"},
new Reservation {ReservationId = 3, ClientName = "Jacqui",Location = "Paris"},
};
        private static ReservationRepository repo = new ReservationRepository();
        public static IReservationRepository getRepository()
        { return repo; }
        public IEnumerable<Reservation> GetAll()
        {
            return data;
        }


        public Reservation Get(int id)
        {
            var matches = data.Where(r => r.ReservationId == id);
            return matches.Count() > 0 ? matches.First() : null;
        }
        public Reservation Add(Reservation item)
        {
            item.ReservationId = data.Count + 1;
            data.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            Reservation item = Get(id);
            if (item != null)
            {
                data.Remove(item);
            }
        }


        public bool Update(Reservation item)
        {
            Reservation storedItem = Get(item.ReservationId);
            if (storedItem != null)
            {
                storedItem.ClientName = item.ClientName;
                storedItem.Location = item.Location;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}