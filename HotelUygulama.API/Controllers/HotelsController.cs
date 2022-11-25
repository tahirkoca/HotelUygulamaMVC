using HotelUygulama.BL.Abstract;
using HotelUygulama.BL.Concrete;
using HotelUygulama.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelUygulama.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;
        //public HotelsController()
        //{
        //    _hotelService = new HotelManager();
        //}
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        /// <summary>
        /// Tüm kayıtları getirmek için bu servis kullanılır.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var hotels = _hotelService.GetAllHotels();
            return Ok(hotels); //200 mesaj+data
        }

        /// <summary>
        /// İlgili hotel id sine göre otel bilgisi getirir.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound(); //404
        }

        /// <summary>
        /// Yeni hotel eklenir.
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                var createdHotel = _hotelService.CreateHotel(hotel);
                return CreatedAtAction("Get", new { id = createdHotel.Id }, createdHotel); //201+veri
            }
            return BadRequest(ModelState); //400+Validasyon hatası
        }

        /// <summary>
        /// Güncelleme işlemi yapılır.
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Hotel hotel)
        {
            if (_hotelService.GetHotelById(hotel.Id) != null)
            {
                return Ok(_hotelService.UpdateHotel(hotel)); //200 mesajı+veri
            }
            return NotFound();
        }

        /// <summary>
        /// Silme işlemi yapılır.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_hotelService.GetHotelById(id) != null)
            {
                var silmeIslemi = _hotelService.GetHotelById(id);
                _hotelService.DeeleteHotel(id);
                return Ok(silmeIslemi);
            }
            return NotFound();
        }
    }
}
