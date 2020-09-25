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

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
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
            FillCityDropDownList();
            FillStateDropDownList();
            FillCountyDropDownList();
            FillBloodGroupDropDownList();
            FillContactCategoryDropDownList();

            if (Request.QueryString["ContactID"] == null)
            {
                lblPageHeader.Text = "Contact Add";
            }
            else
            {
                lblPageHeader.Text = "Contact Edit";
                FillContactForm(Convert.ToInt32(Request.QueryString["ContactID"].ToString().Trim()));
            }
        }
    }
    #endregion

    #region Country Selected Index Change
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlCountry.SelectedIndex>0)
        {
            FillStateDropDownListByCountryID(Convert.ToInt32(ddlCountry.SelectedValue));
        }
        else
        {
            FillStateDropDownListByCountryID(-10);
            FillCityDropDownListByStateID(-10);
        }
    }
    #endregion

    #region State Selected Index Change
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedIndex > 0)
        {
            FillCityDropDownListByStateID(Convert.ToInt32(ddlState.SelectedValue));
        }
        else
        {
            FillCityDropDownListByStateID(-10);
        }
    }
    #endregion

    #region Fill Country Drop Down List
    private void FillCountyDropDownList()
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
                    objCmd.CommandText = "PR_Country_SelectForDropDownListByUserID";

                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"].ToString().Trim();

                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        ddlCountry.DataValueField = "CountryID";
                        ddlCountry.DataTextField = "CountryName";

                        ddlCountry.DataSource = objSDR;
                        ddlCountry.DataBind();

                        ddlCountry.Items.Insert(0, new ListItem("-- Select Country --", "-1"));
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
    
    #region Fill State Drop Down List
    private void FillStateDropDownList()
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
                    objCmd.CommandText = "PR_State_SelectForDropDownListByUserID";

                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"].ToString().Trim();

                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        ddlState.DataValueField = "StateID";
                        ddlState.DataTextField = "StateName";

                        ddlState.DataSource = objSDR;
                        ddlState.DataBind();

                        ddlState.Items.Insert(0, new ListItem("-- Select State --", "-1"));
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

    #region Fill State Drop Down List By Country ID
    private void FillStateDropDownListByCountryID(SqlInt32 CountryID)
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
                    objCmd.CommandText = "PR_State_SelectForDropDownListByUserIDCountryID";

                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"].ToString().Trim();
                    objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = CountryID;

                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if(objSDR.HasRows)
                        {
                            ddlState.DataValueField = "StateID";
                            ddlState.DataTextField = "StateName";

                            ddlState.DataSource = objSDR;
                            ddlState.DataBind();

                            ddlState.Items.Insert(0, new ListItem("-- Select State --", "-1"));

                            ddlCity.Items.Clear();
                            ddlCity.Items.Insert(0, new ListItem("-- Select City --", "-1"));
                        }
                        else
                        {
                            ddlState.Items.Clear();
                            ddlState.Items.Insert(0, new ListItem("-- Select State --", "-1"));

                            ddlCity.Items.Clear();
                            ddlCity.Items.Insert(0, new ListItem("-- Select City --", "-1"));
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

    #region Fill City Drop Down List
    private void FillCityDropDownList()
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
                    objCmd.CommandText = "PR_City_SelectForDropDownListByUserID";

                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"].ToString().Trim();

                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        ddlCity.DataValueField = "CityID";
                        ddlCity.DataTextField = "CityName";

                        ddlCity.DataSource = objSDR;
                        ddlCity.DataBind();

                        ddlCity.Items.Insert(0, new ListItem("-- Select City --", "-1"));
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

    #region Fill City Drop Down List By State ID
    private void FillCityDropDownListByStateID(SqlInt32 StateID)
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
                    objCmd.CommandText = "PR_City_SelectForDropDownListByUserIDStateID";

                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"].ToString().Trim();
                    objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = StateID;

                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if(objSDR.HasRows)
                        {
                            ddlCity.DataValueField = "CityID";
                            ddlCity.DataTextField = "CityName";

                            ddlCity.DataSource = objSDR;
                            ddlCity.DataBind();

                            ddlCity.Items.Insert(0, new ListItem("-- Select City --", "-1"));
                        }
                        else
                        {
                            ddlCity.Items.Clear();
                            ddlCity.Items.Insert(0, new ListItem("-- Select City --", "-1"));
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

    #region Fill Blood Group Drop Down List
    private void FillBloodGroupDropDownList()
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
                    objCmd.CommandText = "PR_BloodGroup_SelectForDropDownListByUserID";

                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"].ToString().Trim();

                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        ddlBloodGroup.DataValueField = "BloodGroupID";
                        ddlBloodGroup.DataTextField = "BloodGroupName";

                        ddlBloodGroup.DataSource = objSDR;
                        ddlBloodGroup.DataBind();

                        ddlBloodGroup.Items.Insert(0, new ListItem("-- Select Blood Group --", "-1"));
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

    #region Fill Contact Category Drop Down List
    private void FillContactCategoryDropDownList()
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
                    objCmd.CommandText = "PR_ContactCategory_SelectForDropDownListByUserID";

                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"].ToString().Trim();

                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        ddlContactContactCategory.DataValueField = "ContactCategoryID";
                        ddlContactContactCategory.DataTextField = "ContactCategoryName";

                        ddlContactContactCategory.DataSource = objSDR;
                        ddlContactContactCategory.DataBind();

                        ddlContactContactCategory.Items.Insert(0, new ListItem("-- Select Contact Category --", "-1"));
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

    #region Fill Contact Form
    private void FillContactForm(SqlInt32 ContactID)
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
                    objCmd.CommandText = "PR_Contact_SelectByPKUserID";

                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"].ToString().Trim();
                    objCmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = ContactID;

                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if (objSDR.HasRows)
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ContactName"].Equals(DBNull.Value))
                                    txtContactName.Text = objSDR["ContactName"].ToString().Trim();

                                if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                    txtMobileNo.Text = objSDR["MobileNo"].ToString().Trim();

                                if (!objSDR["Email"].Equals(DBNull.Value))
                                    txtEmail.Text = objSDR["Email"].ToString().Trim();

                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                    ddlCity.SelectedValue = objSDR["CityID"].ToString().Trim();

                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                    ddlState.SelectedValue = objSDR["StateID"].ToString().Trim();

                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                    ddlCountry.SelectedValue = objSDR["CountryID"].ToString().Trim();

                                if (!objSDR["BloodGroupID"].Equals(DBNull.Value))
                                    ddlBloodGroup.SelectedValue = objSDR["BloodGroupID"].ToString().Trim();

                                if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                                    ddlContactContactCategory.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                                
                                if (!objSDR["Address"].Equals(DBNull.Value))
                                    txtAddress.Text = objSDR["Address"].ToString().Trim();
                                
                                if (!objSDR["Pincode"].Equals(DBNull.Value))
                                    txtPincode.Text = objSDR["Pincode"].ToString().Trim();

                                if (!objSDR["BirthDate"].Equals(DBNull.Value))
                                    txtBirthDate.Text = objSDR["BirthDate"].ToString().Trim();

                                if (!objSDR["Gender"].Equals(DBNull.Value))
                                    txtGender.Text = objSDR["Gender"].ToString().Trim();

                                if (!objSDR["Profession"].Equals(DBNull.Value))
                                    txtProfession.Text = objSDR["Profession"].ToString().Trim();
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

    #region Button: Cancel Contact
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");
    }
    #endregion

    #region Button: Save City
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region Local Vairable
        string strConnection = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        string strError = "";

        SqlString ContactName = SqlString.Null;
        SqlString MobileNo = SqlString.Null;
        SqlString Email = SqlString.Null;
        SqlInt32 CityID = SqlInt32.Null;
        SqlInt32 StateID = SqlInt32.Null;
        SqlInt32 CountryID = SqlInt32.Null;
        SqlInt32 BloodGroupID = SqlInt32.Null;
        SqlInt32 ContactCategoryID = SqlInt32.Null;
        SqlString Address = SqlString.Null;
        SqlString Pincode = SqlString.Null;
        SqlDateTime BirthDate = SqlDateTime.Null;
        SqlString Gender = SqlString.Null;
        SqlString Profession = SqlString.Null;
        #endregion

        #region Server Validation
        if (txtContactName.Text.Trim() == "")
            strError += "Enter Contact Name +</br>";

        if (txtMobileNo.Text.Trim() == "")
            strError += "Enter Mobile No +</br>";

        if (txtEmail.Text.Trim() == "")
            strError += "Enter Email +</br>";

        if (strError.Trim() != "")
        {
            lblErrorMessage.Text = strError;
            return;
        }
        #endregion

        #region Assign Value
        if (txtContactName.Text.Trim() != "")
            ContactName = txtContactName.Text.Trim();

        if (txtMobileNo.Text.Trim() != "")
            MobileNo = txtMobileNo.Text.Trim();

        if (txtEmail.Text.Trim() != "")
            Email = txtEmail.Text.Trim();

        if (ddlCity.SelectedIndex != 0)
            CityID = Convert.ToInt32(ddlCity.SelectedValue);

        if (ddlState.SelectedIndex != 0)
            StateID = Convert.ToInt32(ddlState.SelectedValue);

        if (ddlCountry.SelectedIndex != 0)
            CountryID = Convert.ToInt32(ddlCountry.SelectedValue);

        if (ddlBloodGroup.SelectedIndex != 0)
            BloodGroupID = Convert.ToInt32(ddlBloodGroup.SelectedValue);

        if (ddlContactContactCategory.SelectedIndex != 0)
            ContactCategoryID = Convert.ToInt32(ddlContactContactCategory.SelectedValue);

        if (txtAddress.Text.Trim() != "")
            Address = txtAddress.Text.Trim();

        if (txtBirthDate.Text.Trim() != "")
            BirthDate = Convert.ToDateTime(txtBirthDate.Text.Trim());

        if (txtPincode.Text.Trim() != "")
            Pincode = txtPincode.Text.Trim();

        if (txtGender.Text.Trim() != "")
            Gender = txtGender.Text.Trim();

        if (txtProfession.Text.Trim() != "")
            Profession = txtProfession.Text.Trim();
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

                    if (Request.QueryString["ContactID"] == null)
                    {
                        objCmd.CommandText = "PR_Contact_InsertByUserID";
                    }
                    else
                    {
                        objCmd.CommandText = "PR_Contact_UpdateByPKUserID";
                        objCmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = Request.QueryString["ContactID"].ToString().Trim();
                    }

                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"].ToString().Trim();
                    objCmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = ContactName;
                    objCmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = MobileNo;
                    objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
                    objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID;
                    objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = StateID;
                    objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = CountryID;
                    objCmd.Parameters.Add("@BloodGroupID", SqlDbType.Int).Value = BloodGroupID;
                    objCmd.Parameters.Add("@ContactCategoryID", SqlDbType.Int).Value = ContactCategoryID;
                    objCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = Address;
                    objCmd.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = Pincode;
                    objCmd.Parameters.Add("@BirthDate", SqlDbType.DateTime).Value = BirthDate;
                    objCmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = Gender;
                    objCmd.Parameters.Add("@Profession", SqlDbType.VarChar).Value = Profession;

                    objCmd.ExecuteNonQuery();

                    if (Request.QueryString["ContactID"] == null)
                    {
                        lblSuccess.Text = "Data Insert Successfully";
                        txtContactName.Text = "";
                        txtMobileNo.Text = "";
                        txtEmail.Text = "";
                        ddlCity.SelectedIndex = 0;
                        ddlState.SelectedIndex = 0;
                        ddlCountry.SelectedIndex = 0;
                        ddlBloodGroup.SelectedIndex = 0;
                        ddlContactContactCategory.SelectedIndex = 0;
                        txtAddress.Text = "";
                        txtPincode.Text = "";
                        txtBirthDate.Text = "";
                        txtGender.Text = "";
                        txtProfession.Text = "";
                        txtContactName.Focus();
                    }
                    else
                    {
                        Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");
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