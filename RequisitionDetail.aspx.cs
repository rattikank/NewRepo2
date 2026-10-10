using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Data_Project
{
    public partial class RequisitionDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRequisitionDetail();
            }
        }

        private void LoadRequisitionDetail()
        {
            string idText = Request.QueryString["id"];

            int requisitionID;

            if (!int.TryParse(idText, out requisitionID))
            {
                Response.Redirect("Requisition.aspx");
                return;
            }

            string connectionString =
                ConfigurationManager
                .ConnectionStrings["TermProjectConnectionString"]
                .ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // 1. ข้อมูลใบขอซื้อ
                string sqlRequisition = @"
                    SELECT
                        r.requisition_id,
                        s.staff_name,
                        r.department,
                        r.request_date,
                        r.status
                    FROM requisitions r
                    INNER JOIN staff s
                        ON r.staff_id = s.staff_id
                    WHERE r.requisition_id = @requisition_id;
                ";

                using (SqlCommand cmd = new SqlCommand(sqlRequisition, con))
                {
                    cmd.Parameters.AddWithValue("@requisition_id", requisitionID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // แก้ไขชื่อคอลัมน์ใน reader[...] เป็น snake_case ให้ตรงตาม SQL
                            lblRequisitionID.Text = reader["requisition_id"].ToString();
                            lblStaffName.Text = reader["staff_name"].ToString();
                            lblDepartment.Text = reader["department"].ToString();
                            lblRequestDate.Text = Convert.ToDateTime(reader["request_date"]).ToString("dd/MM/yyyy");
                            lblStatus.Text = reader["status"].ToString();
                        }
                        else
                        {
                            Response.Redirect("Requisition.aspx");
                            return;
                        }
                    }
                }

                // 2. รายการสินค้า
                string sqlItems = @"
                    SELECT
                        item_name,
                        quantity,
                        unit_price,
                        quantity * unit_price AS total_price
                    FROM requisition_items
                    WHERE requisition_id = @requisition_id;
                ";

                using (SqlCommand cmd = new SqlCommand(sqlItems, con))
                {
                    cmd.Parameters.AddWithValue("@requisition_id", requisitionID);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        gvItems.DataSource = dt;
                        gvItems.DataBind();
                    }
                }

                // 3. ยอดรวม
                string sqlTotal = @"
                    SELECT
                        ISNULL(
                            SUM(quantity * unit_price),
                            0
                        )
                    FROM requisition_items
                    WHERE requisition_id = @requisition_id;
                ";

                using (SqlCommand cmd = new SqlCommand(sqlTotal, con))
                {
                    cmd.Parameters.AddWithValue("@requisition_id", requisitionID);

                    decimal total = Convert.ToDecimal(cmd.ExecuteScalar());
                    lblTotal.Text = total.ToString("N2");
                }
            }
        }
    }
}