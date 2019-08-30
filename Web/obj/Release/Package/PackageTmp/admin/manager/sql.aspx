<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sql.aspx.cs" Inherits="Web.admin.manager.sql" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <asp:Button ID="Button1" runat="server" Text="备份数据库" OnClick="Button1_Click1" /><br />
        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
        <asp:Button ID="Button2" runat="server" Text="还原数据库" OnClick="Button1_Click2" />*请先备份数据库然后再还原
    </form>
</body>
</html>
