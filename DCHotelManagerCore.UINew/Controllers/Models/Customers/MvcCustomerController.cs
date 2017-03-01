using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCHotelManagerCore.UINew.Controllers.Models.Customers
{
    using System.Net.Http;
    using System.Text;

    using DCHotelManagerCore.Lib.Models.Persistent;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    [Route("client/[controller]")]
    public class MvcCustomerController: BaseMvcController<Customer>
    {
        // IEntityUiController<Hotel>

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="room">
        /// The room.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            var jsonCustomer = JsonConvert.SerializeObject(customer);

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(
                               "http://localhost:5010/api/Customer/createOrUpdate",
                               new StringContent(jsonCustomer, Encoding.UTF8, "application/json"));
            var newHotel = response.Content.ReadAsStringAsync().Result;
            return this.RedirectToAction("GetAll");
        }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="room">
        /// The room.
        /// </param>
        /// <returns>
        /// The <see cref="ViewResult"/>.
        /// </returns>
        [Route("CreateOrUpdateCustomer")]
        public async Task<IActionResult> CreateOrUpdateCustomer(Customer customers)
        {
            return this.View();
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="rooms">
        /// The rooms.
        /// </param>
        /// <returns>
        /// The <see cref="ViewResult"/>.
        /// </returns>
        [Route("delete")]
        [HttpPost]
        public override async Task<IActionResult> Delete(IList<Customer> customers)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var customerList = customers.Where(customer => customer.IsChecked).Select(customer => customer.Id).ToList();

            var jsonCustomer = JsonConvert.SerializeObject(customerList);

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(
                               "http://localhost:5010/api/Customer/delete",
                               new StringContent(jsonCustomer, Encoding.UTF8, "application/json"));

            return this.RedirectToAction("GetAll");
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="ViewResult"/>.
        /// </returns>
        [Route("getall")]
        public override ViewResult GetAll()
        {
            List<Customer> customers = null;
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:5010/api/Customer/getall").Result;
            if (response.IsSuccessStatusCode)
            {
                var stateInfo = response.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<List<Customer>>(stateInfo);
            }

            return this.View(customers);
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
        public override ViewResult GetEntity(int id)
        {
            // return this.View(this.hotelController.GetEntity(id));
            return null;
        }
    }
}
