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
    public partial class Userhomecartpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*string conString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                string query = "SELECT product_id,product_name,product_price FROM product_detials";
                SqlCommand cmd = new SqlCommand(query);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        gvProducts.DataSource = dt;
                        gvProducts.DataBind();
                    }
                }*/
                lblquerystringname.Text = Request.QueryString["username"];
            }
            BindGrid();
        }
        private void BindGrid()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "select product_id,product_name,product_price from product_detials where catogory_id=@sorting_id";
                SqlCommand cmd2 = new SqlCommand(query, con);
                con.Open();
                cmd2.Parameters.AddWithValue("@sorting_id", ddlusercartsorting.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataSet ds = new DataSet();
                da.Fill(ds, "product_detials");
                Cache.Insert("DATASET", da, null, DateTime.Now.AddHours(24),
                    System.Web.Caching.Cache.NoSlidingExpiration);
                gvProducts.DataSource = ds;
                gvProducts.DataBind();

            }
        }
        protected void getcartupdate()
        {
            string username = Request.QueryString["username"];
            string conString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            string query = "SELECT sum(productprice) as Total_amount FROM productcartamount where usercartname =@username";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@username", username);
            con.Open();
            cmd.ExecuteNonQuery();
            using (SqlDataReader datareader = cmd.ExecuteReader())
            {
                datareader.Read();
                txttotalprice.Text = datareader["Total_amount"].ToString();

            }
            con.Close();
        }
        /*  protected void getproducts()
          {
              string username = Request.QueryString["username"];
              string conString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
              SqlConnection con = new SqlConnection(conString);
              string query = "SELECT productname FROM productcartamount where usercartname =@username";
              SqlCommand cmd = new SqlCommand(query, con);
              con.Open();
              cmd.Parameters.AddWithValue("@username", username);
              cmd.ExecuteNonQuery();
             /* using (SqlDataReader datareader = cmd.ExecuteReader())
              {
                  datareader.Read();
                  txttotalproducts.Text = datareader["productname"].ToString();

              }
              con.Close();
          }*/

        protected void gvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow row = gvProducts.SelectedRow;
            txtproductname.Text = row.Cells[0].Text;
            txtproductprice.Text = row.Cells[1].Text;
            string username = Request.QueryString["username"];
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            string qry = "insert into productcartamount values(@productname,@productprice,@usrename)";
            SqlCommand cmd = new SqlCommand(qry, con);
            con.Open();
            cmd.Parameters.AddWithValue("@productname", txtproductname.Text);
            cmd.Parameters.AddWithValue("@productprice", txtproductprice.Text);
            cmd.Parameters.AddWithValue("@usrename", username);
            cmd.ExecuteNonQuery();
            con.Close();
            lblfinalamount.ForeColor = System.Drawing.Color.Green;
            lblfinalamount.Text = "Products Added Successfull";
        }

        protected void deleteproductbutton_Click(object sender, EventArgs e)
        {

            string username = Request.QueryString["username"];
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            string deleteproduct = "delete from productcartamount where usercartname=@username";
            SqlCommand cmd = new SqlCommand(deleteproduct, con);
            con.Open();
            cmd.Parameters.AddWithValue("@username", username);
            cmd.ExecuteNonQuery();
            con.Close();
            txtproductname.Text = "";
            txtproductprice.Text = "";
            txttotalprice.Text = "";
            // txttotalproducts.Text = "";
            lblfinalamount.ForeColor = System.Drawing.Color.Red;
            lblfinalamount.Text = "Products Removed";
        }

        protected void userlogoutbutton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Homepage.aspx");
        }

        protected void userrefreshbutton_Click(object sender, EventArgs e)
        {

            getcartupdate();
            //getproducts();
        }

        protected void userallproductshownbutton_Click(object sender, EventArgs e)
        {
            string username = Request.QueryString["username"];
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string details = "select productname,productprice from productcartamount where usercartname=@username";
            SqlCommand cmd = new SqlCommand(details, con);
            cmd.Parameters.AddWithValue("@username", username);
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "productcartamount");
            gvusercartshown.DataSource = ds;
            gvusercartshown.DataBind();
        }

        //protected void gvProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    int productId = Convert.ToInt32(gvProducts.DataKeys[e.RowIndex].Values[0]);
        //    string constr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("DELETE FROM product_detials WHERE product_id = @product_id", con))
        //        {
        //            cmd.Parameters.AddWithValue("@product_id", productId);
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //    }
        //}

        protected void gvusercartshown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}