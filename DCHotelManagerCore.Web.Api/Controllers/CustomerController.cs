// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerController.cs" company="">
//   
// </copyright>
// <summary>
//   The customer controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.Web.Api.Controllers
{
    #region

    using System.Collections.Generic;

    using DCHotelManagerCore.Lib.Models.Persistent;
    using DCHotelManagerCore.Lib.Repositories.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    #endregion

    /// <summary>
    /// The customer controller.
    /// </summary>
    [Route("api/[controller]")]
    public class CustomerController : BaseController<Customer>
    {
        /// <summary>
        /// The hotel repository.
        /// </summary>
        private readonly IEntityRepository<Customer> customerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class. 
        /// Initializes a new instance of the <see cref="RoomController"/> class.
        /// </summary>
        /// <param name="customerRepository">
        /// The customer Repository.
        /// </param>
        public CustomerController(IEntityRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Hotel"/>.
        /// </returns>
        public override JsonResult CreateOrUpdateEntity([FromBody] Customer entity)
        {
            if (entity.Id == 0)
            {
                entity = this.customerRepository.Create(entity);
            }
            else
            {
                this.customerRepository.Update(entity);
            }

            return new JsonResult(entity);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entities"></param>
        public override void Delete([FromBody]int[] customersId)
        {
            this.customerRepository.Delete(customersId);
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public override JsonResult GetAll()
        {
            var customerList = this.customerRepository.ReadAllList();
            return new JsonResult(customerList);
        }
    }
}