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

    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using DCHotelManagerCore.Lib.Models.Persistent;
    using DCHotelManagerCore.UINew.Controllers.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    #endregion

    /// <summary>
    /// The mvc hotel controller.
    /// </summary>
    [Route("client/[controller]")]
    public class MvcHotelController : Controller //IEntityUiController<Hotel>
    {
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
        public async Task<IActionResult> Create(Hotel hotel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var jsonHotel = JsonConvert.SerializeObject(hotel);

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(
                               "http://localhost:5010/api/Hotel/createOrUpdate",
                               new StringContent(jsonHotel, Encoding.UTF8, "application/json"));
            var newHotel = response.Content.ReadAsStringAsync().Result;
            return this.RedirectToAction("GetAll");
        }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="ViewResult"/>.
        /// </returns>
        [Route("CreateOrUpdateEntity")]
        public ViewResult CreateOrUpdateEntity()
        {
            return this.View(new Hotel());
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
        public async Task<IActionResult> Delete(HotelViewModel hotelModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var jsonHotel = JsonConvert.SerializeObject(hotelModel.Entities);

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(
                               "http://localhost:5010/api/Hotel/delete",
                               new StringContent(jsonHotel, Encoding.UTF8, "application/json"));
            var newHotel = response.Content.ReadAsStringAsync().Result;
            return this.RedirectToAction("GetAll");
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="ViewResult"/>.
        /// </returns>
        [Route("getall")]
        public ViewResult GetAll()
        {
            List<Hotel> hotels = null;
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:5010/api/Hotel/getall").Result;
            if (response.IsSuccessStatusCode)
            {
                var stateInfo = response.Content.ReadAsStringAsync().Result;
                hotels = JsonConvert.DeserializeObject<List<Hotel>>(stateInfo);
            }

            var viewmodel = new HotelViewModel();
            viewmodel.Entities = hotels;
            return this.View(viewmodel);
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
        public ViewResult GetEntity(int id)
        {
            // return this.View(this.hotelController.GetEntity(id));
            return null;
        }
    }
}