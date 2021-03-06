﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PropertyLibrary;
using System.Drawing;
using System.Text;


namespace _3342FinalProject
{
    public partial class Signup : System.Web.UI.Page
    {
        Utility utility;
        protected void Page_Load(object sender, EventArgs e)
        {
            utility = new Utility();
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            String[] fields = { txtAddress.Text, txtBilling.Text, txtEmail.Text, txtPw1.Text, txtPw2.Text, txtSecurity1.Text, txtSecurity2.Text, txtSecurity3.Text, txtUsername.Text };
            //check all fields for blanks
            if (rbType.SelectedIndex != -1 && !utility.isNullOrEmpty(fields))
            {
                utility.PrintToDebug("TRUE", "validation");
                //Check if username is taken
                if (utility.CheckUserNameTaken(txtUsername.Text))
                {
                    lblError.Visible = true;
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "This Username is taken, try another";
                    return;
                }
                if (txtUsername.Text.Length >= 50)
                {
                    lblError.Visible = true;
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "Username must be less than 50 characters long";
                    return;
                }
                if (!String.Equals(txtPw1.Text, txtPw2.Text))
                {
                    lblError.Visible = true;
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "Passwords do not match";
                    return;
                }
                if(txtPw1.Text.Length < 6)
                {
                    lblError.Visible = true;
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "Password must be at least 6 characters long";
                    return;
                }
                if (txtPw1.Text.Length >= 50)
                {
                    lblError.Visible = true;
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "Password must be less than 50 characters long";
                    return;
                }
                if (txtEmail.Text.Length >= 50)
                {
                    lblError.Visible = true;
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "Email must be less than 50 characters long";
                    return;
                }
                if (txtSecurity1.Text.Length >= 50 || txtSecurity2.Text.Length >= 50 || txtSecurity3.Text.Length >= 50)
                {
                    lblError.Visible = true;
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "Security question responses must be less than 50 characters long";
                    return;
                }

                user.UserName = txtUsername.Text;
                user.SecurityAnswers = txtSecurity1.Text + "," + txtSecurity2.Text + "," + txtSecurity3.Text;
                user.UserType = rbType.SelectedIndex;
                user.WalletAmount = 0;
                user.Password = txtPw1.Text;
                user.Address = txtAddress.Text;
                user.BillingAddress = txtBilling.Text;
                user.Email = txtEmail.Text;

                if (utility.AddUser(user.UserName, user.Password, user.SecurityAnswers, user.WalletAmount, user.UserType, user.Email, user.Address, user.BillingAddress))
                {
                    //txtUsername.Visible = false;
                    //txtAddress.Visible = false;
                    //txtBilling.Visible = false;
                    //txtEmail.Visible = false;
                    //txtPw1.Visible = false;
                    //txtPw2.Visible = false;
                    //txtSecurity1.Visible = false;
                    //txtSecurity2.Visible = false;
                    //txtSecurity3.Visible = false;
                    //lblError.Visible = true;                    
                    lblError.ForeColor = Color.Green;
                    lblError.Text = "Account created, please try to login";
                }
                else
                {
                    lblError.Visible = true;
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "Error creating user, please try again";
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.ForeColor = Color.Red;
                lblError.Text = "Please fill out all fields";
            }            
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }        
    }
}