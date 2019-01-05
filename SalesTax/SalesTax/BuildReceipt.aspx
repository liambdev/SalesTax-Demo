<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuildReceipt.aspx.cs" Inherits="SalesTax.BuildReceipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sales Tax</title>
    <link rel="stylesheet" href="~/css/bootstrap.css" type="text/css" />
    <script type="text/javascript" src="~/css/bootstrap.js"></script>
</head>
<body>
    <form id="form1" runat="server">
            <header>
                <div class="navbar navbar-dark bg-dark box-shadow">
                    <div class="container d-flex justify-content-between">
                        <a href="#" class="navbar-brand d-flex align-items-center">
                            <strong>Sales Tax</strong>
                        </a>
                    </div>
                </div>
            </header>

        <div class="container">
            <div class="row">
                <div class="col-sm-8">
                    <br />
                    <div class="row">
                        <div class="col-sm-4">
                            <asp:Label ID="lblProdDesc" runat="server" Text="Product Description"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtProdDesc" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:RequiredFieldValidator ID="rqProdDesc" runat="server" ForeColor="Red" ErrorMessage="Please enter a product description" ControlToValidate="txtProdDesc"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <asp:Label ID="lblPrice" runat="server" Text="Price before tax (£)"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:RequiredFieldValidator ID="rqPrice" runat="server" ForeColor="Red" ErrorMessage="Please enter a price" ControlToValidate="txtPrice"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rgxPrice" runat="server" ForeColor="Red" ErrorMessage="Please enter a valid price" ControlToValidate="txtPrice" ValidationExpression="^\d{0,4}(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <asp:Label ID="lblProdType" runat="server" Text="Product Type"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlProdType" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <asp:Label ID="lblImport" runat="server" Text="Imported?"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:CheckBox ID="chkImport" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <asp:Button ID="btnAddProd" CssClass="btn btn-primary btn-block" runat="server" Text="Add Product to Receipt" OnClick="btnAddProd_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <br />
                    <div class="row">
                        <div class="col-sm-12">
                            <h4>Receipt</h4>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:GridView ID="gvProds" AutoGenerateColumns="false" ShowHeader="false" GridLines="None" BorderStyle="None" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="productDescription" ItemStyle-CssClass="col-sm-10" />
                                    <asp:BoundField DataField="postTax" ItemStyle-CssClass="col-sm-2" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>                    
                    <div class="row">
                        <div class="col-sm-10">
                            <asp:Label ID="lblSalesTaxesLab" Font-Bold="true" runat="server" Text="Sales Taxes (£)"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <asp:Label ID="lblSalesTaxes" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-10">
                            <asp:Label ID="lblTotalLab" Font-Bold="true" runat="server" Text="Total (£)"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-4">
                            <asp:Button ID="btnNewReceipt" CssClass="btn btn-secondary" runat="server" Text="New Receipt" Visible="false" CausesValidation="false" OnClick="btnNewReceipt_Click" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-4">
                            <asp:Button ID="btnPrintReceipt" CssClass="btn btn-secondary" runat="server" Text="Print Receipt" Visible="false" CausesValidation="false" OnClick="btnPrintReceipt_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
