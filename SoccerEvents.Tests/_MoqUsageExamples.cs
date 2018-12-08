using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerEvents.Tests
{
    [Obsolete("This class is not meant to be used anywhere in this solution; It just contains code examples for you to read", true)]
    class _MoqUsageExamples
    {
        static void Demo()
        {
            //Create an instance of the mock object
            Mock<IProvider> mockProvider = new Mock<IProvider>();

            // Setup the return results of the methods
            mockProvider.Setup(m => m.GetRecordsCount()).Returns(5);

            int recordsCount = mockProvider.Object.GetRecordsCount(); // Now, GetRecordsCount will always return 5

            mockProvider.Setup(m => m.GetNameById(10)).Returns("John");

            string name = mockProvider.Object.GetNameById(10); // Now, for parameter 10, GetNameById will always return "John"

            // Use the mock object
            AClassWhichNeedsAnIProvider aClassWhichNeedsAnIProvider = 
                new AClassWhichNeedsAnIProvider(mockProvider.Object); // Use .Object

            // Verify usage
            mockProvider.Verify(m => m.GetRecordsCount(), Times.Once); // This will throw exception if GetRecordsCount
                                                                       // was not called once

            mockProvider.Verify(m => m.GetNameById(10), Times.Once);   // This will throw exception if GetNameById
                                                                       // was not called once using 10 as parameter 
        }

        interface IProvider
        {
            int GetRecordsCount();

            string GetNameById(int id);
        }

        class AClassWhichNeedsAnIProvider
        {
            public AClassWhichNeedsAnIProvider(IProvider provider)
            {
            }
        }
    }
}