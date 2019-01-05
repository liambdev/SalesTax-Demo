<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintReceipt.aspx.cs" Inherits="SalesTax.PrintReceipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sales Tax Receipt</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p><h4>Sales Tax Receipt</h4></p>
            <br />
            <p>
                <asp:GridView ID="gvProds" AutoGenerateColumns="false" ShowHeader="false" GridLines="None" BorderStyle="None" runat="server">
                    <Columns>
                        <asp:BoundField DataField="productDescription" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label runat="server" Text=" : "></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="postTax" />
                    </Columns>
                </asp:GridView>
            </p>
            <br />
            <p>Sales Taxes: <asp:Label ID="lblSalesTaxes" runat="server" Text=""></asp:Label></p>
            <br />
            <p>Total: <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></p>
        </div>
    </form>
</body>
</html>
