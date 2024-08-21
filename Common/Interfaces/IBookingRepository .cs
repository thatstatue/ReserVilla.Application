using DummyWebApp.Domain.Entities;
using System.Web.Mvc;

namespace DummyWebApp.Application.Common.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        void UpdateStatus(int bookingId, string bookingStatus);
        void UpdatePaymentStatus(int bookingId, string sessionId, string paymentStatus);
    }

}