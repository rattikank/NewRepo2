using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Data_Project
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDashboard();
            }
        }

        private void LoadDashboard()
        {
            string connectionString =
                ConfigurationManager
                .ConnectionStrings["TermProjectConnectionString"]
                .ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // จำนวนใบขอซื้อ
                string sqlRequisitions =
                    "SELECT COUNT(*) FROM Requisitions";

                using (SqlCommand cmd = new SqlCommand(sqlRequisitions, con))
                {
                    lblRequisitions.Text =
                        cmd.ExecuteScalar().ToString();
                }

                // จำนวนใบสั่งซื้อ
                string sqlPurchaseOrders =
                    "SELECT COUNT(*) FROM Purchase_Orders";

                using (SqlCommand cmd = new SqlCommand(sqlPurchaseOrders, con))
                {
                    lblPurchaseOrders.Text =
                        cmd.ExecuteScalar().ToString();
                }

                // จำนวนผู้ขาย
                string sqlVendors =
                    "SELECT COUNT(*) FROM Vendors";

                using (SqlCommand cmd = new SqlCommand(sqlVendors, con))
                {
                    lblVendors.Text =
                        cmd.ExecuteScalar().ToString();
                }

                // จำนวนพนักงาน
                string sqlStaff =
                    "SELECT COUNT(*) FROM Staff";

                using (SqlCommand cmd = new SqlCommand(sqlStaff, con))
                {
                    lblStaff.Text =
                        cmd.ExecuteScalar().ToString();
                }
            }
        }
    }
}