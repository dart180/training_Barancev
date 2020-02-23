using System;
using TechTalk.SpecFlow;
using WebAddressbookTests;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [Binding]
    public class LoginSteps
    {
        private ApplicationManager app
        {
            get { return ApplicationManager.GetInstance(); }
        }

        [Given(@"A user is logged out")]
        public void GivenAUserIsLoggedOut()
        {
            app.Auth.Logout();
        }
        
        [When(@"I login with username ""(.*)** and password ""(.*)""")]
        public void WhenILoginWithValidCredencials(string username, string password)
        {
            AccountData account = new AccountData(username, password);
            ScenarioContext.Current.Add("account", account);
            app.Auth.Login(account);
        }
        
        [Then(@"I have logged in")]
        public void ThenIHaveLoggedIn()
        {
            AccountData account = ScenarioContext.Current.Get<AccountData>("account");  
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Then(@"I have not logged in")]
        public void ThenIHaveNotLoggedIn()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
