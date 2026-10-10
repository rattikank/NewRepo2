<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Dashboard.aspx.cs"
    Inherits="Data_Project.Dashboard" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Dashboard - Procurement System</title>

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

        .cards {
            display: flex;
            gap: 20px;
            flex-wrap: wrap;
        }

        .card {
            background-color: white;
            width: 220px;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 2px 8px rgba(0,0,0,0.1);
        }

        .card h3 {
            margin-top: 0;
            color: #555;
        }

        .number {
            font-size: 32px;
            font-weight: bold;
            color: #4b2e83;
        }
    </style>
</head>

<body>

<form id="form1" runat="server">

    <div class="header">
        <h1>ระบบจัดซื้อจัดจ้างและอนุมัติใบสั่งซื้อ</h1>
        <p>Procurement & Purchase Order System</p>
    </div>

    <div class="container">

        <h2>Dashboard</h2>

        <div class="cards">

            <div class="card">
                <h3>ใบขอซื้อทั้งหมด</h3>
                <asp:Label ID="lblRequisitions"
                    runat="server"
                    CssClass="number">
                </asp:Label>
            </div>

            <div class="card">
                <h3>ใบสั่งซื้อทั้งหมด</h3>
                <asp:Label ID="lblPurchaseOrders"
                    runat="server"
                    CssClass="number">
                </asp:Label>
            </div>

            <div class="card">
                <h3>ผู้ขายทั้งหมด</h3>
                <asp:Label ID="lblVendors"
                    runat="server"
                    CssClass="number">
                </asp:Label>
            </div>

            <div class="card">
                <h3>พนักงานทั้งหมด</h3>
                <asp:Label ID="lblStaff"
                    runat="server"
                    CssClass="number">
                </asp:Label>
            </div>

        </div>

    </div>

</form>

</body>
</html>