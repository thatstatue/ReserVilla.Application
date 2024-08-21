using DummyWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyWebApp.Application.Utility
{
    public static class SD
    {
        public const string Role_Admin = "Admin";
        public const string Role_Customer = "Customer";

        public const string StatusPending = "Pending";
        public const string StatusApproved = "Approved";
        public const string StatusCheckedIn = "CheckedIn";
        public const string StatusCompleted = "Completed";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";


        public static IEnumerable<VillaNumber>? RoomsAvailable(int? villaId,IEnumerable<Booking> allBookings,IEnumerable<VillaNumber> allRooms, DateOnly checkInDate, int nights)
        {
            IEnumerable<VillaNumber> availableRooms = new List<VillaNumber>();
            IEnumerable < Booking > bookings = allBookings.Where(u =>(u.CheckInDate.AddDays(u.Nights)>checkInDate && u.CheckInDate<= checkInDate) 
            || (u.CheckInDate> checkInDate && u.CheckInDate< checkInDate.AddDays(nights))
            );
            if (villaId != null)
            {
                bookings = bookings.Where(u => u.VillaId == villaId);
            }
            foreach (var room in allRooms)
            {
                if (!bookings.Any(u=> u.Villa_Number == room.Villa_Number &&
                (u.Status==SD.StatusApproved || u.Status == SD.StatusCheckedIn)))
                {
                    if (villaId == null || room.VillaId == villaId)
                    {
                    availableRooms = availableRooms.Append(room);
                    }
                }
            }
            return availableRooms;
        }

    }
}
