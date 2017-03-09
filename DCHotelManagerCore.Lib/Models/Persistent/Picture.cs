// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Picture.cs" company="">
//   
// </copyright>
// <summary>
//   The pictures.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.Lib.Models.Persistent
{
    #region

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Drawing;

    using DCHotelManagerCore.Lib.Models.Persistent.Interfaces;

    using Microsoft.AspNetCore.Http;

    #endregion

    /// <summary>
    /// The pictures.
    /// </summary>
    public class Picture : IEntity
    {
        /// <summary>
        /// Gets or sets the byte array.
        /// </summary>
        public byte[] ByteArray { get; set; }

        /// <summary>
        /// Gets or sets the hotel id.
        /// </summary>
        public int? HotelId { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is checked.
        /// </summary>
        [NotMapped]
        public bool IsChecked { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the room id.
        /// </summary>
        public int? RoomId { get; set; }
    }
}