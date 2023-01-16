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
    public partial class Adminpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiViewadmin.ActiveViewIndex = 0;

            }
            BindGrid();
            }
        private void BindGrid()
        { 
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "select * from product_detials where catogory_id=@sorting_id";
                SqlCommand cmd2 = new SqlCommand(query, con);
                con.Open();
                cmd2.Parameters.AddWithValue("@sorting_id", ddladminsorting.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataSet ds = new DataSet();
                da.Fill(ds, "product_detials");
                Cache.Insert("DATASET", da, null, DateTime.Now.AddHours(24),
                    System.Web.Caching.Cache.NoSlidingExpiration);
                gvadmin.DataSource = ds;
                gvadmin.DataBind();

        }
}
        protected void gvadmin_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productId = Convert.ToInt32(gvadmin.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM product_detials WHERE product_id = @product_id", con))
                {
                    cmd.Parameters.AddWithValue("@product_id", productId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();

        }
       /* protected void gvadmin_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvadmin.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvadmin_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int productId = Convert.ToInt32(gvadmin.DataKeys[e.RowIndex].Values[0]);
            string productname = Convert.ToString(gvadmin.DataKeys[e.RowIndex].Values[1]);
            float productprice = (float)Convert.ToInt32(gvadmin.DataKeys[e.RowIndex].Values[2]);
            string constr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
 using (SqlCommand cmd = new SqlCommand("update product_detials set product_name=@productname,product_price=@price where  product_id=@productid", con))
 {
     cmd.Parameters.AddWithValue("@productname", productname);
     cmd.Parameters.AddWithValue("@price", productprice);
                    cmd.Parameters.AddWithValue("@product_id", productId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
        }

        protected void gvadmin_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvadmin.EditIndex = -1;
            BindGrid();
        }*/
        protected void onrowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gvadmin.EditIndex)
            {
                (e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }
        protected void adminlogoutbutton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Homepage.aspx");
        }

        protected void adminloginbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtadminname.Text) && string.IsNullOrWhiteSpace(txtadminpassword.Text))
            {
                lbladminname.Text = "*";
                lbladminpass.Text = "*";
            }
            else
            {
                if (txtadminname.Text == "arjun" && txtadminpassword.Text == "arjun123")
                {
                    MultiViewadmin.ActiveViewIndex = 1;
                    
                }
                else
                {
                    lbladmin.ForeColor = System.Drawing.Color.Red;
                    lbladmin.Text = "Invalid Login credential!";
                }
            }

        }

        protected void logoutbutton_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Homepage.aspx");
        }

        protected void AddNewProductbutton_Click(object sender, EventArgs e)
        {
            MultiViewadmin.ActiveViewIndex = 2;
                    
        }

        protected void Backbutton_Click(object sender, EventArgs e)
        {
            MultiViewadmin.ActiveViewIndex = 1;
            lbladdproduct.Text = "";
        }

        protected void insertbutton_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string insertqurey = "insert into product_detials values(@produvtname,@productprice,@productid)";
                SqlCommand cmd = new SqlCommand(insertqurey, con);
                con.Open();
                if (string.IsNullOrWhiteSpace(txtproductname.Text) || string.IsNullOrWhiteSpace(txtproductprice.Text) || Convert.ToInt16(ddladdproduct.SelectedValue) == 0)
                {
                    lbladdproduct.ForeColor = System.Drawing.Color.Red;
                    lbladdproduct.Text = "Please Enter valid product";
                }
                else
                {
                    cmd.Parameters.AddWithValue("@produvtname", txtproductname.Text);
                    cmd.Parameters.AddWithValue("@productprice", txtproductprice.Text);
                    cmd.Parameters.AddWithValue("@productid", ddladdproduct.SelectedValue);
                    cmd.ExecuteNonQuery();
                    lbladdproduct.ForeColor = System.Drawing.Color.Green;
                    lbladdproduct.Text = "product is added";
                    con.Close();
                }

            }
        }

        //Admin update existing product price code below:
        protected void gvadmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvadmin.SelectedRow;
                txtpriceupdate.Text=row.Cells[4].Text;
                txtproductidinvisible.Text = row.Cells[2].Text;
                txtproductnameupdate.Text = row.Cells[3].Text;
            
           
        }

        protected void priceupdatebutton_Click(object sender, EventArgs e)
        {
           string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
           SqlConnection con = new SqlConnection(cs);
           string updatecommand = "update product_detials set product_name=@newproductname, product_price=@newprice where product_id=@selectedproductid";
           try
           {
               SqlCommand cmd = new SqlCommand(updatecommand, con);
               con.Open();
               cmd.Parameters.AddWithValue("@newprice", txtpriceupdate.Text);
               cmd.Parameters.AddWithValue("@selectedproductid", txtproductidinvisible.Text);
               cmd.Parameters.AddWithValue("@newproductname", txtproductnameupdate.Text);
               cmd.ExecuteNonQuery();
               con.Close();
               BindGrid();
           }
           catch (SqlException)
           {
               Response.Write("DO NOT CLICK UPDATE BUTTON WITH EMPTY FIELD");
           }
           catch (Exception)
           {
               Response.Write("Something Went Wrong Please try again later");
           }

        }
    }
}