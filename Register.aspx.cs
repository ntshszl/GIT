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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (InputID.Text == "" || FirstName.Text == "" || LastName.Text == "" || InputPassword.Text == "" || RepeatPassword.Text == "")
            {
                Response.Write("<script> alert('Please fill all blanks'); </script>");
                Server.Transfer("Register.aspx");
            }

            else
            {
                SqlConnection con = new SqlConnection("Data Source=HMSB-M1LGPT0698\\SQLEXPRESS;Initial Catalog=git; Persist Security Info=True; User ID=Git;Password=Honda12345");

                bool exists = false;

                using (SqlCommand cmd = new SqlCommand("CheckUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@staffID", InputID.Text.Trim());
                    con.Open();
                    exists = Convert.ToBoolean(cmd.ExecuteScalar());


                    // if exists, show a message error
                    if (exists)
                    {
                        Response.Write("<script> alert('Staff ID is already registered'); </script>");
                        Server.Transfer("Register.aspx");
                        con.Close();
                    }

                    else if (InputPassword.Text.Length < 9)
                    {
                        Response.Write("<script> alert('Password must be more than 8 characters'); </script>");
                        Server.Transfer("Register.aspx");
                    }

                    else
                    {
                        // does not exists, so, persist the user
                        SqlCommand cmd2 = new SqlCommand("UserAdd", con);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@staffID", InputID.Text.Trim());
                        cmd2.Parameters.AddWithValue("@firstname", FirstName.Text.Trim());
                        cmd2.Parameters.AddWithValue("@lastname", LastName.Text.Trim());
                        cmd2.Parameters.AddWithValue("@password", InputPassword.Text.Trim());
                        cmd2.Parameters.AddWithValue("@repeatpassword", RepeatPassword.Text.Trim());

                        if (InputPassword.Text == RepeatPassword.Text)
                        {
                            int i = cmd2.ExecuteNonQuery();
                            con.Close();

                            if (i > 0)
                            {
                                Response.Write("<script> alert('Registered Sucessfully'); </script>");
                                Server.Transfer("Login.aspx");
                            }
                            con.Close();
                        }

                        else
                        {
                            Response.Write("<script> alert('Password and repeat password are not match'); </script>");
                            Server.Transfer("Register.aspx");
                        }
                    }
                }
            }

        }
    }
}