using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Data_Project { 
    public partial class TestDB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString =
                    ConfigurationManager
                    .ConnectionStrings["TermProjectConnectionString"]
                    .ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    lblResult.Text = "Database Connected Successfully!";
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = "Connection Failed: " + ex.Message;
            }
        }
    }
}