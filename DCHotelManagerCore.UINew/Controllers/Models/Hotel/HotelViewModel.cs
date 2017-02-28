// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HotelViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The hotel view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.UINew.Controllers.Models.Hotel
{
    #region

    using System.Collections.Generic;

    using DCHotelManagerCore.Lib.Models.Persistent;

    #endregion

    /// <summary>
    /// The hotel view model.
    /// </summary>
    public class HotelViewModel : IEntityList<Hotel>
    {
        public HotelViewModel()
        {
            this.Entities = new List<Hotel>();
        }

        /// <summary>
        /// Gets or sets the entities.
        /// </summary>
        public List<Hotel> Entities { get; set; }
    }
}