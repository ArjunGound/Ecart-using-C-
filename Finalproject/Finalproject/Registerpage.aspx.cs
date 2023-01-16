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
    public partial class Registerpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Submitbutton_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {

                    string command = "insert into arjun_user_registor values(@firstname,@lastname,@age,@gender,@gmail,@username,@password)";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@firstname", txtfirstname.Text);
                    cmd.Parameters.AddWithValue("@lastname", txtlastname.Text);
                    cmd.Parameters.AddWithValue("@age", txtage.Text);
                    cmd.Parameters.AddWithValue("@gender", ddlgender.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@gmail", txtgmail.Text);
                    cmd.Parameters.AddWithValue("@username", txtinsertusername.Text);
                    cmd.Parameters.AddWithValue("@password", txtinsertpassword.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lblmessage.ForeColor = System.Drawing.Color.Green;
                    lblmessage.Text = "Registor Successfull";
                    //MultiView1.ActiveViewIndex = 0;

                }
            }
            catch (SqlException)
            {
                lblmessage.ForeColor = System.Drawing.Color.Red;
                lblmessage.Text = "Username or EmailId already exits please try different username or EmailId";
            }
            catch (Exception)
            {
                lblmessage.ForeColor = System.Drawing.Color.Red;
                lblmessage.Text = "Something Went Wrong Please try Later";
            }
            Response.Redirect("~/Homepage.aspx");
        }

    }
}