using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace _Git_
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (InputID.Text == "" || Password.Text == "")
            {
                Response.Write("<script> alert('Please fill all blanks'); </script>");
            }

            else
            {
                SqlConnection con = new SqlConnection("Data Source=HMSB-M1LGPT0698\\SQLEXPRESS;Initial Catalog=git; Persist Security Info=True; User ID=Git;Password=Honda12345");
                String id = InputID.Text.Trim();
                String password = Password.Text.Trim();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Staff where staffID ='" + InputID.Text + "' AND password = '" + Password.Text + "'", con);
                con.Open();
                cmd.Parameters.AddWithValue("@staffID", InputID.Text.Trim());
                cmd.Parameters.AddWithValue("@password", Password.Text.Trim());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Session["id"] = id;
           
                    if (Session["id"] != null)
                    {
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                    }
                    ClientScript.RegisterStartupScript(Page.GetType(), "Validation", "<script language='javascript>alert('Successfully Login')</script>");
                    
                    


                }
                else
                {
                    Response.Write("<script> alert('Invalid StaffID or password'); </script>");
                    Server.Transfer("Login.aspx");
                }
            }
        }
    }
}