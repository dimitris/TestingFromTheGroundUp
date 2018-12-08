using SoccerEvents.Services;

namespace SoccerEvents.ManualTestDoublesTests._TestDoubles.Services
{
    class DummyNotifier : INotifier
    {
        public void SendEmail(string to, string contents)
        {
            // no-op
        }

        public void SendSms(string phoneNumber, string message)
        {
            // no-op
        }
    }
}