using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG
{
    public partial class Form1 : Form
    {
        public GLClass view;
        public Form1()
        {
            InitializeComponent();
            view = new GLClass();
            view.Parent = this;
            view.Dock = DockStyle.Fill;
            view.Show();

        }
    }
}
