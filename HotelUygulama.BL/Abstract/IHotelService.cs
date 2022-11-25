using HotelUygulama.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUygulama.BL.Abstract
{
    public interface IHotelService
    {

        List<Hotel> GetAllHotels();

        Hotel GetHotelById(int id);
        Hotel CreateHotel(Hotel hotel);
        Hotel UpdateHotel(Hotel hotel);
        void DeeleteHotel(int id);
    }
}
