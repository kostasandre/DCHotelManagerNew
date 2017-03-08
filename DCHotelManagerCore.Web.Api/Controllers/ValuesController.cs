// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValuesController.cs" company="">
//   
// </copyright>
// <summary>
//   The values controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.Web.Api.Controllers
{
    #region

    using System.Collections.Generic;
    using System.Linq;

    using DCHotelManagerCore.Lib.Models.Persistent;
    using DCHotelManagerCore.Lib.Repositories;
    using DCHotelManagerCore.Lib.Repositories.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    #endregion

    /// <summary>
    /// The values controller.
    /// </summary>
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// The hotel repository.
        /// </summary>
        private readonly IEntityRepository<Hotel> hotelRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValuesController"/> class.
        /// </summary>
        /// <param name="hotelRepository">
        /// The hotel repository.
        /// </param>
        public ValuesController(IEntityRepository<Hotel> hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        // DELETE api/values/5

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET api/values
        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        [HttpGet]
        public string Get()
        {
            var strin = "";
            return strin;
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        /// <summary>
        /// The post.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        /// <summary>
        /// The put.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}