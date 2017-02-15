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

    using System.Collections.Generic;

    using DCHotelManagerCore.Lib.Models.Persistent;
    using DCHotelManagerCore.Lib.Repositories.Interfaces;

    using Microsoft.AspNetCore.Mvc;

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
        /// <param name="id">
        /// The id.
        /// </param>
        public override void Delete(int id)
        {
            this.roomRepository.Delete(id);
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public override IEnumerable<Room> GetAll()
        {
            var list = this.roomRepository.ReadAllList();
            return list;
        }
    }
}