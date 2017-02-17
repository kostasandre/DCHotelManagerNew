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

    using System.Net.Http;
   
    using DCHotelManagerCore.Lib.Models.Persistent;
    using DCHotelManagerCore.UINew.Controllers.Interfaces;
    using DCHotelManagerCore.UINew.Helpers;
    using DCHotelManagerCore.Web.Api.Controllers.Interfaces;
   


    using Microsoft.AspNetCore.Mvc;

    #endregion

    /// <summary>
    /// The mvc hotel controller.
    /// </summary>
    [Route("client/[controller]")]
    public class MvcHotelController : Controller, IEntityUiController<Hotel>
    {
        /// <summary>
        /// The hotel controller.
        /// </summary>
        private readonly IEntityController<Hotel> hotelController;

        /// <summary>
        /// Initializes a new instance of the <see cref="MvcHotelController"/> class.
        /// </summary>
        /// <param name="hotelController">
        /// The hotel controller.
        /// </param>
        public MvcHotelController(IEntityController<Hotel> hotelController)
        {
            this.hotelController = hotelController;
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
            return this.View(this.hotelController.CreateOrUpdateEntity(entity));
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
            this.hotelController.Delete(id);
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
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:5010/" + "api/Hotel/getall").Result;
            if (response.IsSuccessStatusCode)
            {
                var stateInfo = response.Content.ReadAsStringAsync().Result;
            }

            return this.View(this.hotelController.GetAll());
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
            return this.View(this.hotelController.GetEntity(id));
        }
    }
}