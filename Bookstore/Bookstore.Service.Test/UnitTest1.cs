using System;
using System.Linq;
using Bookstore.Service.Test.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhetos.Dom.DefaultConcepts;

namespace Bookstore.Service.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AutomaticallyUpdateNumberOfComments()
        {
            using (var container = BookstoreContainer.CreateTransactionScope())
            {
                var repository = container.Resolve<Common.DomRepository>();

                var book = new Book { Title = Guid.NewGuid().ToString() };
                repository.Bookstore.Book.Insert(book);

                int? readNumberOfComments() => repository.Bookstore.BookInfo
                    .Query(bi => bi.ID == book.ID)
                    .Select(bi => bi.NumberOfComments)
                    .Single();

                Assert.AreEqual(0, readNumberOfComments());

                var c1 = new Comment { BookID = book.ID, Text = "c1" };
                var c2 = new Comment { BookID = book.ID, Text = "c2" };

                repository.Bookstore.Comment.Insert(c1);
                Assert.AreEqual(1, readNumberOfComments());

                repository.Bookstore.Comment.Insert(c2);
                Assert.AreEqual(2, readNumberOfComments());
            }
        }
    }
}
