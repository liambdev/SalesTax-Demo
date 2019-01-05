using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SalesTax.Models;

namespace SalesTax
{
    public partial class PrintReceipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Pull back receipt from session and populate relevant fields, etc
                Receipt receipt = (Receipt)Session["Receipt"];
                gvProds.DataSource = receipt.products;
                gvProds.DataBind();
                lblSalesTaxes.Text = receipt.totalTax.ToString("0.#0");
                lblTotal.Text = receipt.grandTotal.ToString("0.#0");
            }
        }
    }
}