// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PictureController.cs" company="">
//   
// </copyright>
// <summary>
//   The picture controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.Web.Api.Controllers
{
    #region

    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using DCHotelManagerCore.Lib.DbContext;
    using DCHotelManagerCore.Lib.Models.Persistent;
    using DCHotelManagerCore.Lib.Repositories;
    using DCHotelManagerCore.Lib.Repositories.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    #endregion

    /// <summary>
    /// The picture controller.
    /// </summary>
    [Route("api/[controller]")]
    public class PictureController : BaseController<Picture>
    {
        /// <summary>
        /// The hotel repository.
        /// </summary>
        private readonly IEntityRepository<Picture> pictureRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PictureController"/> class. 
        /// Initializes a new instance of the <see cref="RoomController"/> class.
        /// </summary>
        /// <param name="pictureRepository">
        /// The picture Repository.
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
        /// The create picture.
        /// </summary>
        /// <param name="photo">
        /// The photo.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        [HttpPost]
        [Route("create")]
        public int CreatePicture([FromBody] Picture picture)
        {
            this.pictureRepository.Create(picture);
            return picture.Id;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="picturesId">
        /// The pictures Id.
        /// </param>
        public override void Delete([FromBody] int[] picturesId)
        {
            this.pictureRepository.Delete(picturesId);
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
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
        /// The id.
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

        /// <summary>
        /// The read all query.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public override JsonResult ReadAllQuery(int id)
        {
            var context = new DataBaseContext();
            var jsonPicture = this.pictureRepository.ReadAllQuery(context).Where(x => x.RoomId == id).ToList();
            return jsonPicture.Count != 0 ? new JsonResult(jsonPicture[0]) : new JsonResult(null);
        }


        [HttpGet]
        [Route("readallqueryhotel/{id}")]
        public JsonResult ReadAllQueryHotel(int id)
        {
            var context = new DataBaseContext();
            var jsonPicture = this.pictureRepository.ReadAllQuery(context).Where(x => x.HotelId == id).ToList();
            return jsonPicture.Count != 0 ? new JsonResult(jsonPicture[0]) : new JsonResult(null);
        }

        /// <summary>
        /// The set picture.
        /// </summary>
        /// <param name="pid">
        /// The pid.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="eid">
        /// The eid.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        [Route("set/{pid}/{type}/{eid}")]
        public ActionResult SetPicture(int pid, string type, int eid)
        {
            var repository = this.pictureRepository as PictureRepository;

            if (repository == null)
            {
                return new BadRequestResult();
            }

            try
            {
                repository.SetPicture(pid, type, eid);

                return new OkResult();
            }
            catch
            {
                return new BadRequestResult();
            }
        }

        /// <summary>
        /// The unset picture.
        /// </summary>
        /// <param name="pid">
        /// The pid.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        [Route("unset/{pid}")]
        public ActionResult UnsetPicture(int pid)
        {
            var repository = this.pictureRepository as PictureRepository;

            if (repository == null)
            {
                return new BadRequestResult();
            }

            try
            {
                repository.UnsetPicture(pid);

                return new OkResult();
            }
            catch
            {
                return new BadRequestResult();
            }
        }
    }
}