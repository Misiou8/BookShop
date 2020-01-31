using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BookshopTest.Selenium
{
    [TestClass]
    public class BookSelenium
    {
        private string _loginAdmin, _passwordAdmin;
        private IWebDriver _driver;

        [TestInitialize]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://localhost:44349");
            _loginAdmin = "a@gmail.com";
            _passwordAdmin = "Abcd1!";
        }

        [TestMethod]
        public void AddPublisherTest()
        {
            AutoLogin(_loginAdmin, _passwordAdmin);
            _driver.FindElement(By.LinkText("Wydawcy")).Click();
            try
            {
                var elements = _driver.FindElements(By.TagName("tr")).Count;
                var expected = elements + 1;

                _driver.FindElement(By.LinkText("Utwórz")).Click();
                _driver.FindElement(By.Id("Name")).SendKeys("Zielona Sowa");
                _driver.FindElement(By.Id("Street")).SendKeys("Paciorkowa");
                _driver.FindElement(By.Id("StreetNumber")).SendKeys("15");
                _driver.FindElement(By.Id("PostalCode")).SendKeys("30-115");
                _driver.FindElement(By.Id("City")).SendKeys("Kraków");
                _driver.FindElement(By.Id("Phone")).SendKeys("777 888 999");
                _driver.FindElement(By.ClassName("btn-primary")).Click();

                elements = _driver.FindElements(By.TagName("tr")).Count;
                Assert.AreEqual(expected, elements);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                AutoLogout();
            }
        }

        [TestMethod]
        public void AddBookTest()
        {
            AutoLogin(_loginAdmin, _passwordAdmin);
            _driver.FindElement(By.LinkText("Książki")).Click();
            try
            {
                var elements = _driver.FindElements(By.TagName("tr")).Count;
                var expected = elements + 1;

                _driver.FindElement(By.LinkText("Utwórz")).Click();
                _driver.FindElement(By.Id("Name")).SendKeys("Ania z Zielonego Wzgórza");
                _driver.FindElement(By.Id("Genre")).SendKeys("Przygodowa");
                _driver.FindElement(By.Id("Year")).SendKeys("2015");
                _driver.FindElement(By.ClassName("btn-primary")).Click();

                elements = _driver.FindElements(By.TagName("tr")).Count;
                Assert.AreEqual(expected, elements);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                AutoLogout();
            }
        }

        [TestMethod]
        public void AddUserTest()
        {
            AutoLogin(_loginAdmin, _passwordAdmin);
            _driver.FindElement(By.LinkText("Użytkownicy")).Click();
          
            _driver.FindElement(By.LinkText("Dodaj klienta")).Click();
            _driver.FindElement(By.Id("Name")).SendKeys("Roman");
            _driver.FindElement(By.Id("Surname")).SendKeys("Baryła");
            _driver.FindElement(By.Id("Email")).SendKeys("r.b@gmail.com");
            _driver.FindElement(By.Id("Password")).SendKeys("Romek1!");
            _driver.FindElement(By.Id("ConfirmPassword")).SendKeys("Romek1!");
            _driver.FindElement(By.ClassName("btn-default")).Click();
           
            AutoLogout();
            
        }

        [TestMethod]
        public void DetailsOfExistingBookTest()
        {
            AutoLogin(_loginAdmin, _passwordAdmin);
            _driver.FindElement(By.LinkText("Książki")).Click();
            try
            {
                _driver.FindElement(By.LinkText("Szczegóły")).Click();


                StringAssert.Contains(_driver.Url, "/Books/Details/");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                AutoLogout();
            }
        }

        [TestMethod]
        public void DeleteExistingBookTest()
        {
            var name = "Ania z Zielonego Wzgórza";
            AutoLogin(_loginAdmin, _passwordAdmin);
            _driver.FindElement(By.LinkText("Książki")).Click();
            try
            {
                var elements = _driver.FindElements(By.TagName("tr")).Count;
                var expected = elements - 1;

                _driver.FindElement(By.XPath("//table/tbody/tr[td" +
                                             "[normalize-space(text())='" + name + "']]//" +
                                             "a[@id='remove_book']"))
                    .Click();
                _driver.FindElement(By.Id("delete")).Click();

                elements = _driver.FindElements(By.TagName("tr")).Count;
                Assert.AreEqual(expected, elements);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                AutoLogout();
            }
        }


        [TestMethod]
        public void DetailsOfExistingUserTest()
        {
            AutoLogin(_loginAdmin, _passwordAdmin);
            _driver.FindElement(By.LinkText("Użytkownicy")).Click();
            try
            {
                _driver.FindElement(By.LinkText("Szczegóły")).Click();


                StringAssert.Contains(_driver.Url, "/Users/Details/");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                AutoLogout();
            }
        }
        [TestCleanup]
        public void Cleanup()
        {
            _driver.Quit();
            _driver = null;
        }

        private void AutoLogin(string email, string password)
        {
            _driver.FindElement(By.LinkText("Logowanie")).Click();
            _driver.FindElement(By.Id("Email")).SendKeys(email);
            _driver.FindElement(By.Id("Password")).SendKeys(password);
            _driver.FindElement(By.XPath("//button[@type='submit'][text()='Zaloguj się']")).Click();
        }

        private void AutoLogout()
        {
            _driver.FindElement(By.Id("logout")).Click();
        }
    }
}
