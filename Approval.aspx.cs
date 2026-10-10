using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Data_Project
{
    public partial class Approval : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadApprovals();
            }
        }

        private void LoadApprovals()
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
                    SUM(RI.quantity * RI.unit_price) AS total_amount
                FROM Requisitions R

                INNER JOIN staff S
                    ON R.staff_id = S.staff_id

                INNER JOIN requisition_items RI
                    ON R.requisition_id = RI.requisition_id

                WHERE R.status = 'Pending'

                GROUP BY
                    R.requisition_id,
                    S.staff_name,
                    R.department,
                    R.request_date

                ORDER BY
                    R.request_date DESC,
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

                        gvApprovals.DataSource = dt;
                        gvApprovals.DataBind();
                    }
                }
            }
        }

        protected void gvApprovals_RowCommand(
            object sender,
            GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Approve")
            {
                return;
            }

            int requisition_id =
                Convert.ToInt32(e.CommandArgument);

            GridViewRow row =
                (GridViewRow)((Button)e.CommandSource).NamingContainer;

            DropDownList ddlVendor =
                (DropDownList)row.FindControl("ddlVendor");

            int vendor_id =
                Convert.ToInt32(ddlVendor.SelectedValue);

            ApproveRequisition(
                requisition_id,
                vendor_id);
        }

        private void ApproveRequisition(
            int requisition_id,
            int vendor_id)
        {
            string connectionString =
                ConfigurationManager
                .ConnectionStrings["TermProjectConnectionString"]
                .ConnectionString;

            try
            {
                using (SqlConnection con =
                       new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd =
                           new SqlCommand(
                               "sp_ApprovePurchaseOrder",
                               con))
                    {
                        cmd.CommandType =
                            System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue(
                            "@RequisitionID",
                            requisition_id);

                        cmd.Parameters.AddWithValue(
                            "@VendorID",
                            vendor_id);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }

                lblMessage.Text =
                    "อนุมัติใบขอซื้อเรียบร้อยแล้ว";

                LoadApprovals();
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "ไม่สามารถอนุมัติได้: "
                    + ex.Message;
            }
        }
    }
}