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

public partial class AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User
        if (Session["UserID"] == null)
            Response.Redirect("~/AdminPanel/Login.aspx");
        #endregion

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ContactCategoryID"] == null)
            {
                lblPageHeader.Text = "Contact Category Add";
            }
            else
            {
                lblPageHeader.Text = "Contact Category Edit";
                FillContactCategoryForm(Convert.ToInt32(Request.QueryString["ContactCategoryID"].ToString().Trim()));
            }
        }
    }
    #endregion
    
    #region Fill Contact Category Form
    private void FillContactCategoryForm(SqlInt32 ContactCategoryID)
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
                    objCmd.CommandText = "PR_ContactCategory_SelectByPKUserID";

                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"].ToString().Trim();
                    objCmd.Parameters.Add("@ContactCategoryID", SqlDbType.Int).Value = ContactCategoryID;

                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if (objSDR.HasRows)
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ContactCategoryName"].Equals(DBNull.Value))
                                    txtContactCategoryName.Text = objSDR["ContactCategoryName"].ToString().Trim();
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

    #region Button: Cancel Contact Category
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
    }
    #endregion

    #region Button: Save Contact Category
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region Local Vairable
        string strConnection = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        string strError = "";
        SqlString ContactCategoryName = SqlString.Null;
        #endregion

        #region Server Validation
        if (txtContactCategoryName.Text.Trim() == "")
            strError += "Enter Contact Category";

        if (strError.Trim() != "")
        {
            lblErrorMessage.Text = strError;
            return;
        }
        #endregion

        #region Assign Value
        if (txtContactCategoryName.Text.Trim() != "")
            ContactCategoryName = txtContactCategoryName.Text.Trim();
        #endregion

        #region Save Data
        using (SqlConnection objConn = new SqlConnection(strConnection))
        {
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    objCmd.CommandType = CommandType.StoredProcedure;

                    if(Request.QueryString["ContactCategoryID"] == null)
                    {
                        objCmd.CommandText = "PR_ContactCategory_InsertByUserID";
                    }
                    else
                    {
                        objCmd.CommandText = "PR_ContactCategory_UpdateByPKUserID";
                        objCmd.Parameters.Add("@ContactCategoryID", SqlDbType.Int).Value = Request.QueryString["ContactCategoryID"].ToString().Trim();
                    }

                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"].ToString().Trim();
                    objCmd.Parameters.Add("@ContactCategoryName", SqlDbType.VarChar).Value = ContactCategoryName;

                    objCmd.ExecuteNonQuery();

                    if (Request.QueryString["ContactCategoryID"] == null)
                    {
                        lblSuccess.Text = "Data Insert Successfully";
                        txtContactCategoryName.Text = "";
                        txtContactCategoryName.Focus();
                    }
                    else
                    {
                        Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
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