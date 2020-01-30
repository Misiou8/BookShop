using System.Threading.Tasks;
using BookShop.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using BookShop.Controllers;
using Microsoft.AspNetCore.Mvc;
using BookShop.Data.Fakes;

namespace BookshopTest.Controllers
{
    [TestClass]
    public class TestDoubleBook
    {
        private string _name, _genre;
        private int _year;

        [TestInitialize]
        public void Initialize()
        {
            _name = "Higurashi";
            _genre = "Horror";
            _year = 2015;
        }

        [TestMethod]
        public void CheckValidatorsOnBook()
        {
            var book = new Book()
            {
                Name = _name,
                Genre = _genre,
                Year = _year
            };

            var context = new ValidationContext(book);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(book, context, result, true);

            Assert.IsTrue(valid);
        }

        [TestMethod]
        public async Task RedirectionAfterCreatingBook()
        {
            var book = new Book();
            var bookRepository = new FakeBookRepository();
            var controller = new BooksController(bookRepository);

            var result = await controller.Create(book);

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public async Task CheckIfBookIsAdded()
        {
            var book = new Book()
            {
                Name = _name,
                Genre = _genre,
                Year = _year
            };

            var context = new FakeBookRepository();
            var controller = new BooksController(context);

            await controller.Create(book);

            Assert.AreEqual(1, context.Books.Count);

        }
    }
}
