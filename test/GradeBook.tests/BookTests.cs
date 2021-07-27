using System;
using Xunit;

namespace GradeBook.tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAverageGrades()
        {
            //Arrange
            var book = new Book("");
            book.AddGrade(66.32);
            book.AddGrade(76.35);
            book.AddGrade(84.58);

            //Act
            var result = book.GetStatistics();

            //Test
            Assert.Equal( 75.75, result.Average, 2);
            Assert.Equal( 84.58, result.High, 2);
            Assert.Equal( 66.32, result.Low, 2);

            
        }
    }
}
