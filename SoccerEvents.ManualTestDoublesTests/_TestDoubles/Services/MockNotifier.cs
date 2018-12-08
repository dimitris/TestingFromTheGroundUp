using SoccerEvents.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoccerEvents.ManualTestDoublesTests._TestDoubles.Services
{
    [Obsolete("This homemade \"Mock\" class is just for demonstration; Do not use it", false)]
    public class MockNotifier : INotifier
    {
        private Dictionary<string, int> _sendEmailCallsRecorder = new Dictionary<string, int>();
        private Dictionary<string, int> _sendSmsCallsRecorder = new Dictionary<string, int>();

        public void SendEmail(string to, string message)
        {
            RecordMethodCall(_sendEmailCallsRecorder, new string[] { to, message });
        }

        public void SendEmailExpectation(string toArgument, string messageArgument, int numberOfTimesCalled)
        {
            if (numberOfTimesCalled != NumberOfTimesSendEmailWasCalledWithSpecificArguments(new string[] { toArgument, messageArgument }))
                throw new Exception("Expectation failed");
        }

        public void SendSms(string phoneNumber, string message)
        {
            RecordMethodCall(_sendSmsCallsRecorder, new string[] { phoneNumber, message });
        }

        public void SendSmsExpectation(string phoneNumberArgument, string messageArgument, int numberOfTimesCalled)
        {
            if (numberOfTimesCalled != NumberOfTimesSendSmsWasCalledWithSpecificArguments(new string[] { phoneNumberArgument, messageArgument }))
            {
                throw new Exception("Expectation failed");
            }
        }

        private void RecordMethodCall(Dictionary<string, int> recorder, IEnumerable<string> callArguments)
        {
            string argumentsSignature = GetArgumentsSignature(callArguments);

            if (!recorder.ContainsKey(argumentsSignature))
                recorder.Add(argumentsSignature, 0);

            recorder[argumentsSignature] += 1;
        }

        private string GetArgumentsSignature(IEnumerable<string> callArguments) => string.Join("_", callArguments);

        private int NumberOfTimesSendEmailWasCalledWithSpecificArguments(IEnumerable<string> callArguments) =>
            _sendEmailCallsRecorder.Where(kv => kv.Key == GetArgumentsSignature(callArguments)).FirstOrDefault().Value;

        public int NumberOfTimesSendSmsWasCalledWithSpecificArguments(IEnumerable<string> callArguments) =>
            _sendSmsCallsRecorder.Where(kv => kv.Key == GetArgumentsSignature(callArguments)).FirstOrDefault().Value;
    }
}