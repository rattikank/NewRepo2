<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="RequisitionDetail.aspx.cs"
    Inherits="Data_Project.RequisitionDetail" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>รายละเอียดใบขอซื้อ</title>

    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            background-color: #f5f5f5;
        }

        .header {
            background-color: #4b2e83;
            color: white;
            padding: 20px;
        }

        .container {
            padding: 30px;
        }

        .info {
            background-color: white;
            padding: 20px;
            margin-bottom: 20px;
            border-radius: 10px;
        }

        .table {
            width: 100%;
            border-collapse: collapse;
            background-color: white;
        }

        .table th {
            background-color: #4b2e83;
            color: white;
            padding: 12px;
            text-align: left;
        }

        .table td {
            padding: 10px;
            border-bottom: 1px solid #ddd;
        }

        .total {
            background-color: white;
            padding: 20px;
            margin-top: 20px;
            text-align: right;
            font-size: 20px;
            font-weight: bold;
        }

        .back {
            display: inline-block;
            margin-bottom: 20px;
            color: #4b2e83;
            text-decoration: none;
            font-weight: bold;
        }
    </style>
</head>

<body>

<form id="form1" runat="server">

    <div class="header">
        <h1>ระบบจัดซื้อจัดจ้างและอนุมัติใบสั่งซื้อ</h1>
    </div>

    <div class="container">

        <a href="Requisition.aspx" class="back">
            ← กลับรายการใบขอซื้อ
        </a>

        <h2>รายละเอียดใบขอซื้อ</h2>

        <div class="info">

            <p>
                <strong>รหัสใบขอซื้อ:</strong>
                <asp:Label ID="lblRequisitionID"
                    runat="server">
                </asp:Label>
            </p>

            <p>
                <strong>ผู้ขอซื้อ:</strong>
                <asp:Label ID="lblStaffName"
                    runat="server">
                </asp:Label>
            </p>

            <p>
                <strong>แผนก:</strong>
                <asp:Label ID="lblDepartment"
                    runat="server">
                </asp:Label>
            </p>

            <p>
                <strong>วันที่ขอซื้อ:</strong>
                <asp:Label ID="lblRequestDate"
                    runat="server">
                </asp:Label>
            </p>

            <p>
                <strong>สถานะ:</strong>
                <asp:Label ID="lblStatus"
                    runat="server">
                </asp:Label>
            </p>

        </div>

        <h3>รายการสินค้า</h3>

        <asp:GridView
            ID="gvItems"
            runat="server"
            AutoGenerateColumns="False"
            EmptyDataText="ไม่พบข้อมูลใบขอซื้อ"
            CssClass="table">

            <Columns>

                <asp:BoundField
                    DataField="item_name"
                    HeaderText="รายการ" />

                <asp:BoundField
                    DataField="quantity"
                    HeaderText="จำนวน" />

                <asp:BoundField
                    DataField="unit_price"
                    HeaderText="ราคาต่อหน่วย"
                    DataFormatString="{0:N2}" />

                <asp:BoundField
                    DataField="total_price"
                    HeaderText="รวม"
                    DataFormatString="{0:N2}" />

            </Columns>

        </asp:GridView>

        <div class="total">
            ยอดรวม:
            <asp:Label
                ID="lblTotal"
                runat="server">
            </asp:Label>
            บาท
        </div>

    </div>

</form>

</body>
</html>