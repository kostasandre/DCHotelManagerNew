// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseController.cs" company="">
//   
// </copyright>
// <summary>
//   The base controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.Web.Api.Controllers
{
    #region

    using System;
    using System.Collections.Generic;

    using DCHotelManagerCore.Lib.DbContext;
    using DCHotelManagerCore.Lib.Models.Persistent.Interfaces;
    using DCHotelManagerCore.Web.Api.Controllers.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    #endregion

    /// <summary>
    /// The base controller.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class BaseController<T> : IEntityController<T>
        where T : IEntity
    {
        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        [Route("createOrUpdate")]
        [HttpPost]
        public virtual JsonResult CreateOrUpdateEntity(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entities">
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        [Route("delete")]
        [HttpPost]
        public virtual void Delete(int[] entities)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        [HttpGet]
        [Route("getall")]
        public virtual JsonResult GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get entity.
        /// </summary>
        /// <param name="id">
        ///     The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        [HttpGet]
        [Route("getentity/{id}")]
        public virtual JsonResult GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        #region Implementation of IEntityController<T>

        [HttpGet]
        [Route("readallquery/{id}")]
        public virtual JsonResult ReadAllQuery(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}