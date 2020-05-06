using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using MarsFramework.Global;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Excel.Log;
using RelevantCodes.ExtentReports;
using MarsFramework.Pages;
using AutoItX3Lib;
using System.Collections.Generic;
using System;

namespace Marsframework.Pages

{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }


        //Click on ShareSkill Button
        [FindsBy(How = How.XPath, Using = "//a[@class='ui basic green button']")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='title']")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.XPath, Using = "//textarea[@name='description']")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown // select the dropdown list
        [FindsBy(How = How.XPath, Using = "//select[@name='categoryId']")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='subcategoryId']")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "(//input[@aria-label='Add new tag'])[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type (Hourly basis service)
        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType' and @value='0'] ")]
        private IWebElement Hourlybasisservice { get; set; }

        //Select the Service type (One-off service)
        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType' and @value='1'] ")]
        private IWebElement Oneoffservice { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//input[@name='locationType' and @value='0'] ")]
        private IWebElement LocationTypeOptions { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.XPath, Using = "//input[@name='startDate'] ")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']")]
        private IWebElement EnddateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate'] ")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//div[@class='ui checkbox'] /input[@index='1']")]
        private IWebElement Days { get; set; }

       //Click on Startdate dropdown
        [FindsBy(How = How.XPath, Using = "//input[@name='startDate']")]
        private IWebElement StartdateDropDown { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//input[@name='StartTime' and @index='1']")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//input[@name='EndTime' and @index='1']")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//input[@name='skillTrades' and  @value='true'] ")]
        private IWebElement SkillTradeOption { get; set; }

        //Click On Skill-Exchange option
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper'] //input[@aria-label='Add new tag']")]
        private IWebElement SkillExchangeOption { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@name='charge'] ")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//input[@name='isActive' and @value='true'] ")]
        private IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save'] ")]
        private IWebElement Save { get; set; }

        //Click on Cancel button
        [FindsBy(How = How.XPath, Using = "//input[@value='Cancel'] ")]
        private IWebElement Cancel { get; set; }

        //Click on WorkSample Upload button
        [FindsBy(How = How.XPath, Using = "//i[@class='huge plus circle icon padding-25']")]
        private IWebElement WorkSampleUploadButton { get; set; }

        /*internal void EnterShareSkill()
        {

        }*/

        internal void ClickOnShareSkillButton()
        {
            try
            {
                //defining driver wait
                GlobalDefinitions.wait(2000);


                //Click on ShareSkill Button
                ShareSkillButton.Click();

                // Get current URL and store in a variable
                String ShareSkillCurrentUrl = GlobalDefinitions.driver.Url;

                // Print in Console
                Console.WriteLine(ShareSkillCurrentUrl);

                GlobalDefinitions.wait(2000);

                // Validate if user had navigated to Share skills page successfully
                if (ShareSkillCurrentUrl == "http://192.168.99.100:5000/Home/ServiceListing")

                {
                    // Print in Console
                    Console.WriteLine("Passed - Search skills button takes user to search skills page succesfully");

                    //Write Log reports 
                    Base.test.Log(LogStatus.Info, "Navigated to Search skills page ");
                }
                else
                {
                    // Print in Console
                    Console.WriteLine("Failed - search skills button not taken user to search skills page");


                    //take screen shot and save with given name
                    GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "search skill button");

                    //Write Log reports 
                    Base.test.Log(LogStatus.Info, "Navigating to search skills page - Failed ");
                }

            }
            catch (Exception e)
            {
                // Catch block 
                Base.test.Log(LogStatus.Info, "search skills - Test Failed ", e.Message);

            }

            //Write Log reports 
            Base.test.Log(LogStatus.Info, "Clicked ShareSkill Button");
        }

        internal void EnterTitle()
        {
            //populate Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Share_Skill");

            // Enter Title Field
            GlobalDefinitions.wait(5000);
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Write log reports
            Base.test.Log(LogStatus.Info, "Entered Title");
        }


        internal void EnterDescription()
        {
            // Enter the Description in textbox
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Write log reports
            Base.test.Log(LogStatus.Info, "Entered Description");
        }


        internal void SelectCategoryDropDown()
        {
            /* Click on Category Dropdown
            CategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Graphics & Design")); */

            /* create select element object & select Catagory dropdown
            SelectElement SelectACatagory = new SelectElement(CategoryDropDown);
            SelectACatagory.SelectByText("Graphics & Design"); */

           // create select element object & select Catagory dropdown 
           SelectElement SelectACatagory = new SelectElement(CategoryDropDown);
            foreach (IWebElement element in SelectACatagory.Options)
            {
                if (element.Text == GlobalDefinitions.ExcelLib.ReadData(2, "Category"))
                {
                    element.Click();
                }
            }

            //Write log reports
            Base.test.Log(LogStatus.Info, "Selected Catagory Dropdown");
        }


        internal void SelectSubCategoryDropDown()
        {

            /* create select element object & select sub Category Dropdown
            SelectElement SelectASubCatagory = new SelectElement(SubCategoryDropDown);
            SelectASubCatagory.SelectByText("Flyers & Brochures"); */ 


            //create select element object & select sub Category Dropdown
            SelectElement SelectASubCatagory = new SelectElement(SubCategoryDropDown);
            foreach (IWebElement element in SelectASubCatagory.Options)
            {
                if (element.Text == GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"))
                {
                    element.Click();
                }
            }

            //Write log reports
            Base.test.Log(LogStatus.Info, "Entered Sub Catagory Dropdown");
        }


        internal void SelectTags()
        {
            //Using for loop to enter multiple tags - from excel file
            for (int i = 2; i <10 ; i++)
            {
                Actions action = new Actions(GlobalDefinitions.driver);
                action.MoveToElement(Tags).Click().Perform();
                string TagsDataFromExcel =  GlobalDefinitions.ExcelLib.ReadData(i, "Tags");
                if (TagsDataFromExcel != null)
                {
                    Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(i, "Tags"));
                    Tags.SendKeys(Keys.Enter);
                }

            }

            //Write log reports
            Base.test.Log(LogStatus.Info, "Entered All the tags");
        }


        internal void SelectServiceTypeOptions()
        {
            //Select the Service type

            // ServiceTypeOptions.Click();

            //Using if condition to take service type data from excel file
            if (GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='locationType' and @value='0']")).Text.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "Service Type")))
                {
                    Hourlybasisservice.Click();
                }
               else
                {
                    Oneoffservice.Click();
                }

            //Write log reports
            Base.test.Log(LogStatus.Info, "Selected Service Type");

            
        }


        internal void SelectLocationTypeOptions()
        {
            ////Select the Location type
            LocationTypeOptions.Click();

            //Write log reports
            Base.test.Log(LogStatus.Info, "Selected LOcation Type");
        }


        internal void SelectStartDateDropDown()
        {
            //Find the date time picker control and Fill date as dd/mm/yyyy as 30/03/2020
            StartdateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Start date"));

            //Write log reports
            Base.test.Log(LogStatus.Info, "Entered Startdate");
        }


        internal void SelectEndDateDropDown()
        {
            //Find the date time picker control and Fill date as dd/mm/yyyy as 30/03/2050
            EnddateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "End date"));

            //Write log reports
            Base.test.Log(LogStatus.Info, "Entered Enddate");
        }

        internal void SelectDays()
        {
            //Click On available days
            Days.Click();

            //Write log reports
            Base.test.Log(LogStatus.Info, "Selected Available days");
        }

        internal void SelectStartTimeDropDown()
        {
            //Click on StartTime dropdown
            StartTimeDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartTime"));

            //Write log reports
            Base.test.Log(LogStatus.Info, "Entered StartTime");

        }


        internal void SelectEndTimeDropDown()
        {
            // Click On EndTime Dropdown
            EndTimeDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndTime"));

            //Write log reports
            Base.test.Log(LogStatus.Info, "Entered EndTime");
        }

        internal void SelectSkillTradeOption()
        {
            //Click on Skill Trade option
            SkillTradeOption.Click();

            //Write log reports
            Base.test.Log(LogStatus.Info, "Selected SkillTrade Option");
        }


        internal void SelectSkillExchangeOption()
        {
            // To mouse hover Skill Exchange Option using Actions
            Actions action1 = new Actions(GlobalDefinitions.driver);
            action1.MoveToElement(SkillExchangeOption).Click().Perform();

            //Read Skill exchange data from excel file
            SkillExchangeOption.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));

            //Pressing the enter key 
            SkillExchangeOption.SendKeys(Keys.Enter);

            //Write log reports
            Base.test.Log(LogStatus.Info, "Selected Skill Exchange Option");

        }

        internal void SelectActiveOption()
        {
            //Click on Active/Hidden option
            ActiveOption.Click();

            //Write log reports
            Base.test.Log(LogStatus.Info, "Checked Active Option");
        }



        internal void UploadWorkSamplesAutoIt()
        {

            // Click on Work Sample file upload button
            WorkSampleUploadButton.Click();


            // AutoIt - Handles windows that do not belongs to browser
            AutoItX3 autoIt = new AutoItX3();

            ////To activate the window("open" is the window name for chrome. if u click upload file button from mozilla or IE, the window name is different
            autoIt.WinActivate("Open");  // https://www.youtube.com/watch?v=vmWmCw_8WsE

            //defining driver wait
            GlobalDefinitions.wait(2000);

            // To Select file from a window 
            autoIt.Send(@"F:\Tasks\fileuploadsample.txt");

            //defining driver wait
            GlobalDefinitions.wait(2000);

            // To press open button -- so the file will get uploaded
            autoIt.Send("{ENTER}");


            //Write log reports
            Base.test.Log(LogStatus.Info, "WorkSample File Uploaded");

        }


        internal void ClickSave()
        {
            // Click On Save Button
            Save.Click();

            //Write log reports
            Base.test.Log(LogStatus.Info, "Clicked Save");
        }
    }
}
