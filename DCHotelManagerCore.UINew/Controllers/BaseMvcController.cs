// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseMvcController.cs" company="">
//   
// </copyright>
// <summary>
//   The base mvc controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.UINew.Controllers
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DCHotelManagerCore.Lib.Models.Persistent.Interfaces;
    using DCHotelManagerCore.UINew.Controllers.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    #endregion

    /// <summary>
    /// The base mvc controller.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class BaseMvcController<T> : Controller, IEntityUiController<T>
        where T : IEntity
    {
        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="ViewResult"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public ViewResult CreateOrUpdateEntity()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entities">
        /// The entities.
        /// </param>
        /// <returns>
        /// The <see cref="ViewResult"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Task<IActionResult> Delete(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="ViewResult"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        [Route("getall")]
        public ViewResult GetAll()
        {
            throw new NotImplementedException();
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
        /// <exception cref="NotImplementedException">
        /// </exception>
        public ViewResult GetEntity(int id)
        {
            throw new NotImplementedException();
        }
    }
}