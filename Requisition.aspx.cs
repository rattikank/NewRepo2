using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Data_Project
{
    public partial class Requisition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRequisitions();
            }
        }

        private void LoadRequisitions()
        {
            string connectionString =
                ConfigurationManager
                .ConnectionStrings["TermProjectConnectionString"]
                .ConnectionString;

            string sql = @"
               SELECT
                    R.requisition_id,
                    S.staff_name,
                    R.department,
                    R.request_date,
                    R.status
                FROM dbo.requisitions AS R
                INNER JOIN dbo.staff AS S
                    ON R.staff_id = S.staff_id
                ORDER BY R.request_date DESC,
                         R.requisition_id DESC;
            ";

            using (SqlConnection con =
                   new SqlConnection(connectionString))
            {
                using (SqlCommand cmd =
                       new SqlCommand(sql, con))
                {
                    using (SqlDataAdapter da =
                           new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        gvRequisitions.DataSource = dt;
                        gvRequisitions.DataBind();
                    }
                }
            }
        }
    }
}