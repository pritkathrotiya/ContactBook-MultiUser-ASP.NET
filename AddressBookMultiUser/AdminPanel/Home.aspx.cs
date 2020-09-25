using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Home : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User
        if (Session["UserID"] == null)
            Response.Redirect("~/AdminPanel/Login.aspx");
        #endregion

        if(!Page.IsPostBack)
        {
            FillHomeForm();
        }
    }
    #endregion

    #region Fill Home Form
    private void FillHomeForm()
    {
        string strConnection = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;

        using (SqlConnection objConn = new SqlConnection(strConnection))
        {
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_UserDetails_SelectByUserID";

                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"].ToString().Trim();

                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if (objSDR.HasRows)
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["Username"].Equals(DBNull.Value))
                                    txtUsername.Text = objSDR["Username"].ToString().Trim();

                                if (!objSDR["Password"].Equals(DBNull.Value))
                                    txtPassword.Text = objSDR["Password"].ToString().Trim();

                                if (!objSDR["DisplayName"].Equals(DBNull.Value))
                                    txtDisplayName.Text = objSDR["DisplayName"].ToString().Trim();

                                if (!objSDR["Address"].Equals(DBNull.Value))
                                    txtAddress.Text = objSDR["Address"].ToString().Trim();

                                if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                    txtMobileNo.Text = objSDR["MobileNo"].ToString().Trim();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
    }
    #endregion
}