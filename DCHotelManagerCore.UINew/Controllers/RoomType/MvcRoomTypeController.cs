using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCHotelManagerCore.UINew.Controllers.RoomType
{
    using System.Net.Http;
    using System.Text;

    using DCHotelManagerCore.Lib.Models.Persistent;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    [Route("client/[controller]")]
    public class MvcRoomTypeController:BaseMvcController<RoomType>
    {
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(RoomType roomType)
        {
            var jsonRoomType = JsonConvert.SerializeObject(roomType);

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(
                               "http://localhost:5010/api/RoomType/createOrUpdate",
                               new StringContent(jsonRoomType, Encoding.UTF8, "application/json"));
            //var newRoomType = response.Content.ReadAsStringAsync().Result;
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
        [Route("CreateOrUpdateRoomType")]
        public async Task<IActionResult> CreateOrUpdateRoomType(RoomType roomType)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync($"http://localhost:5010/api/RoomType/getentity/{roomType.Id}").Result;
            if (response.IsSuccessStatusCode && roomType.Id != 0)
            {
                var stateInfo = response.Content.ReadAsStringAsync().Result;
                var localRoomType = JsonConvert.DeserializeObject<RoomType>(stateInfo);
                
                    return this.View(localRoomType);
            }
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
        public override async Task<IActionResult> Delete(IList<RoomType> roomTypes)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var roomTypeList = roomTypes.Where(room => room.IsChecked).Select(room => room.Id).ToList();

            var jsonRoomTypes = JsonConvert.SerializeObject(roomTypeList);

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(
                               "http://localhost:5010/api/RoomType/delete",
                               new StringContent(jsonRoomTypes, Encoding.UTF8, "application/json"));

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
            List<RoomType> roomTypes = null;
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:5010/api/RoomType/getall").Result;
            if (response.IsSuccessStatusCode)
            {
                var stateInfo = response.Content.ReadAsStringAsync().Result;
                roomTypes = JsonConvert.DeserializeObject<List<RoomType>>(stateInfo);
            }

            return this.View(roomTypes);
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
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync($"http://localhost:5010/api/RoomType/getentity?id={id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var stateInfo = response.Content.ReadAsStringAsync().Result;
                var localRoomType = JsonConvert.DeserializeObject<RoomType>(stateInfo);
                return this.View(localRoomType);
            }

            return this.View();
        }
    }
}
