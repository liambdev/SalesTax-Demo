using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SalesTax.Code;
using SalesTax.Models;

namespace SalesTax
{
    public partial class BuildReceipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Create an instance of receipt and store in session
                Session["Receipt"] = new Receipt();

                PopulateFields(new Receipt());

            }
        }

        private void PopulateFields(Receipt receipt)
        {
            txtPrice.Text = null;
            txtProdDesc.Text = null;
            
            // Get product type values
            List<KeyValuePair<bool, string>> prodTypes = GlobalMethods.GetProdTypes();
            ddlProdType.DataSource = prodTypes;
            ddlProdType.DataTextField = "Value";
            ddlProdType.DataValueField = "Key";
            ddlProdType.DataBind();

            chkImport.Checked = false;

            RefreshBasket(receipt);
        }

        protected void btnAddProd_Click(object sender, EventArgs e)
        {
            // Pull back receipt object from session state
            Receipt receipt = (Receipt)Session["Receipt"];

            Product prod = new Product();

            // populate fields from form
            prod.productDescription = txtProdDesc.Text;
            prod.preTax = Convert.ToDecimal(txtPrice.Text);
            prod.basicTax = Convert.ToBoolean(ddlProdType.SelectedValue);

            if (chkImport.Checked)
                prod.importTax = true;

            // Add the product to the receipt (and work out any tax values)
            receipt.AddProduct(prod);

            // Refresh the basket on the page
            RefreshBasket(receipt);

            ClearSelections();

            // Save object back to session state
            Session["Receipt"] = receipt;
        }

        private void ClearSelections()
        {
            txtPrice.Text = null;
            txtProdDesc.Text = null;
            chkImport.Checked = false;
            ddlProdType.SelectedIndex = 0;

            // As a product has been added, display the new receipt button and print button
            if (btnNewReceipt.Visible == false)
                btnNewReceipt.Visible = true;

            if (btnPrintReceipt.Visible == false)
                btnPrintReceipt.Visible = true;
        }

        protected void RefreshBasket(Receipt receipt)
        {
            //re-bind the grid view so new product is displayed
            gvProds.DataSource = receipt.products;
            gvProds.DataBind();
            lblSalesTaxes.Text = receipt.totalTax.ToString("0.#0");
            lblTotal.Text = receipt.grandTotal.ToString("0.#0");
        }

        protected void btnNewReceipt_Click(object sender, EventArgs e)
        {
            // Create an instance of receipt and store in session
            Session["Receipt"] = new Receipt();
            PopulateFields(new Receipt());

            // hide buttons
            btnNewReceipt.Visible = false;
            btnPrintReceipt.Visible = false;
        }

        protected void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrintReceipt.aspx");
        }
    }
}