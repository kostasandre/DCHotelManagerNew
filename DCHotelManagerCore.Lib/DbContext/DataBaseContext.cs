// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataBaseContext.cs" company="">
//   
// </copyright>
// <summary>
//   The data base context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DCHotelManagerCore.Lib.DbContext
{
    #region

    using DCHotelManagerCore.Lib.Models.Persistent;

    using Microsoft.EntityFrameworkCore;

    #endregion

    /// <summary>
    /// The data base context.
    /// </summary>
    public class DataBaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataBaseContext"/> class.
        /// </summary>
        /// <param name="options">
        /// The options.
        /// </param>
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public DataBaseContext()
            : base(new DbContextOptions<DataBaseContext>())
        {
        }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the hotels.
        /// </summary>
        public DbSet<Hotel> Hotels { get; set; }

        /// <summary>
        /// Gets or sets the rooms.
        /// </summary>
        public DbSet<Room> Rooms { get; set; }

        /// <summary>
        /// Gets or sets the room types.
        /// </summary>
        public DbSet<RoomType> RoomTypes { get; set; }
    }
}