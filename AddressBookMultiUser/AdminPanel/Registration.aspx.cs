using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

public partial class Admin_Registration : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region Button: Register User
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        #region Local Vairable
        string strConnection = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        string strError = "";
        SqlString Username = SqlString.Null;
        SqlString Password = SqlString.Null;
        SqlString DisplayName = SqlString.Null;
        SqlString Address = SqlString.Null;
        SqlString MobileNo = SqlString.Null;
        #endregion

        #region Server Validation
        if (txtUsername.Text.Trim() == "")
            strError += "Enter Username +</br>";

        if (txtPassword.Text.Trim() == "")
            strError += "Enter Password +</br>";

        if (txtDisplayName.Text.Trim() == "")
            strError += "Enter Display Name +</br>";

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

        if (txtDisplayName.Text.Trim() != "")
            DisplayName = txtDisplayName.Text.Trim();

        if (txtAddress.Text.Trim() != "")
            Address = txtAddress.Text.Trim();

        if (txtMobileNo.Text.Trim() != "")
            MobileNo = txtMobileNo.Text.Trim();
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

                    objCmd.CommandText = "PR_UserDetails_Insert";

                    objCmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = Username;
                    objCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
                    objCmd.Parameters.Add("@DisplayName", SqlDbType.VarChar).Value = DisplayName;
                    objCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = Address;
                    objCmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = MobileNo;

                    objCmd.ExecuteNonQuery();

                    Response.Redirect("~/AdminPanel/Login.aspx");
                }
            }
            catch(SqlException sqlex)
            {
                if (sqlex.Number == 2627) // Unique constraint error
                    lblErrorMessage.Text = "Username alrday taken";
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

    #region Button: Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Login.aspx");
    }
    #endregion
}