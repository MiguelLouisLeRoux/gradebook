using System;
using Xunit;

namespace GradeBook.tests
{
    public class TypseTests
    {

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string theName = "Pete";
            toUpperCase(theName);
            var name = toUpperCase(theName);
            Assert.Equal("Pete", theName);
            Assert.Equal("PETE", name);
        }

        private string toUpperCase(string val)
        {
            return val.ToUpper();
        }

        [Fact]
        public void Test1()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }
        
        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }


        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book2, book1);

        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book2, book1);
           

        }

        Book GetBook(string name){
            return new Book(name);
        }
    }
}
