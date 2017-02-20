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

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    #endregion

    /// <summary>
    /// The mvc hotel controller.
    /// </summary>
    [Route("client/[controller]")]
    public class MvcHotelController : Controller
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
        public async Task<IActionResult> Create(Hotel hotel)
        {
            var jsonHotel = JsonConvert.SerializeObject(hotel);

            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(
                               "localhost:5005/api/createorupdate",
                               new StringContent(jsonHotel, Encoding.UTF8, "application/json"));
            var newHotel = await response.Content.ReadAsStringAsync();
            return null;
            
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
        public ViewResult CreateOrUpdateEntity(Hotel entity)
        {
            // return this.View(this.hotelController.CreateOrUpdateEntity(entity));
            return null;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ViewResult"/>.
        /// </returns>
        public ViewResult Delete(int id)
        {
            // this.hotelController.Delete(id);
            return this.View();
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
        public ViewResult GetEntity(int id)
        {
            // return this.View(this.hotelController.GetEntity(id));
            return null;
        }
    }
}