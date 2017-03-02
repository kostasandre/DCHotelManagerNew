// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HotelController.cs" company="">
//   
// </copyright>
// <summary>
//   The hotel controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.Web.Api.Controllers
{
    #region

    using System.Collections.Generic;

    using DCHotelManagerCore.Lib.Models.Persistent;
    using DCHotelManagerCore.Lib.Repositories.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    #endregion

    /// <summary>
    /// The hotel controller.
    /// </summary>
    [Route("api/[controller]")]
    public class HotelController : BaseController<Hotel>
    {
        /// <summary>
        /// The hotel repository.
        /// </summary>
        private readonly IEntityRepository<Hotel> hotelRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelController"/> class.
        /// </summary>
        /// <param name="hotelRepository">
        /// The hotel repository.
        /// </param>
        public HotelController(IEntityRepository<Hotel> hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Hotel"/>.
        /// </returns>
        public override JsonResult CreateOrUpdateEntity([FromBody] Hotel entity)
        {
            if (entity.Id == 0)
            {
                entity = this.hotelRepository.Create(entity);
            }
            else
            {
                this.hotelRepository.Update(entity);
            }

            return new JsonResult(entity);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public override void Delete([FromBody] int[] hotelsId)
        {
            this.hotelRepository.Delete(hotelsId);
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public override JsonResult GetAll()
        {
          
            var jsonHotelList = this.hotelRepository.ReadAllList();
            return new JsonResult(jsonHotelList);
        }

        /// <summary>
        /// The get entity.
        /// </summary>
        /// <param name="id">
        ///     The id.
        /// </param>
        /// <returns>
        /// The <see cref="Hotel"/>.
        /// </returns>
        [Route("getentity/{id}")]
        public override JsonResult GetEntity(int id)
        {
            var jsonHotel = this.hotelRepository.ReadOne(id);
            return new JsonResult(jsonHotel);
        }
    }
}