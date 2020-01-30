using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BookShop.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookshopTest
{
    [TestClass]
    public class PublisherTests
    {
        private string _name, _street, _postalCode, _city, _phone;
        private int _streetNumber;

        [TestInitialize]
        public void InitializeTests()
        {
            _name = "Waneko";
            _street = "Orzeszkowa";
            _streetNumber = 33;
            _postalCode = "80-306";
            _city = "Gdańsk";
            _phone = "555 123 532";
        }

        [TestMethod]
        public void AllPublisherData_AreValid()
        {
            var publisher = new Publisher()
            {
                Name = _name,
                Street = _street,
                StreetNumber = _streetNumber,
                PostalCode = _postalCode,
                City = _city,
                Phone = _phone
            };

            var context = new ValidationContext(publisher);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(publisher, context, result, true);

            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void NameStreetCity_TooShort()
        {
            var publisher = new Publisher()
            {
                Name = "O",
                Street = "XDD",
                StreetNumber = _streetNumber,
                PostalCode = _postalCode,
                City = "W",
                Phone = _phone
            };

            var result = TestModelHelper.Validate(publisher);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void NameStreetCity_TooLong()
        {
            var publisher = new Publisher()
            {
                Name = new string('X', 31),
                Street = new string('D', 41),
                StreetNumber = _streetNumber,
                PostalCode = _postalCode,
                City = new string('D', 31),
                Phone = _phone
            };

            var result = TestModelHelper.Validate(publisher);
            Assert.AreEqual(3, result.Count);
        }
        [TestMethod]
        public void NameStreetCity_NotCapitalChar()
        {
            var publisher = new Publisher()
            {
                Name = "insignis",
                Street = "złomowa",
                StreetNumber = _streetNumber,
                PostalCode = _postalCode,
                City = "sosnowiec",
                Phone = _phone
            };

            var result = TestModelHelper.Validate(publisher);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void StreetNumber_Wrong()
        {
            var publisher = new Publisher()
            {
                Name = _name,
                Street = _street,
                StreetNumber = 0,
                PostalCode = _postalCode,
                City = _city,
                Phone = _phone
            };

            var result = TestModelHelper.Validate(publisher);
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void PostalCode_Wrong()
        {
            var publisher = new Publisher()
            {
                Name = _name,
                Street = _street,
                StreetNumber = _streetNumber,
                PostalCode = "123-52",
                City = _city,
                Phone = _phone
            };

            var result = TestModelHelper.Validate(publisher);
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void Phone_Wrong()
        {
            var publisher = new Publisher()
            {
                Name = _name,
                Street = _street,
                StreetNumber = _streetNumber,
                PostalCode = _postalCode,
                City = _city,
                Phone = "12345656352"
            };

            var result = TestModelHelper.Validate(publisher);
            Assert.AreEqual(1, result.Count);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _name = null;
            _street = null;
            _streetNumber = 0;
            _postalCode = null;
            _city = null;
            _phone = null;
        }
    }
}
