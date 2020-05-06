using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using MarsFramework.Global;

namespace MarsFramework.Pages
{
    class SignIn
    {
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        internal void LoginSteps()
        {
            //populate Excel Sheet
            Global.GlobalDefinitions.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "SignIn");

            // Go To URL

            Global.GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

            // Click on SignIn Link
            SignIntab.Click();

            // Enter Email Field // global.globaldefinations if u didn't declare them, if u declare "marsframework.global" no need to use it everytime
            Email.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Username"));


            // Enter Password Field
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            // Click On Login Button
            LoginBtn.Click();
        }
    }
}