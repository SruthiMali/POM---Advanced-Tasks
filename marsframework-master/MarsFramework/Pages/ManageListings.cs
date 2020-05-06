using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

       //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes - for delete
        [FindsBy(How = How.XPath, Using = "//button[contains(.,'Yes')]")]
        private IWebElement clickYesButton { get; set; }

        //Click on No - for not deleting 
        [FindsBy(How = How.XPath, Using = "//button[contains(.,'No')]")]
        private IWebElement clickNoButton { get; set; }
        

        //Click on ShareSkill Button [ under shareskill button]
        [FindsBy(How = How.XPath, Using = "//a[@class='ui basic green button']")]
        private IWebElement ShareSkillButton { get; set; }


        //Enter the Title in textbox [ under shareskill button]
        [FindsBy(How = How.XPath, Using = "//input[@name='title']")]
        private IWebElement Title { get; set; }

        //Click on Save button [ under shareskill button]
        [FindsBy(How = How.XPath, Using = "//input[@value='Save'] ")]
        private IWebElement Save { get; set; }

        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");

        }

        internal void ClickOnShareSkillButton()
        {
            // Because of application problem we need to click Skill button first, then ManageListings Link
            //Click on ShareSkill Button
           
            //defining driver wait
            GlobalDefinitions.wait(5000);

            //Click on Shareskill button
            ShareSkillButton.Click();

            //Write Log reports
            Base.test.Log(LogStatus.Info, "Clicked Shareskill Button");

        }

        internal void ClickOnmanageListingsLink()
        {
            //defining driver wait
            GlobalDefinitions.wait(5000);

            //Click on manageListingsLink
            manageListingsLink.Click();

            //Write Log reports
            Base.test.Log(LogStatus.Info, "Clicked Manage Listings Link");

        }

        internal void ClickView()
        {
            ////View the listing
            view.Click();

            //Write Log reports
            Base.test.Log(LogStatus.Info, "Clicked Save Button");
        }

        internal void Clickedit()
        {
            //Edit the listing
            edit.Click();

            //Clear the title textbox
            Title.Clear();

            //Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Title"));
            Title.SendKeys("Selenium");

            //Click on Save button
            Save.Click();

            //Write Log reports
            Base.test.Log(LogStatus.Info, "Clicked Edit Button");

        }

        internal void Clickdelete()
        {

            if (GlobalDefinitions.ExcelLib.ReadData(2, "DeleteAction").Equals("Yes"))
            {
                // perform action i.e Click on Yes 
                clickYesButton.Click();

                //Write Log reports
                Base.test.Log(LogStatus.Info, "Clicked on YES button for delete");
            }
            else
            {
                // perform action i.e Click on No
                clickNoButton.Click();

                //Write Log reports
                Base.test.Log(LogStatus.Info, "Clicked on NO  button for delete");
            }

        }

    }
}
