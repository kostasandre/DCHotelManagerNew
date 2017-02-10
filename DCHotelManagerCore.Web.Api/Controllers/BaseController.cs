using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCHotelManagerCore.Web.Api.Controllers
{
    using DCHotelManagerCore.Lib.Models.Persistent;
    using DCHotelManagerCore.Lib.Models.Persistent.Interfaces;
    using DCHotelManagerCore.Web.Api.Controllers.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    public class BaseController<T>: IEntityController<T>
        where T: IEntity
    {
        #region Implementation of IEntityController<T>
        [Route("createOrUpdate")]
        [HttpPost]
        public virtual T CreateOrUpdateEntity(T entity)
        {
            throw new NotImplementedException();
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public virtual void Delete(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("getall")]
        public virtual IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public T GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
