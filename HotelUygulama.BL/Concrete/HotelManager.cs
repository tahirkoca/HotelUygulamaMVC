using HotelUygulama.BL.Abstract;
using HotelUygulama.DAL.Abstract;
using HotelUygulama.DAL.Concrete;
using HotelUygulama.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUygulama.BL.Concrete
{
    public class HotelManager : IHotelService
    {
        private IHotelRepository _hotelRepository;

        //public HotelManager()
        //{
        //    _hotelRepository = new HotelRepository();
        //}

        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;

        }




        public Hotel CreateHotel(Hotel hotel)
        {
            return _hotelRepository.CreateHotel(hotel);
        }

        public void DeeleteHotel(int id)
        {
            _hotelRepository.DeeleteHotel(id);
        }

        public List<Hotel> GetAllHotels()
        {
            return _hotelRepository.GetAllHotels();
        }

        public Hotel GetHotelById(int id)
        {
            if(id>0)
            {
                return _hotelRepository.GetHotelById(id);
            }

            throw new Exception("id 0 dan büyük değil");
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            return _hotelRepository.UpdateHotel(hotel);
        }
    }
}
