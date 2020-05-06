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
    class Profile
    {
        public Profile()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click Desctiption Icon 
        [FindsBy(How = How.XPath, Using = "//h3[contains(.,'Description')]/span")]
        private IWebElement Description { get; set; }

        //Enter Description 
        [FindsBy(How = How.XPath, Using = "//textarea[@maxlength='600']")]
        private IWebElement EnterDescription { get; set; }

        //Click on Save Button to save description
        [FindsBy(How = How.XPath, Using = "//button[@type='button']")]
        private IWebElement DescriptionSave { get; set; }

        //Click on username/Hi Sruthi
        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Hi Sruthi')]")]
        private IWebElement Username { get; set; }

        //Click Change Password
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Change Password')]")]
        private IWebElement ChangePassword { get; set; }

        // Click on current password 
        [FindsBy(How = How.XPath, Using = "//input[@name='oldPassword']")]
        private IWebElement CurrentPassword { get; set; }

        // Click on New password 
        [FindsBy(How = How.XPath, Using = "//input[@name='newPassword']")]
        private IWebElement NewPassword { get; set; }

        // Click on Confirm password 
        [FindsBy(How = How.XPath, Using = "//input[@name='confirmPassword']")]
        private IWebElement ConfirmPassword { get; set; }

        // Click on Change password save button
        [FindsBy(How = How.XPath, Using = "//button[@type='button'][contains(.,'Save')]")]
        private IWebElement ChangePasswordSave { get; set; }

        

        internal void AddDescription()
        {

            try

            {
                GlobalDefinitions.wait(5000);

                // Click on Description Icon 
                Description.Click();

                GlobalDefinitions.wait(9000);

                // Enter Description
                EnterDescription.SendKeys("Hi this Sruthi");

                GlobalDefinitions.wait(5000);

                //Click on Save button
                DescriptionSave.Click();


                // Validate if user added description successfully
                string ExpectedValue = "Description has been saved successfully";
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;

                // Assert Condition for adding description Confirmation message
                Assert.AreEqual(ExpectedValue, ActualValue);

                // Print in Console
                Console.WriteLine("Passed - user added description successfully");

                //Write Log reports 
                Base.test.Log(LogStatus.Info, "user added description successfully");



            }
            catch (Exception e)
            {

                // Print in Console
                Console.WriteLine("Failed - user not added description");

                //take screen shot and save with given name
                GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "user not added description");

                // write log reports
                Base.test.Log(LogStatus.Info, "Adding Description -Test Failed", e.Message);
            }

            //Write Log reports 
            Base.test.Log(LogStatus.Info, "Clicked Add Description Icon");


        }

        internal void EditDescription()
        {
            try

            {
                GlobalDefinitions.wait(2000);

                // Click on Description Icon 
                Description.Click();

                GlobalDefinitions.wait(9000);

                //Clear Description Textbox
                EnterDescription.Clear();


                // Enter Description
                EnterDescription.SendKeys("Hi this description is edited");

                GlobalDefinitions.wait(5000);

                //Click on Save button
                DescriptionSave.Click();


                // Validate if user added description successfully
                string ExpectedValue = "Description has been saved successfully";
                string ActualValue = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;

                // Assert Condition for adding description Confirmation message
                Assert.AreEqual(ExpectedValue, ActualValue);

                // Print in Console
                Console.WriteLine("Passed - user edited description successfully");

                //Write Log reports 
                Base.test.Log(LogStatus.Info, "user edited description successfully");



            }
            catch (Exception e)
            {

                // Print in Console
                Console.WriteLine("Failed - user not edited description");

                //take screen shot and save with given name
                GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "user not edited description");

                // write log reports
                Base.test.Log(LogStatus.Info, "Editing description -Test Failed", e.Message);
            }

            //Write Log reports 
            Base.test.Log(LogStatus.Info, "Clicked edit Description Icon");


        }

        internal void ClickChangePassword()
        {
            try
            {
                //defining driver wait
                GlobalDefinitions.wait(2000);

                // To mouse hover username/Hi Sruthi link using Actions & click change password
               // Actions action2 = new Actions(GlobalDefinitions.driver);
               // action2.MoveToElement(Username).MoveToElement(ChangePassword).Click().Build().Perform();

                //Click on Username & select Change Password  by using Actions 
                Username.Click();

                // using for loop to click down arrow for 2 times
                for (int i=0; i<2; i++)
                {
                    
                    Username.SendKeys(Keys.ArrowDown);
                }


                // Click on Change Password
               ChangePassword.Click();

                //Populate the excel data
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignUp");

                // Enter current password 
                CurrentPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

               // Enter New password 
                NewPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

                //Enter Confirm Password
                ConfirmPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPswd"));

               // Click on Change password save button
                ChangePasswordSave.Click();

                // Print in Console
                Console.WriteLine("Passed - user able to change password ");

                //Write Log reports 
                Base.test.Log(LogStatus.Info, "user able to change password successfully");



            }
            catch (Exception e)
            {

                // Print in Console
                Console.WriteLine("Failed - user unable to change password ");

                //take screen shot and save with given name
                GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Change password");

                // write log reports
                Base.test.Log(LogStatus.Info, "Change password -Test Failed", e.Message);

            }
        }

    }
}
