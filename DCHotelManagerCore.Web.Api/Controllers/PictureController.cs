using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCHotelManagerCore.Web.Api.Controllers
{
    using DCHotelManagerCore.Lib.Models.Persistent;
    using DCHotelManagerCore.Lib.Repositories.Interfaces;

    using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    public class PictureController:BaseController<Picture>
    {
        /// <summary>
        /// The hotel repository.
        /// </summary>
        private readonly IEntityRepository<Picture> pictureRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomController"/> class.
        /// </summary>
        /// <param name="roomRepository">
        /// The room Repository.
        /// </param>
        public PictureController(IEntityRepository<Picture> pictureRepository)
        {
            this.pictureRepository = pictureRepository;
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
        public override JsonResult CreateOrUpdateEntity([FromBody] Picture entity)
        {
            if (entity.Id == 0)
            {
                entity = this.pictureRepository.Create(entity);
            }
            else
            {
                this.pictureRepository.Update(entity);
            }

            return new JsonResult(entity);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="roomsId">
        /// The rooms Id.
        /// </param>
        public override void Delete([FromBody] int[] picturesId)
        {
            this.pictureRepository.Delete(picturesId);
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public override JsonResult GetAll()
        {
            var pictureList = this.pictureRepository.ReadAllList();
            return new JsonResult(pictureList);
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
            var jsonPicture = this.pictureRepository.ReadOne(id);
            return new JsonResult(jsonPicture);
        }
    }
}
