using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    internal class ManageRequests
    {
        public ManageRequests()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }


        //Click on Manage Requests link
        [FindsBy(How = How.XPath, Using = "//div[@class='ui dropdown link item']")]
        private IWebElement manageRequestsLink { get; set; }

        //Click on Received Requests 
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Received Requests')]")]
        private IWebElement receivedRequests { get; set; }

        //Click on Sent Requests
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Sent Requests')]")]
        private IWebElement sentRequests { get; set; }

        internal void Requests()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageRequests");

        }

        internal void ClickOnnManageRequestsLink()
        {
            
            //defining driver wait
            GlobalDefinitions.wait(2000);

            // Click on Manage Requests link
            manageRequestsLink.Click();


            // Get current URL and store in a variable
            String CurrentUrl = GlobalDefinitions.driver.Url;

            // Print the Current Url in console
            Console.WriteLine(CurrentUrl);

            //defining driver wait
            GlobalDefinitions.wait(2000);


            // Validate if user had navigated to Manage Requests page successfully

            if (CurrentUrl == "http://192.168.99.100:5000/Account/Profile")
         
            {
                Console.WriteLine("Passed - Manage Requests link takes user to Manage Requests page succesfully");

            }
            else
            {
                Console.WriteLine("Failed - Manage Requests link not taken user to Manage Requests page");

                //take screen shot and save with given name
                GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Not Navigated to Manage Requests page");

                //Write Log reports 
                Base.test.Log(LogStatus.Info, "Test Failed ");
            }

            // Assertion on Manage Requests link current Url VS Expected Url
            Assert.That(CurrentUrl, Is.EqualTo("http://192.168.99.100:5000/Account/Profile"));
           

            //Write Log reports 
            Base.test.Log(LogStatus.Info, "Clicked Manage Requests Link");


        }

        internal void ClickOnReceivedRequests()
        {
            try
            {
                //defining driver wait
                GlobalDefinitions.wait(2000);

                // To mouse hover Manage Requests link using Actions
                Actions action1 = new Actions(GlobalDefinitions.driver);

                //Click on Received Requests
                action1.MoveToElement(manageRequestsLink).MoveToElement(receivedRequests).Click().Build().Perform();

                //defining driver wait
                GlobalDefinitions.wait(2000);
                
                // Get current URL and store in a variable
                String ReceivedRequestCurrentUrl = GlobalDefinitions.driver.Url;

                // Print in Console
                Console.WriteLine(ReceivedRequestCurrentUrl);

                GlobalDefinitions.wait(2000);

                // Validate if user had navigated to Received Requests page successfully
                if (ReceivedRequestCurrentUrl == "http://192.168.99.100:5000/Home/ReceivedRequest")

                {
                    // Print in Console
                    Console.WriteLine("Passed - Received Requests link takes user to Received Requests page succesfully");

                    //Write Log reports 
                    Base.test.Log(LogStatus.Info, "Navigated to Received Requests page ");
                }
                else
                {
                    // Print in Console
                    Console.WriteLine("Failed - Received Requests link not taken user to Received Requests page");


                    //take screen shot and save with given name
                    GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Not Navigated to Received Requests page");

                    //Write Log reports 
                    Base.test.Log(LogStatus.Info, "Navigating to Received requests page - Failed ");
                }

            }
            catch (Exception e)
            {
                // Catch block 
                Base.test.Log(LogStatus.Info, "Received Requests Test Failed ", e.Message);

            }

            //Write Log reports 
            Base.test.Log(LogStatus.Info, "Clicked Received Requests Link");


        }


        internal void ClickOnSentRequests()
        {

            try
            {
                // To mouse hover Manage Requests link using Actions
                Actions action = new Actions(GlobalDefinitions.driver);

                //Click on Sent Requests
                action.MoveToElement(manageRequestsLink).MoveToElement(sentRequests).Click().Perform();

                // Get current URL and store in a variable
                String SentRequestCurrentUrl = GlobalDefinitions.driver.Url;

                // Print in Console
                Console.WriteLine(SentRequestCurrentUrl);

                // Validate if user had navigated to Sent Requests page successfully
                if (SentRequestCurrentUrl == "http://192.168.99.100:5000/Home/SentRequest")

                {
                    // Print in Console
                    Console.WriteLine("Passed - Sent Requests link takes user to Sent Requests page succesfully");

                    //Write Log reports 
                    Base.test.Log(LogStatus.Info, "Navigated to Sent Requests page ");
                }
                else
                {
                    // Print in Console
                    Console.WriteLine("Failed - Sent Requests link not taken user to Sent Requests page");


                    //take screen shot and save with given name
                    GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Not Navigated to Sent Requests page");

                    //Write Log reports 
                    Base.test.Log(LogStatus.Info, "Sent Requests Test Failed ");
                }

            }
            catch (Exception e)
            {

                // Catch block to handle errors
                Base.test.Log(LogStatus.Info, "Test Failed ", e.Message);
            }

            // Assertion on Received Requests link current Url VS Expected Url
            //Assert.That(SentRequestCurrentUrl, Is.EqualTo("http://192.168.99.100:5000/Home/SentRequest"));


            //Write Log reports 
            Base.test.Log(LogStatus.Info, "Clicked Sent Requests Link");

        }

    }



}
