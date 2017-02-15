using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCHotelManagerCore.UINew.Controllers.Interfaces
{
    using DCHotelManagerCore.Lib.Models.Persistent.Interfaces;

    /// <summary>
    /// The EntityUiController interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IEntityUiController<T> where T:IEntity
    {

    }
}
