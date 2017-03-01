// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityUiController.cs" company="">
//   
// </copyright>
// <summary>
//   The EntityUiController interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.UINew.Controllers.Interfaces
{
    #region

    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DCHotelManagerCore.Lib.Models.Persistent;
    using DCHotelManagerCore.Lib.Models.Persistent.Interfaces;
    using DCHotelManagerCore.UINew.Controllers.Models;
    using DCHotelManagerCore.UINew.Controllers.Models.Hotel;

    using Microsoft.AspNetCore.Mvc;

    #endregion

    /// <summary>
    /// The EntityUiController interface.
    /// </summary>
    /// <typeparam name="T">
    /// the IEntityUiController.
    /// </typeparam>
    public interface IEntityUiController<T>
        where T : IEntity
    {
        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="hotel">
        /// The hotel.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        Task<IActionResult> CreateOrUpdateEntity(T entity);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entities">
        /// The entities.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        Task<IActionResult> Delete(IList<T> entities);

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        ViewResult GetAll();

        /// <summary>
        /// The get entity.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        ViewResult GetEntity(int id);
    }
}