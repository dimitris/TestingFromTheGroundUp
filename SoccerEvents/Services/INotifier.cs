namespace SoccerEvents.Services
{
    /// <summary>
    /// Provides various notification capabilities
    /// </summary>
    public interface INotifier
    {
        /// <summary>
        /// Sends email
        /// </summary>
        void SendEmail(string to, string contents);

        /// <summary>
        /// Sends sms
        /// </summary>
        void SendSms(string phoneNumber, string message);
    }
}