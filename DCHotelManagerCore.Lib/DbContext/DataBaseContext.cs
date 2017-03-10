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
    using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="DataBaseContext"/> class.
        /// </summary>
        public DataBaseContext()
            : base(
                new DbContextOptions<DataBaseContext>().WithExtension(
                    new SqlServerOptionsExtension
                        {
                            ConnectionString =
                                "Server=ANDREADAKIS01\\KOSTASANDRE;Database=DCHotelManagerCore;Trusted_Connection=True;MultipleActiveResultSets=true"
                        }))
        {
        }

        /// <summary>
        /// Gets or sets the billings.
        /// </summary>
        public DbSet<Billing> Billings { get; set; }

        /// <summary>
        /// Gets or sets the billing services.
        /// </summary>
        public DbSet<BillingService> BillingServices { get; set; }

        /// <summary>
        /// Gets or sets the bookings.
        /// </summary>
        public DbSet<Booking> Bookings { get; set; }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the hotels.
        /// </summary>
        public DbSet<Hotel> Hotels { get; set; }

        /// <summary>
        /// Gets or sets the pictures.
        /// </summary>
        public DbSet<Picture> Pictures { get; set; }

        /// <summary>
        /// Gets or sets the rooms.
        /// </summary>
        public DbSet<Room> Rooms { get; set; }

        /// <summary>
        /// Gets or sets the room types.
        /// </summary>
        public DbSet<RoomType> RoomTypes { get; set; }

        /// <summary>
        /// Gets or sets the services.
        /// </summary>
        public DbSet<Service> Services { get; set; }
    }
}