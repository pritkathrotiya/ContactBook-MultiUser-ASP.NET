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

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
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
            if (Request.QueryString["CountryID"] == null)
            {
                lblPageHeader.Text = "Country Add";
            }
            else
            {
                lblPageHeader.Text = "Country Edit";
                FillCountryForm(Convert.ToInt32(Request.QueryString["CountryID"].ToString().Trim()));
            }
        }
    }
    #endregion

    #region Fill Country Form
    private void FillCountryForm(SqlInt32 CountryID)
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
                    objCmd.CommandText = "PR_Country_SelectByPKUserID";

                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"].ToString().Trim();
                    objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = CountryID;

                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if (objSDR.HasRows)
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["CountryName"].Equals(DBNull.Value))
                                    txtCountryName.Text = objSDR["CountryName"].ToString().Trim();

                                if (!objSDR["CountryCode"].Equals(DBNull.Value))
                                    txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
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

    #region Button: Cancel Country
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
    }
    #endregion
    
    #region Button: Save Country
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region Local Vairable
        string strConnection = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        string strError = "";
        SqlString CountryName = SqlString.Null;
        SqlString CountryCode = SqlString.Null;
        #endregion

        #region Server Validation
        if (txtCountryName.Text.Trim() == "")
            strError += "Enter Country Name+</br>";

        if (txtCountryCode.Text.Trim() == "")
            strError += "Enter Country Code";

        if (strError.Trim() != "")
        {
            lblErrorMessage.Text = strError;
            return;
        }
        #endregion

        #region Assign Value
        if (txtCountryName.Text.Trim() != "")
            CountryName = txtCountryName.Text.Trim();

        if (txtCountryCode.Text.Trim() != "")
            CountryCode = txtCountryCode.Text.Trim();
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

                    if (Request.QueryString["CountryID"] == null)
                    {
                        objCmd.CommandText = "PR_Country_InsertByUserID";
                    }
                    else
                    {
                        objCmd.CommandText = "PR_Country_UpdateByPKUserID";
                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = Request.QueryString["CountryID"].ToString().Trim();
                    }

                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"].ToString().Trim();
                    objCmd.Parameters.Add("@CountryName", SqlDbType.VarChar).Value = CountryName;
                    objCmd.Parameters.Add("@CountryCode", SqlDbType.VarChar).Value = CountryCode;

                    objCmd.ExecuteNonQuery();

                    if (Request.QueryString["CountryID"] == null)
                    {
                        lblSuccess.Text = "Data Insert Successfully";
                        txtCountryName.Text = "";
                        txtCountryCode.Text = "";
                        txtCountryName.Focus();
                    }
                    else
                    {
                        Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
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