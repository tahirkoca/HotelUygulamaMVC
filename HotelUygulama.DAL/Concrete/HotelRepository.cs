using HotelUygulama.DAL.Abstract;
using HotelUygulama.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUygulama.DAL.Concrete
{
   public class HotelRepository : IHotelRepository
    {

        //HotelDbContext db = new HotelDbContext();


        private HotelDbContext db;

        public HotelRepository(HotelDbContext db)
        {
            this.db = db;

        }


        public Hotel CreateHotel(Hotel hotel)
        {
            db.hotels.Add(hotel);
            db.SaveChanges();
            return hotel;
        }

        public void DeeleteHotel(int id)
        {
            db.hotels.Remove(GetHotelById(id));
            db.SaveChanges();
        }

        public List<Hotel> GetAllHotels()
        {
            return db.hotels.ToList();
        }




        public Hotel GetHotelById(int id)
        {
            return db.hotels.Find(id);
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            db.Entry(GetHotelById(hotel.Id)).CurrentValues.SetValues(hotel);
            db.SaveChanges();
            return hotel;
        }
    }
}
