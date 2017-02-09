// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HotelController.cs" company="">
//   
// </copyright>
// <summary>
//   The hotel controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.Web.Api.Controllers
{
    #region

    using System;
    using System.Collections.Generic;

    using DCHotelManagerCore.Lib.Models.Persistent;
    using DCHotelManagerCore.Web.Api.Controllers.Interfaces;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    #endregion

    /// <summary>
    /// The hotel controller.
    /// </summary>
    [Route("api/[controller]")]
    public class HotelController : BaseController<Hotel>
    {
        #region Overrides of BaseController<Hotel>


        public override IEnumerable<Hotel> GetAll()
        {
            var hotel = new Hotel() { Id = 1, Name = "My Hotel" };
            var list = new List<Hotel> { hotel };
            return list;
        }

        public override void Delete(Hotel entity)
        {
            base.Delete(entity);
        }

        #endregion
    }
}