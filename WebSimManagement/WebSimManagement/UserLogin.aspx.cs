using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSimManagement
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// It check the username,password and refer the user to the dashboard page,else return an error message
        /// </summary>
        /// <param name="sender">The button is the sender object</param>
        /// <param name="e">The event argument for the button click event</param>
        protected void Login_Click(object sender, EventArgs e)
        {
            bool isLogin = Membership.ValidateUser(txtUsername.Text, txtPassword.Text);

            if (isLogin)
            {
                FormsAuthentication.SetAuthCookie(txtUsername.Text, true);
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                lblMessage.Text = "The username and/or password is incorrect.Please enter correct credentials.";
            }

            if (Page.IsPostBack)
            {
                txtUsername.Text = string.Empty;
                rememberMe.Checked = false;
            }
        }

        /// <summary>
        /// It cancels the process and return the user to the login page
        /// </summary>
        /// <param name="sender">The button is the sender object</param>
        /// <param name="e">The event argument for the button click event</param>
        //protected void LoginCancel_Click(object sender, EventArgs e)
        //{
        //    txtUsername.Text = string.Empty;
        //    rememberMe.Checked = false;
        //}
    }
}