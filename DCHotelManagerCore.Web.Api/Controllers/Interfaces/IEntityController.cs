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
    using System.Net.Http;

    using DCHotelManagerCore.Lib.Models.Persistent;
    using DCHotelManagerCore.Lib.Models.Persistent.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    #endregion

    /// <summary>
    /// The EntityController interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    interface IEntityController<T>
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
        /// <param name="id">
        /// The id.
        /// </param>
        void Delete(int id);

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        T GetEntity(int id);
    }
}