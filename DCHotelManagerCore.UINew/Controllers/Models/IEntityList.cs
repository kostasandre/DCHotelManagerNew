// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityList.cs" company="">
//   
// </copyright>
// <summary>
//   The EntityList interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.UINew.Controllers.Models
{
    #region

    using System.Collections.Generic;

    using DCHotelManagerCore.Lib.Models.Persistent.Interfaces;

    #endregion

    /// <summary>
    /// The EntityList interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IEntityList<T>
        where T : IEntity
    {
        /// <summary>
        /// Gets or sets the entities.
        /// </summary>
        List<T> Entities { get; set; }
    }
}