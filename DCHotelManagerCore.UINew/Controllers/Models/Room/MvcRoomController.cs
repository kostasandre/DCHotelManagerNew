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
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using DCHotelManagerCore.Lib.Models.Persistent;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Net.Http.Headers;

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
        /// <param name="picture">
        /// The picture.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(Room room, IFormFile picture)
        {
            var databasePicture = new Picture();
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(
                               "http://localhost:5010/api/Room/createOrUpdate",
                               new StringContent(JsonConvert.SerializeObject(room), Encoding.UTF8, "application/json"));

            var roomId = JsonConvert.DeserializeObject<Room>(response.Content.ReadAsStringAsync().Result).Id;
            if (picture != null && roomId != 0)
            {
                response = await httpClient.GetAsync($"http://localhost:5010/api/Picture/readallquery/{roomId}");
                var existingPicture = JsonConvert.DeserializeObject<Picture>(response.Content.ReadAsStringAsync().Result);

                if (existingPicture != null)
                {
                    response = await httpClient.GetAsync($"http://localhost:5010/api/Picture/unset/{existingPicture.Id}");
                }

                using (var stream = new MemoryStream())
                {
                    await picture.CopyToAsync(stream);
                    databasePicture.RoomId = roomId;
                    databasePicture.ByteArray = stream.ToArray();
                    var jsonPictureToUpload = JsonConvert.SerializeObject(databasePicture);

                    response = await httpClient.PostAsync(
                                   "http://localhost:5010/api/Picture/create",
                                   new StringContent(jsonPictureToUpload, Encoding.UTF8, "application/json"));
                }
            }

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
            }

            response = httpClient.GetAsync($"http://localhost:5010/api/Picture/getall").Result;
            if (response.IsSuccessStatusCode)
            {
                var stateInfo = response.Content.ReadAsStringAsync().Result;
                var pictures = JsonConvert.DeserializeObject<List<Picture>>(stateInfo);

                foreach (var picture in pictures.Where(x => x.RoomId == localRoom.Id))
                {
                    localRoom.Pictures.Add(picture);
                }
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

            response = httpClient.GetAsync($"http://localhost:5010/api/Picture/getall").Result;
            if (response.IsSuccessStatusCode)
            {
                var stateInfo = response.Content.ReadAsStringAsync().Result;
                var pictures = JsonConvert.DeserializeObject<List<Picture>>(stateInfo);

                foreach (var room in rooms)
                {
                    foreach (var picture in pictures.Where(x => x.RoomId == room.Id))
                    {
                        room.Pictures.Add(picture);
                    }
                }
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