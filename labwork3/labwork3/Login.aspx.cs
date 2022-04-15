using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace labwork3
{
    public partial class Login : System.Web.UI.Page
    {
        private Dictionary<string, string> accounts = new()
        {
            {"account1","12345678"},
            {"account2","qwerty"},
            {"account3","password"}
        };
        protected void Page_Load(object sender, EventArgs e)
        {
           Session.Clear();
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = username_textbox.Text;
            string password = password_textbox.Value.ToString();
            if (accounts.Contains(new KeyValuePair<string, string>(username, password)))
            {
                Session["logined"] = true;
                Response.Redirect("MainPage.aspx");
                
            }
            else
            {
                username_textbox.Text = password_textbox.Value = "";
                Response.Write("<scrip> alert('Enter valid password and login') </script>");
            }
        }
    }
}