using Moq;
using SoccerEvents.Domain;
using SoccerEvents.Persistence;
using SoccerEvents.Services;
using SoccerEvents.SoccerEvents;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SoccerEvents.Tests
{
    public class SoccerEventsTaskTests
    {
        [Fact]
        void Update_WithZeroSoccerEvents_ReturnsFalse()
        {
            // Arrange
            Mock<ISoccerEventsProvider> mockProvider = new Mock<ISoccerEventsProvider>();
            mockProvider.Setup(m => m.GetAll()).Returns(Enumerable.Empty<SoccerEvent>());
            Mock<ISoccerEventsStore> mockStore = new Mock<ISoccerEventsStore>();
            Mock<INotifier> mockNotifier = new Mock<INotifier>();

            string infoEmailAddress = "info@example.com", infoMessage = "Soccer events processed successfully",
                alertEmailAddress = "alert@example.com", alertSmsNumber = "6999999999",
                alertMessage = "ALERT! No soccer events!";

            SoccerEventsTask sut = new SoccerEventsTask(mockProvider.Object, mockStore.Object, mockNotifier.Object,
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
            Mock<ISoccerEventsProvider> mockProvider = new Mock<ISoccerEventsProvider>();
            mockProvider.Setup(m => m.GetAll()).Returns(Enumerable.Empty<SoccerEvent>());
            Mock<ISoccerEventsStore> mockStore = new Mock<ISoccerEventsStore>();
            Mock<INotifier> mockNotifier = new Mock<INotifier>();

            string infoEmailAddress = "info@example.com", infoMessage = "Soccer events processed successfully",
                alertEmailAddress = "alert@example.com", alertSmsNumber = "6999999999",
                alertMessage = "ALERT! No soccer events!";

            SoccerEventsTask sut = new SoccerEventsTask(mockProvider.Object, mockStore.Object, mockNotifier.Object,
                infoEmailAddress, infoMessage, alertEmailAddress, alertSmsNumber, alertMessage);

            // Act
            sut.Update();

            // Assert
            mockNotifier.Verify(m => m.SendEmail(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            mockNotifier.Verify(m => m.SendSms(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        void Update_WithZeroSoccerEvents_CallsNotifierSendEmailAndSendSmsUsingCorrectAlertParametersOnce()
        {
            // Arrange
            Mock<ISoccerEventsProvider> mockProvider = new Mock<ISoccerEventsProvider>();
            mockProvider.Setup(m => m.GetAll()).Returns(Enumerable.Empty<SoccerEvent>());
            Mock<ISoccerEventsStore> mockStore = new Mock<ISoccerEventsStore>();
            Mock<INotifier> mockNotifier = new Mock<INotifier>();

            string infoEmailAddress = "info@example.com", infoMessage = "Soccer events processed successfully",
                alertEmailAddress = "alert@example.com", alertSmsNumber = "6999999999",
                alertMessage = "ALERT! No soccer events!";

            SoccerEventsTask sut = new SoccerEventsTask(mockProvider.Object, mockStore.Object, mockNotifier.Object,
                infoEmailAddress, infoMessage, alertEmailAddress, alertSmsNumber, alertMessage);

            // Act
            sut.Update();

            // Assert
            mockNotifier.Verify(m => m.SendEmail(alertEmailAddress, alertMessage), Times.Once);
            mockNotifier.Verify(m => m.SendSms(alertSmsNumber, alertMessage), Times.Once);
        }

        [Fact]
        void Update_WithThreeSoccerEvents_ReturnsTrue()
        {
            // Arrange
            IEnumerable<SoccerEvent> threeSoccerEvents = new SoccerEvent[]
            {
                new SoccerEvent(eventId: 1, homeScore: 2, awayScore: 0, homeTeam: "Bayern Munich", awayTeam: "Arsenal F.C."),
                new SoccerEvent(eventId: 2, homeScore: 1, awayScore: 1, homeTeam: "Manchester United", awayTeam: "Juventus"),
                new SoccerEvent(eventId: 3, homeScore: 3, awayScore: 3, homeTeam: "Porto F.C.", awayTeam: "Barcelona")
            };

            Mock<ISoccerEventsProvider> mockProvider = new Mock<ISoccerEventsProvider>();
            mockProvider.Setup(m => m.GetAll()).Returns(threeSoccerEvents);
            Mock<ISoccerEventsStore> mockStore = new Mock<ISoccerEventsStore>();
            Mock<INotifier> mockNotifier = new Mock<INotifier>();

            string infoEmailAddress = "info@example.com", infoMessage = "Soccer events processed successfully",
                alertEmailAddress = "alert@example.com", alertSmsNumber = "6999999999",
                alertMessage = "ALERT! No soccer events!";

            SoccerEventsTask sut = new SoccerEventsTask(mockProvider.Object, mockStore.Object, mockNotifier.Object,
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
            IEnumerable<SoccerEvent> threeSoccerEvents = new SoccerEvent[]
            {
                new SoccerEvent(eventId: 1, homeScore: 2, awayScore: 0, homeTeam: "Bayern Munich", awayTeam: "Arsenal F.C."),
                new SoccerEvent(eventId: 2, homeScore: 1, awayScore: 1, homeTeam: "Manchester United", awayTeam: "Juventus"),
                new SoccerEvent(eventId: 3, homeScore: 3, awayScore: 3, homeTeam: "Porto F.C.", awayTeam: "Barcelona")
            };

            Mock<ISoccerEventsProvider> mockProvider = new Mock<ISoccerEventsProvider>();
            mockProvider.Setup(m => m.GetAll()).Returns(threeSoccerEvents);
            Mock<ISoccerEventsStore> mockStore = new Mock<ISoccerEventsStore>();
            Mock<INotifier> mockNotifier = new Mock<INotifier>();

            string infoEmailAddress = "info@example.com", infoMessage = "Soccer events processed successfully",
                alertEmailAddress = "alert@example.com", alertSmsNumber = "6999999999",
                alertMessage = "ALERT! No soccer events!";

            SoccerEventsTask sut = new SoccerEventsTask(mockProvider.Object, mockStore.Object, mockNotifier.Object,
                infoEmailAddress, infoMessage, alertEmailAddress, alertSmsNumber, alertMessage);

            // Act
            bool actual = sut.Update();

            // Assert
            mockNotifier.Verify(m => m.SendEmail(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        void Update_WithThreeSoccerEvents_CallsNotifierSendEmailUsingCorrectInfoParametersOnce()
        {
            // Arrange
            IEnumerable<SoccerEvent> threeSoccerEvents = new SoccerEvent[]
            {
                new SoccerEvent(eventId: 1, homeScore: 2, awayScore: 0, homeTeam: "Bayern Munich", awayTeam: "Arsenal F.C."),
                new SoccerEvent(eventId: 2, homeScore: 1, awayScore: 1, homeTeam: "Manchester United", awayTeam: "Juventus"),
                new SoccerEvent(eventId: 3, homeScore: 3, awayScore: 3, homeTeam: "Porto F.C.", awayTeam: "Barcelona")
            };

            Mock<ISoccerEventsProvider> mockProvider = new Mock<ISoccerEventsProvider>();
            mockProvider.Setup(m => m.GetAll()).Returns(threeSoccerEvents);
            Mock<ISoccerEventsStore> mockStore = new Mock<ISoccerEventsStore>();
            Mock<INotifier> mockNotifier = new Mock<INotifier>();

            string infoEmailAddress = "info@example.com", infoMessage = "Soccer events processed successfully",
                alertEmailAddress = "alert@example.com", alertSmsNumber = "6999999999",
                alertMessage = "ALERT! No soccer events!";

            SoccerEventsTask sut = new SoccerEventsTask(mockProvider.Object, mockStore.Object, mockNotifier.Object,
                infoEmailAddress, infoMessage, alertEmailAddress, alertSmsNumber, alertMessage);

            // Act
            bool actual = sut.Update();

            // Assert
            mockNotifier.Verify(m => m.SendEmail(infoEmailAddress, infoMessage), Times.Once);
        }

        [Fact]
        void Update_WithNonZeroSoccerEvents_CallsStoreSaveUsingCorrectParametersOnce()
        {
            // Arrange
            IEnumerable<SoccerEvent> threeSoccerEvents = new SoccerEvent[]
            {
                new SoccerEvent(eventId: 1, homeScore: 2, awayScore: 0, homeTeam: "Bayern Munich", awayTeam: "Arsenal F.C."),
                new SoccerEvent(eventId: 2, homeScore: 1, awayScore: 1, homeTeam: "Manchester United", awayTeam: "Juventus"),
                new SoccerEvent(eventId: 3, homeScore: 3, awayScore: 3, homeTeam: "Porto F.C.", awayTeam: "Barcelona")
            };

            Mock<ISoccerEventsProvider> mockProvider = new Mock<ISoccerEventsProvider>();
            mockProvider.Setup(m => m.GetAll()).Returns(threeSoccerEvents);
            Mock<ISoccerEventsStore> mockStore = new Mock<ISoccerEventsStore>();
            Mock<INotifier> mockNotifier = new Mock<INotifier>();

            string infoEmailAddress = "info@example.com", infoMessage = "Soccer events processed successfully",
                alertEmailAddress = "alert@example.com", alertSmsNumber = "6999999999",
                alertMessage = "ALERT! No soccer events!";

            SoccerEventsTask sut = new SoccerEventsTask(mockProvider.Object, mockStore.Object, mockNotifier.Object,
                infoEmailAddress, infoMessage, alertEmailAddress, alertSmsNumber, alertMessage);

            // Act
            bool actual = sut.Update();

            // Assert
            mockStore.Verify(m => m.Save(threeSoccerEvents), Times.Once);
        }
    }
}