﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FriishProduce
{
    public partial class Wait : Form
    {
        public Wait()
        {
            InitializeComponent();
            Program.Lang.String("busy", "projectform");
        }
    }
}
