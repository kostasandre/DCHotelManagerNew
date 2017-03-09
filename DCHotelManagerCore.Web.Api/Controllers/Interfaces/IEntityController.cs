// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityController.cs" company="">
//   
// </copyright>
// <summary>
//   The EntityController interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.Web.Api.Controllers.Interfaces
{
    #region

    using System.Collections.Generic;

    using DCHotelManagerCore.Lib.DbContext;
    using DCHotelManagerCore.Lib.Models.Persistent.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    #endregion

    /// <summary>
    /// The EntityController interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IEntityController<T>
        where T : IEntity
    {
        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        JsonResult CreateOrUpdateEntity(T entity);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entities">
        /// </param>
        void Delete(int[] entities);

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        JsonResult GetAll();

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        JsonResult GetEntity(int id);

        /// <summary>
        /// The read all query.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        JsonResult ReadAllQuery(int id);
    }
}