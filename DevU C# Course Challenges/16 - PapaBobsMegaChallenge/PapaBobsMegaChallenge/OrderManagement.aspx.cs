using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PapaBobsMegaChallenge
{
    public partial class OrderManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            refreshGridView();
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView.Rows[index];
            var value = row.Cells[1].Text.ToString();
            var orderId = Guid.Parse(value);

            PapaBobs.Domain.OrderManager.CompleteOrder(orderId);

            refreshGridView();
        }
        
        private void refreshGridView()
        {
            var orders = PapaBobs.Domain.OrderManager.GetOrders();
            GridView.DataSource = orders;
            GridView.DataBind();
        }
    }
}