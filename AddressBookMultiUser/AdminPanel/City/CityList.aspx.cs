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

public partial class AdminPanel_City_CityList : System.Web.UI.Page
{
    #region Load Page
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User
        if (Session["UserID"] == null)
            Response.Redirect("~/AdminPanel/Login.aspx");
        #endregion

        if (!Page.IsPostBack)
        {
            FillGridViewCity();
        }
    }
    #endregion

    #region Fill City Grid View
    private void FillGridViewCity()
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
                    objCmd.CommandText = "PR_City_SelectAllByUserID";

                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"].ToString().Trim();

                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if (objSDR.HasRows)
                        {
                            gvCity.DataSource = objSDR;
                            gvCity.DataBind();
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

    #region Delete City 
    private void DeleteCity(SqlInt32 CityID)
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
                    objCmd.CommandText = "PR_City_DeleteByPKUserID";

                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"].ToString().Trim();
                    objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID;

                    objCmd.ExecuteNonQuery();
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

    #region Button: Add City
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/City/CityAddEdit.aspx");
    }
    #endregion
    
    #region Button: Delete Edit Record
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                DeleteCity(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                FillGridViewCity();
            }
        }
        else if (e.CommandName == "EditRecord")
        {
            if(e.CommandArgument != null)
                Response.Redirect(e.CommandArgument.ToString().Trim());
        }
    }
    #endregion
}