using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSimManagement
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Register a new user to the database and also checks for the duplicate username.
        /// </summary>
        /// <param name="sender">The button is the sender object</param>
        /// <param name="e">The event argument for the button click event</param>
        protected void RegisterUser_Click(object sender, EventArgs e)
        {
            try
            {
                // Creates a new user or gives an exception when there is username conflict.
                MembershipUser newUser = Membership.CreateUser(txtUsername.Text, txtPassword.Text, txtEmail.Text);
            }
            catch(MembershipCreateUserException me)
            {
                lblMessage.Text = GetErrorMessage(me.StatusCode);
            }

            if (Page.IsPostBack)
            {
                txtUsername.Text = string.Empty;
                txtEmail.Text = string.Empty;
                Response.Redirect("UserLogin.aspx");
            }
        }

        /// <summary>
        /// Display the error message while creating a new user
        /// </summary>
        /// <param name="membershipCreateStatus">gives the exception status code</param>
        /// <returns>returns string value</returns>
        private string GetErrorMessage(MembershipCreateStatus membershipCreateStatus)
        {
            switch (membershipCreateStatus)
            {
                    //When the user enter a duplicate username
                case MembershipCreateStatus.DuplicateUserName:
                    return "The username is not valid. Please enter a different username.";

                    // When the error occurs due to server disconnected or at the server side.
                default:
                    return "An unknown error occured/ Please verify your entry and try again.";
            }
        }
    }
}