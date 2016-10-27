﻿using Autofac;
using CrossLayer.Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObject.Factory.Contracts.Pages.Contracts;
using PageObject.SetUpWebDriver;
using TechTalk.SpecFlow;
using UserStories.AcceptanceTest.Steps.Base;

namespace UserStories.AcceptanceTest.Steps
{
    /// <summary>
    /// Login Steps.
    /// </summary>
    /// <seealso cref="UserStories.AcceptanceTest.Steps.Base.BaseStep" />
    [Binding]
    public class LoginSteps : BaseStep
    {
        // Home Page.
        private readonly IHomePage _homePage;

        // Manager Page.
        private readonly IManagerPage _managerPage;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginSteps"/> class.
        /// </summary>
        public LoginSteps()
        {
            this._homePage = AutofacContainer.AContainer.Resolve<IHomePage>();
            this._managerPage = AutofacContainer.AContainer.Resolve<IManagerPage>();
        }

        /// <summary>
        /// Givens the user enters to the home page.
        /// </summary>
        [Given(@"The user enters to the home page")]
        public void GivenTheUserEntersToTheHomePage()
        {
            this._homePage.GoToHomePage();
        }

        /// <summary>
        /// Whens the user logs with a valid user.
        /// </summary>
        [Given(@"The user logs with a valid user")]
        [When(@"The user logs with a valid user")]
        public void WhenTheUserLogsWithAValidUser()
        {
            this._homePage.LoginUser("mngr52720", "yzynUrE");
        }

        /// <summary>
        /// Whens the user logs with an invalid user.
        /// </summary>
        [When(@"The user logs with an invalid user")]
        public void WhenTheUserLogsWithAnInvalidUser()
        {
            this._homePage.LoginUser("invalid", "invalid");
        }

        /// <summary>
        /// Thens the user has logged correctly.
        /// </summary>
        [Then(@"The user '(.*)' has logged correctly")]
        public void ThenTheUserHasLoggedCorrectly(string userId)
        {
            Assert.AreEqual(string.Concat("Manger Id : ", userId), this._managerPage.GetWelcomeUserManager());
        }

        /// <summary>
        /// Thens the web throws a pop up.
        /// </summary>
        [Then(@"The web throws a pop up")]
        public void ThenTheWebThrowsAPopUp()
        {
            this._homePage.SwitchToIncorrectUserLoginAlert();
        }

        /// <summary>
        /// Thens the system dispose the web driver.
        /// </summary>
        [Then(@"The system dispose the web driver")]
        public void ThenTheSystemDisposeTheWebDriver()
        {
            SetUpWebDriver.CloseChromeWebDriver();
        }
    }
}
