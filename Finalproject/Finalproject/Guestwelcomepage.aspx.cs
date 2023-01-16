using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Finalproject
{
    public partial class Guestwelcomepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
        private void BindGrid()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
                if (ddlguestfliter.SelectedValue == "0")
                {
                    string queryall = "select product_name as ProductName,product_price as Price from product_detials";
                    SqlDataAdapter daselectall = new SqlDataAdapter(queryall,con);
                    DataSet dsall = new DataSet();
                    daselectall.Fill(dsall);
                    gvguest.DataSource = dsall;
                    gvguest.DataBind();
                }
             else{
                string query = "select product_name as ProductName,product_price as Price from product_detials where catogory_id=@sorting_id";
                SqlCommand cmd2 = new SqlCommand(query, con);
                con.Open();
                cmd2.Parameters.AddWithValue("@sorting_id", ddlguestfliter.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataSet ds = new DataSet();
                da.Fill(ds, "product_detials");
                //Cache.Insert("DATASET", da, null, DateTime.Now.AddHours(24),
                //    System.Web.Caching.Cache.NoSlidingExpiration);
                gvguest.DataSource = ds;
                gvguest.DataBind();
            }

            }
        protected void loginbutton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Homepage.aspx");
        }

        protected void registorbutton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registerpage.aspx");
        }
    }
}