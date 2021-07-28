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
        }

        [Fact]
        public void BookCalculatesHighestGrades()
        {
            //Arrange
            var book = new Book("");
            book.AddGrade(66.32);
            book.AddGrade(76.35);
            book.AddGrade(84.58);

            //Act
            var result = book.GetStatistics();

            //Test 
            Assert.Equal( 84.58, result.High, 2);
        }

        [Fact]
        public void BookCalculatesLowestGrades()
        {
            //Arrange
            var book = new Book("");
            book.AddGrade(66.32);
            book.AddGrade(76.35);
            book.AddGrade(84.58);

            //Act
            var result = book.GetStatistics();

            //Test
            Assert.Equal( 66.32, result.Low, 2);      
        }

        [Fact]
        public void BookReturnsCorrectLetterGrade()
        {
            //Arrange
            var book = new Book("");
            book.AddGrade(66.32);
            book.AddGrade(76.35);
            book.AddGrade(84.58);

            //Act
            var result = book.GetStatistics();

            //Test
            Assert.Equal( "C", result.Letter);      
        }
    }
}
