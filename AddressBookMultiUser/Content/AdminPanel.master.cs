using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_AdminPanel : System.Web.UI.MasterPage
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            if (Session["DisplayName"] != null)
                lblDisplayName.Text = "Hi! "+Session["DisplayName"].ToString().Trim();
        }
    }
    #endregion

    #region HyperLink: Logout
    protected void lbLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/AdminPanel/Login.aspx");
    }
    #endregion
}
