using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ReportSpace.PMPConnector.Connector;
using TechTalk.SpecFlow;

namespace ReportSpace.Tests
{
    [Binding]
    public class StepPmpConnector
    {
        #region

        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [Given("I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see http://go.specflow.org/doc-sharingdata 
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            ScenarioContext.Current.Pending();
        }

        [When("I press add")]
        public void WhenIPressAdd()
        {
            //TODO: implement act (action) logic

            ScenarioContext.Current.Pending();
        }

        [Then("the result should be (.*) on the screen")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

            ScenarioContext.Current.Pending();
        }

        #endregion


        #region

       


        [Given(@"I create a pmp request for weeks (.*) to (.*)")]
        public void GivenICreateAPmpRequestForWeeks(int p0, int p1)
        {
            var ctx = new Context();

            for (int i = p0; i < p1; i++)
            {
                var request = new PmpRequest("http://api.acrowire.com/api/reporting/projectsbyuser/2014-" + 1);

                var list = request.GetResponse<PmpResource>();

                foreach (var pmpResource in list)
                {
                    string query = string.Format(
                        "INSERT INTO vw_project_summary_by_user values('{0}','{1}', {2}, {3}, {4}, {5}, {6} );",
                                                 pmpResource.User_name, pmpResource.Project, pmpResource.Total_hours,
                                                 pmpResource.Billable_hours, pmpResource.Gross_revenue,
                                                 pmpResource.Direct_labor, "12" );
                    ctx.Database.ExecuteSqlCommand(query);
                }
            }
        }

        private PmpRequest _request;
        private List<PmpResource> _list;
        
        [Given(@"I create a pmp request for week (.*)")]
        public void GivenICreateAPmpRequestForWeek(int p0)
        {
            _request = new PmpRequest("http://api.acrowire.com/api/reporting/projectsbyuser/2014-" + p0);
        }

        [When(@"I get the List response (.*)")]
        public void WhenIGetTheListResponse(int p0)
        {
            int year = 2014;

            _list = _request.GetResponse<PmpResource>();

            using (SqlConnection openCon = new SqlConnection("Data Source=TXBOJVALDES;Initial Catalog=PmpRepository;User Id=admin;Password=admin;Max Pool Size=100;Pooling=True;"))
            {
                openCon.Open();

                foreach (var pmpResource in _list)
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = openCon;            // <== lacking
                        command.CommandType = CommandType.Text;
                        command.CommandText = "INSERT into vw_project_summary_by_user (user_name, project, total_hours, billable_hours, gross_revenue, direct_labor, weekname) " +
                                              "VALUES (@userName, @project, @total_hours, @billable_hours, @gross_revenue, @direct_labor, @week, @year)";
                        command.Parameters.AddWithValue("@userName", pmpResource.User_name);
                        command.Parameters.AddWithValue("@project", pmpResource.Project);
                        command.Parameters.AddWithValue("@total_hours", pmpResource.Total_hours);
                        command.Parameters.AddWithValue("@billable_hours", pmpResource.Billable_hours);
                        command.Parameters.AddWithValue("@gross_revenue", pmpResource.Gross_revenue);
                        command.Parameters.AddWithValue("@direct_labor", pmpResource.Direct_labor);
                        command.Parameters.AddWithValue("@week", p0);
                        command.Parameters.AddWithValue("@year", year);

                        int recordsAffected = command.ExecuteNonQuery();
                    }
                }
            }

        }

        [Then(@"the response should contain (.*) items")]
        public void ThenTheResponseShouldContainItems(int p0)
        {
            //Assert.AreEqual(p0, _list.Count);
        }

        #endregion


        #region

        private int requests;
        [Given(@"I want to create pmp requests for week (.*) or higher")]
        public void GivenIWantToCreatePmpRequestsForWeekOrHigher(int p0)
        {
            requests = p0;
        }


        [When(@"I get the run the requests")]
        public void WhenIGetTheRunTheRequests()
        {
            int year = 2014;

            for (int i = requests; i < requests + 7; i++)
            {
                var request = new PmpRequest("http://api.acrowire.com/api/reporting/projectsbyuser/2014-" + i);

                var list = request.GetResponse<PmpResource>();

                using (SqlConnection openCon = new SqlConnection("Data Source=TXBOJVALDES;Initial Catalog=PmpRepository;User Id=admin;Password=admin;Max Pool Size=100;Pooling=True;"))
                {
                    openCon.Open();

                    foreach (var pmpResource in list)
                    {
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = openCon;            // <== lacking
                            command.CommandType = CommandType.Text;
                            command.CommandText = "INSERT into vw_project_summary_by_user (user_name, project, total_hours, billable_hours, gross_revenue, direct_labor, week, year) " +
                                                  "VALUES (@userName, @project, @total_hours, @billable_hours, @gross_revenue, @direct_labor, @week, @year)";
                            command.Parameters.AddWithValue("@userName", pmpResource.User_name);
                            command.Parameters.AddWithValue("@project", pmpResource.Project);
                            command.Parameters.AddWithValue("@total_hours", pmpResource.Total_hours);
                            command.Parameters.AddWithValue("@billable_hours", pmpResource.Billable_hours);
                            command.Parameters.AddWithValue("@gross_revenue", pmpResource.Gross_revenue);
                            command.Parameters.AddWithValue("@direct_labor", pmpResource.Direct_labor);
                            command.Parameters.AddWithValue("@week", i);
                            command.Parameters.AddWithValue("@year", year);

                            int recordsAffected = command.ExecuteNonQuery();
                        }
                    }
                }

            }
        }


        #endregion
    }
}
