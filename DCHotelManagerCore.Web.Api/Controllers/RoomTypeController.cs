// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomTypeController.cs" company="">
//   
// </copyright>
// <summary>
//   The room type controller.
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
    /// The room type controller.
    /// </summary>
    [Route("api/[controller]")]
    public class RoomTypeController : BaseController<RoomType>
    {
        /// <summary>
        /// The hotel repository.
        /// </summary>
        private readonly IEntityRepository<RoomType> roomTypeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomTypeController"/> class. 
        /// Initializes a new instance of the <see cref="CustomerController"/> class. 
        /// Initializes a new instance of the <see cref="RoomController"/> class.
        /// </summary>
        /// <param name="customerRepository">
        /// The customer Repository.
        /// </param>
        public RoomTypeController(IEntityRepository<RoomType> customerRepository)
        {
            this.roomTypeRepository = customerRepository;
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
        public override JsonResult CreateOrUpdateEntity([FromBody] RoomType entity)
        {
            if (entity.Id == 0)
            {
                entity = this.roomTypeRepository.Create(entity);
            }
            else
            {
                this.roomTypeRepository.Update(entity);
            }

            return new JsonResult(entity);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="roomTypesId">
        /// The room Types Id.
        /// </param>
        public override void Delete([FromBody]int[] roomTypesId)
        {
            this.roomTypeRepository.Delete(roomTypesId);
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public override JsonResult GetAll()
        {
            var roomTypeList = this.roomTypeRepository.ReadAllList();
            return new JsonResult(roomTypeList);
        }

        /// <summary>
        /// The get entity.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        [Route("getentity/{id}")]
        public override JsonResult GetEntity(int id)
        {
            var jsonRoomType = this.roomTypeRepository.ReadOne(id);
            return new JsonResult(jsonRoomType);
        }
    }
}