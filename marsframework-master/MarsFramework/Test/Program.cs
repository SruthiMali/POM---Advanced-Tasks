using Marsframework.Pages;
using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {
            //  Page Object Model and Test driven Framework Saved in my F: Drive 

            [Test]
            public void Profile1()
            {
                // Creates a toggle for the given test, adds all log events under it
                test = extent.StartTest("Profile");

                //Create a Class & an Object to call the method
                Profile P = new Profile();
                P.AddDescription();
                P.EditDescription();
                P.ClickChangePassword();
            }

            [Test]
            public void ShareSkill()
            {
                // Creates a toggle for the given test, adds all log events under it
                test = extent.StartTest("ShareSkill");

                //Create a Class & an Object to call the method
                ShareSkill SK = new ShareSkill();
                
                SK.ClickOnShareSkillButton();
                SK.EnterTitle();
                SK.EnterDescription();
                SK.SelectCategoryDropDown();
                SK.SelectSubCategoryDropDown();
                SK.SelectTags();
                SK.SelectLocationTypeOptions();
                SK.SelectStartDateDropDown();
                SK.SelectEndDateDropDown();
                SK.SelectDays();
                SK.SelectStartTimeDropDown();
                SK.SelectEndTimeDropDown();
                SK.SelectSkillTradeOption();
                SK.SelectSkillExchangeOption();
                SK.SelectActiveOption();
                SK.UploadWorkSamplesAutoIt();
                SK.ClickSave();

            }

            [Test]
            public void ManageListings()
            {
                // Creates a toggle for the given test, adds all log events under it
                test = extent.StartTest("ManageListings");

                // Because of application problem we need to click Skill button first, then ManageListings Link
                //Create a Class & an Object to call the Shareskill method
                ShareSkill SK = new ShareSkill();

                //Create a Class & an Object to call the ManageListings method
                ManageListings ML = new ManageListings();

                SK.ClickOnShareSkillButton();
                ML.ClickOnmanageListingsLink();
                //ML.ClickView();
                ML.Clickedit();
                ML.Clickdelete();

            }

            [Test]
            public void ManageRequests()
            {
                // Creates a toggle for the given test, adds all log events under it
                test = extent.StartTest("ManageRequests");

                //Create a Class & an Object to call the ManageRequests method
                ManageRequests MR = new ManageRequests();

                MR.ClickOnnManageRequestsLink(); 
                MR.ClickOnReceivedRequests();
                MR.ClickOnSentRequests(); 

            }

            [Test]
            public void SearchSkills()
            {
                // Creates a toggle for the given test, adds all log events under it
                test = extent.StartTest("SearchSkills");

                //Create a Class & an Object to call the ManageRequests method
                SearchSkills SS = new SearchSkills();
                SS.ClickOnSearchSkills();
                SS.ClickOnCatagories();
                SS.ClickOnSubCatagories();
            }


        }
    }
}