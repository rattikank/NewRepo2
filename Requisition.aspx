<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Requisition.aspx.cs"
    Inherits="Data_Project.Requisition" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>ใบขอซื้อ</title>

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

        .header h1 {
            margin: 0;
        }

        .container {
            padding: 30px;
        }

        .menu {
            background-color: white;
            padding: 15px;
            margin-bottom: 20px;
        }

        .menu a {
            margin-right: 20px;
            text-decoration: none;
            color: #4b2e83;
            font-weight: bold;
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

        .table tr:hover {
            background-color: #f1f1f1;
        }
    </style>
</head>

<body>

<form id="form1" runat="server">

    <div class="header">
        <h1>ระบบจัดซื้อจัดจ้างและอนุมัติใบสั่งซื้อ</h1>
    </div>

    <div class="container">

        <div class="menu">
            <a href="Dashboard.aspx">Dashboard</a>
            <a href="Requisition.aspx">ใบขอซื้อ</a>
            <a href="Approval.aspx">อนุมัติใบขอซื้อ</a>
        </div>

        <h2>รายการใบขอซื้อ</h2>

        

<asp:GridView
    ID="gvRequisitions"
    runat="server"
    AutoGenerateColumns="False"
    EmptyDataText="ไม่พบข้อมูลใบขอซื้อ"
    CssClass="table">

    <Columns>
        <asp:BoundField
            DataField="requisition_id"
            HeaderText="รหัสใบขอซื้อ" />

        <asp:BoundField
            DataField="staff_name"
            HeaderText="ผู้ขอซื้อ" />

        <asp:BoundField
            DataField="department"
            HeaderText="แผนก" />

        <asp:BoundField
            DataField="request_date"
            HeaderText="วันที่ขอซื้อ"
            DataFormatString="{0:dd/MM/yyyy}" />

        <asp:BoundField
            DataField="status"
            HeaderText="สถานะ" />

        <asp:HyperLinkField
            DataNavigateUrlFields="requisition_id"
            DataNavigateUrlFormatString="RequisitionDetail.aspx?id={0}"
            Text="ดูรายละเอียด"
            HeaderText="รายละเอียด" />
    </Columns>

</asp:GridView>

    </div>

</form>

</body>
</html>