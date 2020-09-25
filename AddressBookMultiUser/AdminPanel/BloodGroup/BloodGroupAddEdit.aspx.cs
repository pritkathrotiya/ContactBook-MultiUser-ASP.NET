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

public partial class AdminPanel_BloodGroup_BloodGroupAddEdit : System.Web.UI.Page
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
            if (Request.QueryString["BloodGroupID"] == null)
            {
                lblPageHeader.Text = "Blood Group Add";
            }
            else
            {
                lblPageHeader.Text = "Blood Group Edit";
                FillBloodGroupForm(Convert.ToInt32(Request.QueryString["BloodGroupID"].ToString().Trim()));
            }
        }
    }
    #endregion
    
    #region Fill Blood Group Form
    private void FillBloodGroupForm(SqlInt32 BloodGroupID)
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
                    objCmd.CommandText = "PR_BloodGroup_SelectByPKUserID";

                    objCmd.Parameters.Add("@BloodGroupID", SqlDbType.Int).Value = BloodGroupID;
                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"].ToString().Trim();

                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if (objSDR.HasRows)
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["BloodGroupName"].Equals(DBNull.Value))
                                    txtBloodGroupName.Text = objSDR["BloodGroupName"].ToString().Trim();
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

    #region Button: Cancel Blood Group
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/BloodGroup/BloodGroupList.aspx");
    }
    #endregion

    #region Button: Save Blood Group
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region Local Variable
        string strConnection = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        string strError = "";
        SqlString BloodGroupName = SqlString.Null;
        #endregion

        #region Server Side Validation
        if (txtBloodGroupName.Text.Trim() == "")
            strError += "Enter Blood Group";

        if (strError.Trim() != "")
        {
            lblErrorMessage.Text = strError;
            return;
        }
        #endregion

        #region Assign Value
        if (txtBloodGroupName.Text.Trim() != "")
            BloodGroupName = txtBloodGroupName.Text.Trim();
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

                    if (Request.QueryString["BloodGroupID"] == null)
                    {
                        objCmd.CommandText = "PR_BloodGroup_InsertByUserID";
                    }
                    else
                    {
                        objCmd.CommandText = "PR_BloodGroup_UpdateByPKUserID";
                        objCmd.Parameters.Add("BloodGroupID", SqlDbType.Int).Value = Request.QueryString["BloodGroupID"].ToString().Trim();
                    }

                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"].ToString().Trim();
                    objCmd.Parameters.Add("@BloodGroupName", SqlDbType.VarChar).Value = BloodGroupName;

                    objCmd.ExecuteNonQuery();

                    if (Request.QueryString["BloodGroupID"] == null)
                    {
                        lblSuccess.Text = "Data Insert Successfully";
                        txtBloodGroupName.Text = "";
                        txtBloodGroupName.Focus();
                    }
                    else
                    {
                        Response.Redirect("~/AdminPanel/BloodGroup/BloodGroupList.aspx");
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