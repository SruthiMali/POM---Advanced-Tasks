using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
   internal class SearchSkills
    {
        public SearchSkills()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }

        //Click on SearchSkillIcon
        [FindsBy(How = How.XPath, Using = "//i[@class='search link icon']")]
        private IWebElement searchSkillIcon { get; set; }

        //Click on Programming & Tech Catagory
        [FindsBy(How = How.XPath, Using = "//a[@role='listitem'][contains(.,'Programming & Tech')]")]
        private IWebElement programmingTechCatagory { get; set; }

        //Click on QA SubCatagory Under Programming & Tech Catagory
        [FindsBy(How = How.XPath, Using = "//a[@role='listitem'][contains(.,'QA')]")]
        private IWebElement QASubCatagory { get; set; }

        internal void ClickOnSearchSkills()
        {
            try
            {
                //defining driver wait
                GlobalDefinitions.wait(2000);

                // Click on Search Skill Icon
                searchSkillIcon.Click();

                // Get current URL and store in a variable
                String SearchSkillspageUrl = GlobalDefinitions.driver.Url;
                string expectedurl = "http://192.168.99.100:5000/Home/Search?searchString=";

                // Validate if user had navigated to Search skills page successfully (you can use any one of below 3 assertions)
                Assert.That(SearchSkillspageUrl, Is.EqualTo("http://192.168.99.100:5000/Home/Search?searchString="));

                //Assert.AreEqual(expectedurl, SearchSkillspageUrl);
                //Assert.AreEqual(GlobalDefinitions.driver.FindElement(By.XPath("//h3[contains(.,'Refine Results')]")).Text, "Refine Results");

                // Print in Console
                Console.WriteLine("Passed - Search Skills link takes user to Search Skills page succesfully");

                //Write Log reports 
                Base.test.Log(LogStatus.Info, "Navigated to Search Skills page ");

            }
            catch (Exception e)
            {
                // Code for Handling the exception
                Console.WriteLine("Failed - not taken user to Search Skills page");

                //take screen shot and save with given name
                GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Not Navigated to Search Skills page");

                //Write Log reports 
                Base.test.Log(LogStatus.Info, "Not Navigated to Search Skills page ", e.Message);
            }
        }

        internal void ClickOnCatagories()
        {
            
            try
            {
                // Click on any catagory
                programmingTechCatagory.Click();

                // Get current URL and store in a variable
                String catagoryUrl = GlobalDefinitions.driver.Url;
                string expectedurl = "http://192.168.99.100:5000/Home/Search?cat=ProgrammingTech";

                // Validate if user had navigated to Prog & Tech Catagory page successfully (you can use any one of below 3 assertions)
                // Assert.That(catagoryUrl, Is.EqualTo("http://192.168.99.100:5000/Home/Search?cat=ProgrammingTech"));

                Assert.AreEqual(expectedurl, catagoryUrl);
                //Assert.AreEqual(GlobalDefinitions.driver.FindElement(By.XPath("//h3[contains(.,'Refine Results')]")).Text, "Refine Results");

                // Print in Console
                Console.WriteLine("Passed - Navigated to Programming & Tech catagory page succesfully");

                //Write Log reports 
                Base.test.Log(LogStatus.Info, "Navigated to Catagory page ");

            }
            catch (Exception e)
            {
                // Code for Handling the exception
                Console.WriteLine("Failed - not taken user to Catagory page");

                //take screen shot and save with given name
                GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Not Navigated to Catagory page");

                //Write Log reports 
                Base.test.Log(LogStatus.Info, "Not Navigated to Catagory page ", e.Message);
            }

        }

        internal void ClickOnSubCatagories()
        {
            try
            {
                // Click on any Sub catagory
                QASubCatagory.Click();

                // Get current URL and store in a variable
                String SubcatagoryUrl = GlobalDefinitions.driver.Url;
                string expectedurl = "http://192.168.99.100:5000/Home/Search?cat=ProgrammingTech&subcat=4";

                // Validate if user had navigated to QA SubCatagory page successfully (you can use any one of below 3 assertions)
                // Assert.That(catagoryUrl, Is.EqualTo("http://192.168.99.100:5000/Home/Search?cat=ProgrammingTech&subcat=4"));

                Assert.AreEqual(expectedurl, SubcatagoryUrl);
                //Assert.AreEqual(GlobalDefinitions.driver.FindElement(By.XPath("//h3[contains(.,'Refine Results')]")).Text, "Refine Results");

                // Print in Console
                Console.WriteLine("Passed - Navigated to QA Subcatagory page succesfully");

                //Write Log reports 
                Base.test.Log(LogStatus.Info, "Navigated to QA Subcatagory page succesfully ");

            }
            catch (Exception e)
            {
                // Code for Handling the exception
                Console.WriteLine("Failed - not taken user to SubCatagory page");

                //take screen shot and save with given name
                GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Not Navigated to SubCatagory page");

                //Write Log reports 
                Base.test.Log(LogStatus.Info, "Not Navigated to SubCatagory page ", e.Message);
            }

        }
    }
}
