// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MvcRoomController.cs" company="">
//   
// </copyright>
// <summary>
//   The mvc room controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.UINew.Controllers.Models.Room
{
    #region

    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using DCHotelManagerCore.Lib.Models.Persistent;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    #endregion

    /// <summary>
    /// The mvc room controller.
    /// </summary>
    [Route("client/[controller]")]
    public class MvcRoomController : BaseMvcController<Room>
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
        public async Task<IActionResult> Create(Room room)
        {
            room.Hotel = null;

            var jsonRoom = JsonConvert.SerializeObject(room);

            
            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(
                               "http://localhost:5010/api/Room/createOrUpdate",
                               new StringContent(jsonRoom, Encoding.UTF8, "application/json"));
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
        [Route("CreateOrUpdateRoom")]
        public async Task<IActionResult> CreateOrUpdateRoom(Room room)
        {
            var localRoom = new Room();
            

            var httpClient = new HttpClient();
            var response = httpClient.GetAsync($"http://localhost:5010/api/Room/getentity/{room.Id}").Result;
            if (response.IsSuccessStatusCode && room.Id != 0)
            {
                var stateInfo = response.Content.ReadAsStringAsync().Result;
                 localRoom = JsonConvert.DeserializeObject<Room>(stateInfo);
            }

            response = httpClient.GetAsync($"http://localhost:5010/api/Hotel/getall").Result;
            if (response.IsSuccessStatusCode)
            {
                var stateInfo = response.Content.ReadAsStringAsync().Result;
                localRoom.AllHotels = JsonConvert.DeserializeObject<List<Hotel>>(stateInfo);
            }

            response = httpClient.GetAsync($"http://localhost:5010/api/RoomType/getall").Result;
            if (response.IsSuccessStatusCode)
            {
                var stateInfo = response.Content.ReadAsStringAsync().Result;
                localRoom.AllRoomTypes = JsonConvert.DeserializeObject<List<RoomType>>(stateInfo);
                return this.View(localRoom);
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
        public override async Task<IActionResult> Delete(IList<Room> rooms)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var roomList = rooms.Where(room => room.IsChecked).Select(room => room.Id).ToList();

            var jsonRoom = JsonConvert.SerializeObject(roomList);

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(
                               "http://localhost:5010/api/Room/delete",
                               new StringContent(jsonRoom, Encoding.UTF8, "application/json"));

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
            List<Room> rooms = null;
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:5010/api/Room/getall").Result;
            if (response.IsSuccessStatusCode)
            {
                var stateInfo = response.Content.ReadAsStringAsync().Result;
                rooms = JsonConvert.DeserializeObject<List<Room>>(stateInfo);
            }

            return this.View(rooms);
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
        [Route("getentity/{id}")]
        public override ViewResult GetEntity(int id)
        {
            // return this.View(this.hotelController.GetEntity(id));
            return null;
        }
    }
}