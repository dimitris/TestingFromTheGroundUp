using SoccerEvents.Services;

namespace SoccerEvents.ManualTestDoublesTests._TestDoubles.Services
{
    public class StubNotifier : INotifier
    {
        public void SendEmail(string to, string contents)
        {
        }

        public void SendSms(string phoneNumber, string message)
        {
        }
    }
}