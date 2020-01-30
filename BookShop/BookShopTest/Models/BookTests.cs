using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BookShop.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BookshopTest
{
    [TestClass]
    public class BookTests
    {
        private string _name, _genre;
        private int _year;

        [TestInitialize]
        public void InitializeTests()
        {
            _name = "Higurashi";
            _genre = "Horror";
            _year = 2015;
        }

        [TestMethod]
        public void AllBookData_isValid()
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
        public void NameGenre_notWithCapitalLetter()
        {
            var book = new Book()
            {
                Name = "costam",
                Genre = "jeszczejak",
                Year = 1900
            };

            var result = TestModelHelper.Validate(book);
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void NameGenre_LengthIsLessThanExpected()
        {
            var book = new Book()
            {
                Name = "Co",
                Genre = "Si",
            };

            var result = TestModelHelper.Validate(book);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]

        public void Year_TooFew()
        {
            var book = new Book()
            {
                Name = "Elo",
                Genre = "Ziomeczki",
                Year = 1899
            };

            var result = TestModelHelper.Validate(book);
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void Year_NotFuture()
        {
            var book = new Book()
            {
                Name = "Swietna",
                Genre = "Futurystyczna",
                Year = 2022
            };

            var result = TestModelHelper.Validate(book);
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void Year_CannotPutString()
        {
            var book = new Book()
            {
                Name = new string('Z', 41),
                Genre = new string('X', 41),
                Year = _year
            };

            var result = TestModelHelper.Validate(book);
            Assert.AreEqual(2, result.Count);
        }

        [TestCleanup]
        public void CleanupTests()
        {
            _name = null;
            _genre = null;
            _year = 0;
        }
    }
}
