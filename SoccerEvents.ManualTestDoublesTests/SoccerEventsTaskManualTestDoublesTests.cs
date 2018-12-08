using SoccerEvents.ManualTestDoublesTests._TestDoubles.Persistence;
using SoccerEvents.ManualTestDoublesTests._TestDoubles.Services;
using SoccerEvents.Persistence;
using SoccerEvents.Services;
using SoccerEvents.SoccerEvents;
using Xunit;

namespace SoccerEvents.ManualTestDoublesTests
{
    public class SoccerEventsTaskManualTestDoublesTests
    {
        [Fact]
        void Update_WithZeroSoccerEvents_ReturnsFalse()
        {
            // Arrange
            ISoccerEventsProvider provider = new StubZeroSoccerEventsProvider();
            ISoccerEventsStore store = new DummySoccerEventsStore();
            INotifier notifier = new DummyNotifier();

            string infoEmailAddress = "info@example.com", infoMessage = "Soccer events processed successfully",
                alertEmailAddress = "alert@example.com", alertSmsNumber = "6999999999",
                alertMessage = "ALERT! No soccer events!";

            SoccerEventsTask sut = new SoccerEventsTask(provider, store, notifier,
                infoEmailAddress, infoMessage, alertEmailAddress, alertSmsNumber, alertMessage);

            bool expected = false;

            // Act
            bool actual = sut.Update();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        void Update_WithZeroSoccerEvents_CallsNotifierSendEmailAndSendSmsOnce()
        {
            // Arrange
            ISoccerEventsProvider provider = new StubZeroSoccerEventsProvider();
            ISoccerEventsStore store = new DummySoccerEventsStore();
            SpyNotifier notifier = new SpyNotifier();

            string infoEmailAddress = "info@example.com", infoMessage = "Soccer events processed successfully",
                alertEmailAddress = "alert@example.com", alertSmsNumber = "6999999999",
                alertMessage = "ALERT! No soccer events!";

            SoccerEventsTask sut = new SoccerEventsTask(provider, store, notifier,
                infoEmailAddress, infoMessage, alertEmailAddress, alertSmsNumber, alertMessage);

            int expectedTimesSendEmailWasCalled = 1;
            int expectedTimesSendSmsWasCalled = 1;

            // Act
            sut.Update();

            // Assert
            Assert.Equal(expectedTimesSendEmailWasCalled, notifier.NumberOfTimesSendEmailWasCalled);
            Assert.Equal(expectedTimesSendSmsWasCalled, notifier.NumberOfTimesSendSmsWasCalled);
        }

        [Fact]
        void Update_WithZeroSoccerEvents_CallsNotifierSendEmailAndSendSmsUsingCorrectAlertParametersOnce()
        {
            // Arrange
            ISoccerEventsProvider provider = new StubZeroSoccerEventsProvider();
            ISoccerEventsStore store = new DummySoccerEventsStore();
            MockNotifier notifier = new MockNotifier();

            string infoEmailAddress = "info@example.com", infoMessage = "Soccer events processed successfully",
                alertEmailAddress = "alert@example.com", alertSmsNumber = "6999999999",
                alertMessage = "ALERT! No soccer events!";

            SoccerEventsTask sut = new SoccerEventsTask(provider, store, notifier,
                infoEmailAddress, infoMessage, alertEmailAddress, alertSmsNumber, alertMessage);

            int expectedTimesSendEmailWasCalled = 1;
            int expectedTimesSendSmsWasCalled = 1;

            // Act
            bool actual = sut.Update();

            // Assert
            notifier.SendEmailExpectation(alertEmailAddress, alertMessage, expectedTimesSendEmailWasCalled);
            notifier.SendSmsExpectation(alertSmsNumber, alertMessage, expectedTimesSendSmsWasCalled);
        }

        [Fact]
        void Update_WithThreeSoccerEvents_ReturnsTrue()
        {
            // Arrange
            ISoccerEventsProvider provider = new StubThreeSoccerEventsProvider();
            ISoccerEventsStore store = new DummySoccerEventsStore();
            INotifier notifier = new DummyNotifier();

            string infoEmailAddress = "info@example.com", infoMessage = "Soccer events processed successfully",
            alertEmailAddress = "alert@example.com", alertSmsNumber = "6999999999",
            alertMessage = "ALERT! No soccer events!";

            SoccerEventsTask sut = new SoccerEventsTask(provider, store, notifier,
                infoEmailAddress, infoMessage, alertEmailAddress, alertSmsNumber, alertMessage);

            bool expected = true;

            // Act
            bool actual = sut.Update();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        void Update_WithThreeSoccerEvents_CallsNotifierSendEmailOnce()
        {
            // Arrange
            StubThreeSoccerEventsProvider provider = new StubThreeSoccerEventsProvider();
            DummySoccerEventsStore store = new DummySoccerEventsStore();
            SpyNotifier notifier = new SpyNotifier();

            string infoEmailAddress = "info@example.com", infoMessage = "Soccer events processed successfully",
            alertEmailAddress = "alert@example.com", alertSmsNumber = "6999999999",
            alertMessage = "ALERT! No soccer events!";

            SoccerEventsTask sut = new SoccerEventsTask(provider, store, notifier,
                infoEmailAddress, infoMessage, alertEmailAddress, alertSmsNumber, alertMessage);

            int expectedTimesSendEmailWasCalled = 1;

            // Act
            sut.Update();
            int actualTimesSendEmailWasCalled = notifier.NumberOfTimesSendEmailWasCalled;

            // Assert
            Assert.Equal(expectedTimesSendEmailWasCalled, actualTimesSendEmailWasCalled);
        }

        [Fact]
        void Update_WithThreeSoccerEvents_CallsNotifierSendEmailUsingCorrectInfoParametersOnce()
        {
            // Arrange
            StubThreeSoccerEventsProvider provider = new StubThreeSoccerEventsProvider();
            DummySoccerEventsStore store = new DummySoccerEventsStore();
            MockNotifier notifier = new MockNotifier();

            string infoEmailAddress = "info@example.com", infoMessage = "Soccer events processed successfully",
            alertEmailAddress = "alert@example.com", alertSmsNumber = "6999999999",
            alertMessage = "ALERT! No soccer events!";

            SoccerEventsTask sut = new SoccerEventsTask(provider, store, notifier,
                infoEmailAddress, infoMessage, alertEmailAddress, alertSmsNumber, alertMessage);

            int expectedTimesSendEmailWasCalled = 1;

            // Act
            sut.Update();

            // Assert
            notifier.SendEmailExpectation(infoEmailAddress, infoMessage, expectedTimesSendEmailWasCalled);
        }
    }
}
