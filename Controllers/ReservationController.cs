using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ReservationController : ApiController
    {
        IReservationRepository mydata = ReservationRepository.getRepository();
        public IEnumerable<Reservation> GetAllReservations()
        {
            return mydata.GetAll();
        }
        public Reservation GetReservation(int id)
        {
            return mydata.Get(id);
        }
        [HttpPost]
        public Reservation CreateReservation(Reservation item)
        {
            return mydata.Add(item);
        }
        [HttpPut]
        public bool UpdateReservation(Reservation item)
        {
            return mydata.Update(item);
        }
        [HttpDelete]
        public void DeleteReservation(int id)
        {
            mydata.Remove(id);
        }
    }
}