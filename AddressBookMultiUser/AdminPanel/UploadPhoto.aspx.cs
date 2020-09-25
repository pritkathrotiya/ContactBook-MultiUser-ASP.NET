using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_UploadPhoto : System.Web.UI.Page
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
            FillContactDropDownList();
        }
    }
    #endregion

    #region Fill Contact Drop Down List
    private void FillContactDropDownList()
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
                    objCmd.CommandText = "PR_Contact_SelectForDropDownListByUserID";

                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"].ToString().Trim();

                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if(objSDR.HasRows)
                        {
                            ddlContact.DataValueField = "ContactID";
                            ddlContact.DataTextField = "ContactName";

                            ddlContact.DataSource = objSDR;
                            ddlContact.DataBind();

                            ddlContact.Items.Insert(0, new ListItem("-- Select Contact --", "-1"));
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

    #region Button: Upload Contact Photo
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if(fuContatcPhoto.HasFile)
        {
            string strPhotoPath = "~/Content/ContactPhoto/";
            string strPhysicalPath = Server.MapPath(strPhotoPath);
            strPhysicalPath += fuContatcPhoto.FileName;

            if (File.Exists(strPhysicalPath))
                File.Delete(strPhysicalPath);

            fuContatcPhoto.SaveAs(strPhysicalPath);

            #region Upload File Path Into SQL
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
                        objCmd.CommandText = "PR_Contact_UploadPhotoPath";

                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"].ToString().Trim();
                        objCmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = Convert.ToInt32(ddlContact.SelectedValue);
                        objCmd.Parameters.Add("@PhotoPath", SqlDbType.VarChar).Value = (strPhotoPath+=fuContatcPhoto.FileName);

                        objCmd.ExecuteNonQuery();

                        ddlContact.SelectedIndex = 0;
                        ddlContact.Focus();
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

            lblSuccess.Text = "File Upload Successfully";
        }
        else
        {
            lblErrorMessage.Text = "Upload Photo";
        }
    }
    #endregion
}