using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Combat
{
    public partial class Form_Win : Form
    {
        public Form_Win()
        {
            InitializeComponent();
        }

        public Form_Win(int win_player)
        {
            InitializeComponent();

            if (win_player == 0)
            {
                labelWin.Text = "Red Player Win!";
            }
            else
            {
                labelWin.Text = "Black Player Win!";
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
