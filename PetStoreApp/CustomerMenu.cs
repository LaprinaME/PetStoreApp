﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetStoreApp
{
    public partial class CustomerMenu : Form
    {
        public static CustomerMenu Instance { get; } = new CustomerMenu();

        public CustomerMenu()
        {
            InitializeComponent();
        }

        private void CustomerMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
