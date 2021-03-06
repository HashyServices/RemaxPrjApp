﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryReax;


namespace RemaxWindowsApp
{
    public partial class frmLogin : Form
    {
        public static Employee employee;
        public static agent;
        public static admin;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            employee = null;
            admin = null;
            agent = null;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            if (email == "")
                labelEmailErr.Text = "*Required email";
            if (password == "")
                labelPasswordErr.Text = "*Required password";
            else
            {
                employee = EmployeeDB.getEmployee(email, password);
                if (employee != null)
                {
                    if (employee.GetType().Equals(typeof(Admin)))
                    {
                        admin = (Admin)employee;
                        MenuRemax(true, true, false, false);
                    }
                    else if (employee.GetType().Equals(typeof(Agent)))
                    {
                        agent = (Agent)employee;
                        MenuRemax(true, false, true, false);
                    }
                    this.Close();
                }
                else
                {
                    labelLoginErr.Text = "*Ivalid email or password.";

                }
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            labelEmailErr.Text = "";
            labelLoginErr.Text = "";
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            labelPasswordErr.Text = "";
            labelLoginErr.Text = "";
        }

        private void MenuRemax(bool menu, bool admin, bool agent, bool user)
        {

            ((frmRemax)this.MdiParent).applicationToolStripMenuItem.Enabled = ((frmRemax)this.MdiParent).managementToolStripMenuItem.Enabled = menu;
            if (admin)
            {
                ((frmRemax)this.MdiParent).housesToolStripMenuItem.Visible = ((frmRemax)this.MdiParent).clientsToolStripMenuItem.Visible = ((frmRemax)this.MdiParent).employeesToolStripMenuItem.Visible = true;
                ((frmRemax)this.MdiParent).agentsToolStripMenuItem.Visible = ((frmRemax)this.MdiParent).loginToolStripMenuItem.Enabled = false;
                ((frmRemax)this.MdiParent).logoutToolStripMenuItem.Enabled = true;
            }
            if (agent)
            {
                ((frmRemax)this.MdiParent).housesToolStripMenuItem.Visible = ((frmRemax)this.MdiParent).clientsToolStripMenuItem.Visible = true;
                ((frmRemax)this.MdiParent).employeesToolStripMenuItem.Visible = ((frmRemax)this.MdiParent).agentsToolStripMenuItem.Visible = ((frmRemax)this.MdiParent).loginToolStripMenuItem.Enabled = false;
                ((frmRemax)this.MdiParent).logoutToolStripMenuItem.Enabled = true;
            }
            if (user)
            {
                ((frmRemax)this.MdiParent).agentsToolStripMenuItem.Visible = ((frmRemax)this.MdiParent).housesToolStripMenuItem.Visible = true;
                ((frmRemax)this.MdiParent).employeesToolStripMenuItem.Visible = ((frmRemax)this.MdiParent).clientsToolStripMenuItem.Visible = false;
                ((frmRemax)this.MdiParent).logoutToolStripMenuItem.Enabled = false;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            MenuRemax(false, false, false, false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MenuRemax(true, false, false, true);
            this.Close();
        }

        private void labelEmail_Click(object sender, EventArgs e)
        {

        }
    }

    public class Employee
    {
    }
}
