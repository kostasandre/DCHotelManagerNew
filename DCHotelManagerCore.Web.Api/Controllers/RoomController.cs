// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomController.cs" company="">
//   
// </copyright>
// <summary>
//   The room controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.Web.Api.Controllers
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DCHotelManagerCore.Lib.DbContext;
    using DCHotelManagerCore.Lib.Models.Persistent;
    using DCHotelManagerCore.Lib.Repositories.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    #endregion

    /// <summary>
    /// The room controller.
    /// </summary>
    [Route("api/[controller]")]
    public class RoomController : BaseController<Room>
    {
        /// <summary>
        /// The hotel repository.
        /// </summary>
        private readonly IEntityRepository<Room> roomRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomController"/> class.
        /// </summary>
        /// <param name="roomRepository">
        /// The room Repository.
        /// </param>
        public RoomController(IEntityRepository<Room> roomRepository)
        {
            this.roomRepository = roomRepository;
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
        public override JsonResult CreateOrUpdateEntity([FromBody] Room entity)
        {
            if (entity.Id == 0)
            {
                entity = this.roomRepository.Create(entity);
            }
            else
            {
                this.roomRepository.Update(entity);
            }

            return new JsonResult(entity);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="roomsId">
        /// The rooms Id.
        /// </param>
        public override void Delete([FromBody] int[] roomsId)
        {
            this.roomRepository.Delete(roomsId);
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public override JsonResult GetAll()
        {
            var roomList = this.roomRepository.ReadAllList();
            return new JsonResult(roomList);
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
            var jsonRoom = this.roomRepository.ReadOne(id);
            return new JsonResult(jsonRoom);
        }
    }
}