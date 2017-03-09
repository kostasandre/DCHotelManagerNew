// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MvcHotelController.cs" company="">
//   
// </copyright>
// <summary>
//   The mvc hotel controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.UINew.Controllers.Models.Hotel
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;

    using DCHotelManagerCore.Lib.Models.Persistent;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Internal;
    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    #endregion

    /// <summary>
    /// The mvc hotel controller.
    /// </summary>
    [Route("client/[controller]")]
    public class MvcHotelController: BaseMvcController<Hotel>
    {
        // IEntityUiController<Hotel>

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="hotel">
        /// The hotel.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(Hotel hotel, IFormFile picture)
        {
            var databasePicture = new Picture();
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(
                               "http://localhost:5010/api/Hotel/createOrUpdate",
                               new StringContent(JsonConvert.SerializeObject(hotel), Encoding.UTF8, "application/json"));

            var hotelId = JsonConvert.DeserializeObject<Hotel>(response.Content.ReadAsStringAsync().Result).Id;
            if (picture != null && hotelId != 0)
            {
                response = await httpClient.GetAsync($"http://localhost:5010/api/Picture/readallqueryhotel/{hotelId}");
                var existingPicture = JsonConvert.DeserializeObject<Picture>(
                    response.Content.ReadAsStringAsync().Result);

                if (existingPicture != null)
                {
                    response = await httpClient.GetAsync(
                                   $"http://localhost:5010/api/Picture/unset/{existingPicture.Id}");
                }

                using (var stream = new MemoryStream())
                {
                    await picture.CopyToAsync(stream);
                    databasePicture.HotelId = hotelId;
                    databasePicture.ByteArray = stream.ToArray();
                    var jsonPictureToUpload = JsonConvert.SerializeObject(databasePicture);

                    response = await httpClient.PostAsync(
                                   "http://localhost:5010/api/Picture/create",
                                   new StringContent(jsonPictureToUpload, Encoding.UTF8, "application/json"));
                }
            }

            return this.RedirectToAction("GetAll");
        }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="hotel">
        /// The hotel.
        /// </param>
        /// <returns>
        /// The <see cref="ViewResult"/>.
        /// </returns>
        [Route("CreateOrUpdateEntity")]
        public override async Task<IActionResult> CreateOrUpdateEntity(Hotel hotel)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync($"http://localhost:5010/api/Hotel/getentity/{hotel.Id}").Result;
            if (response.IsSuccessStatusCode && hotel.Id != 0)
            {
                var stateInfo = response.Content.ReadAsStringAsync().Result;
                var localHotel = JsonConvert.DeserializeObject<Hotel>(stateInfo);

                response = httpClient.GetAsync($"http://localhost:5010/api/Room/getall").Result;
                if (response.IsSuccessStatusCode)
                {
                    stateInfo = response.Content.ReadAsStringAsync().Result;
                    localHotel.AllRooms = JsonConvert.DeserializeObject<List<Room>>(stateInfo);
                }

                response = httpClient.GetAsync($"http://localhost:5010/api/Picture/getall").Result;
                if (response.IsSuccessStatusCode)
                {
                    stateInfo = response.Content.ReadAsStringAsync().Result;
                    var pictures = JsonConvert.DeserializeObject<List<Picture>>(stateInfo);


                    foreach (var picture in pictures.Where(x => x.HotelId == hotel.Id))
                    {
                        localHotel.Pictures.Add(picture);
                    }
                    return this.View(localHotel);
                }
            }

            return this.View();
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="hotels">
        /// The hotels.
        /// </param>
        /// <returns>
        /// The <see cref="ViewResult"/>.
        /// </returns>
        [Route("delete")]
        [HttpPost]
        public override async Task<IActionResult> Delete(IList<Hotel> hotels)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var hotelList = hotels.Where(hotel => hotel.IsChecked).Select(motel => motel.Id).ToList();

            var jsonHotel = JsonConvert.SerializeObject(hotelList);

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(
                               "http://localhost:5010/api/Hotel/delete",
                               new StringContent(jsonHotel, Encoding.UTF8, "application/json"));

            return this.RedirectToAction("GetAll");
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="ti8eleiTo">
        /// The ti 8 elei to.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Task<IActionResult> Delete(IEntityList<Hotel> ti8eleiTo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="ViewResult"/>.
        /// </returns>
        [Route("getall")]
        public override ViewResult GetAll()
        {
            List<Hotel> hotels = null;
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:5010/api/Hotel/getall").Result;
            if (response.IsSuccessStatusCode)
            {
                var stateInfo = response.Content.ReadAsStringAsync().Result;
                hotels = JsonConvert.DeserializeObject<List<Hotel>>(stateInfo);

                response = httpClient.GetAsync($"http://localhost:5010/api/Picture/getall").Result;
                if (response.IsSuccessStatusCode)
                {
                    stateInfo = response.Content.ReadAsStringAsync().Result;
                    var pictures = JsonConvert.DeserializeObject<List<Picture>>(stateInfo);

                    foreach (var hotel in hotels)
                    {
                        foreach (var picture in pictures.Where(x=>x.HotelId == hotel.Id))
                        {
                           hotel.Pictures.Add(picture);
                        }
                    }
                }
            }



            return this.View(hotels);
        }

        /// <summary>
        /// The get entity.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ViewResult"/>.
        /// </returns>
        [Route("getentity/{id}")]
        public override ViewResult GetEntity(int id)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync($"http://localhost:5010/api/Hotel/getentity?id={id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var stateInfo = response.Content.ReadAsStringAsync().Result;
                var localHotel = JsonConvert.DeserializeObject<Hotel>(stateInfo);
                return this.View(localHotel);
            }

            return this.View();
        }
    }
}