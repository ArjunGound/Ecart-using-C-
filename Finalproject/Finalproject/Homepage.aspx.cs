using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Finalproject
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    MultiView1.ActiveViewIndex = 0;
            //    string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            //    using (SqlConnection con = new SqlConnection(cs))
            //    {
            //        string query = "select product_name,product_price from product_detials";
            //        SqlDataAdapter da = new SqlDataAdapter(query, con);
            //        DataSet ds = new DataSet();
            //        da.Fill(ds);
            //        gvguest.DataSource = ds;
            //        gvguest.DataBind();

            //    }
            //}
            //BindGrid();
        }
       
        //protected void registorbutton_Click(object sender, EventArgs e)
        //{
        //    MultiView1.ActiveViewIndex = 1;
        //}

       

        protected void adminloginbutton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Adminpage.aspx");
        }

        protected void loginbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtusername.Text) && string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                lblusernamevalidation.Text = "*";
                lblpasswordvalidation.Text = "*";
            }
            else
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                string checkcommand = "select * from arjun_user_registor where user_name=@username AND password=@password";
                SqlCommand cmd = new SqlCommand(checkcommand, con);
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    Response.Redirect("~/Userhomecartpage.aspx?username=" + Server.UrlEncode(txtusername.Text));
                }
                else
                {
                    lblloginmessage.Text = "User Not Exits Please Register!!";
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Guestwelcomepage.aspx");
        }

        //protected void guestallproductbutton_Click(object sender, EventArgs e)
        //{
        //    string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        string query = "select product_name,product_price from product_detials";
        //        SqlDataAdapter da = new SqlDataAdapter(query, con);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds);
        //        gvguest.DataSource = ds;
        //        gvguest.DataBind();

        //    }
        //    ddlguestfliter.SelectedIndex = -1;
        //}
    }
}