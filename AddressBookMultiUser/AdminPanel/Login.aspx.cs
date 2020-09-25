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

public partial class Admin_Login : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region LinkButton: Register User
    protected void lbRegisterUser_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Registration.aspx");
    }
    #endregion

    #region Button: Login
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        #region Local Vairable
        string strConnection = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        string strError = "";
        SqlString Username = SqlString.Null;
        SqlString Password = SqlString.Null;
        #endregion

        #region Server Validation
        if (txtUsername.Text.Trim() == "")
            strError += "Enter Username +</br>";

        if (txtPassword.Text.Trim() == "")
            strError += "Enter Password +</br>";

        if (strError.Trim() != "")
        {
            lblErrorMessage.Text = strError;
            return;
        }
        #endregion

        #region Assign Value
        if (txtUsername.Text.Trim() != "")
            Username = txtUsername.Text.Trim();

        if (txtPassword.Text.Trim() != "")
            Password = txtPassword.Text.Trim();
        #endregion

        #region Save Date
        using (SqlConnection objConn = new SqlConnection(strConnection))
        {
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    objCmd.CommandType = CommandType.StoredProcedure;

                    objCmd.CommandText = "PR_UserDetails_SelectByUserNamePassword";

                    objCmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = Username;
                    objCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;

                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if(objSDR.HasRows)
                        {
                            while(objSDR.Read())
                            {
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                    Session["UserID"] = objSDR["UserID"].ToString().Trim();

                                if (!objSDR["DisplayName"].Equals(DBNull.Value))
                                    Session["DisplayName"] = objSDR["DisplayName"].ToString().Trim();

                                Response.Redirect("~/AdminPanel/Home.aspx");
                            }
                        }
                        else
                        {
                            lblErrorMessage.Text = "Username or Password does not match";
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
        #endregion
    }
    #endregion
}