using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DCHotelManagerCore.UINew.Controllers
{
    using DCHotelManagerCore.Lib.Models.Persistent;
    using DCHotelManagerCore.Lib.Repositories.Interfaces;
    using DCHotelManagerCore.UINew.Controllers.Interfaces;
    using DCHotelManagerCore.Web.Api.Controllers;
    using DCHotelManagerCore.Web.Api.Controllers.Interfaces;

    public class MvcHotelController : Controller,IEntityUiController<Hotel>
    {
        private IEntityController<Hotel> hotelController;

        public MvcHotelController(IEntityController<Hotel> hotelController )
        {
            this.hotelController = hotelController;
        }

        #region Implementation of IEntityUiController<Hotel>

        public ViewResult CreateOrUpdateEntity(Hotel entity)
        {
            return this.View(this.hotelController.CreateOrUpdateEntity(entity));
        }

        public ViewResult Delete(int id)
        {
            this.hotelController.Delete(id);
            return this.View();
        }

        public ViewResult GetAll()
        {
            return this.View(this.hotelController.GetAll());
        }

        public ViewResult GetEntity(int id)
        {
            return this.View(this.hotelController.GetEntity(id));
        }

        #endregion
    }
}