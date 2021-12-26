using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Projector
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if(bunifuCheckbox1.Checked == true)
            {
                Worker wk = new Worker();
                wk.ShowDialog();
            }

            if (bunifuCheckbox2.Checked == true)
            {
                Worker wk = new Worker();
                wk.ShowDialog();
            }
        }

        private void guna2CustomRadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            bunifuCheckbox2.Checked = false;
            bunifuCheckbox3.Checked = false;
            bunifuCheckbox4.Checked = false;
        }

        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {
            bunifuCheckbox1.Checked = false;
            bunifuCheckbox3.Checked = false;
            bunifuCheckbox4.Checked = false;
        }

        private void bunifuCheckbox3_OnChange(object sender, EventArgs e)
        {
            bunifuCheckbox2.Checked = false;
            bunifuCheckbox1.Checked = false;
            bunifuCheckbox4.Checked = false;
        }

        private void bunifuCheckbox4_OnChange(object sender, EventArgs e)
        {
            bunifuCheckbox2.Checked = false;
            bunifuCheckbox3.Checked = false;
            bunifuCheckbox1.Checked = false;
        }

        private void bunifuCheckbox8_OnChange(object sender, EventArgs e)
        {
            bunifuCheckbox7.Checked = false;
            bunifuCheckbox6.Checked = false;
            bunifuCheckbox5.Checked = false;
        }

        private void bunifuCheckbox7_OnChange(object sender, EventArgs e)
        {
            bunifuCheckbox8.Checked = false;
            bunifuCheckbox6.Checked = false;
            bunifuCheckbox5.Checked = false;
        }

        private void bunifuCheckbox6_OnChange(object sender, EventArgs e)
        {
            bunifuCheckbox7.Checked = false;
            bunifuCheckbox8.Checked = false;
            bunifuCheckbox5.Checked = false;
        }

        private void bunifuCheckbox5_OnChange(object sender, EventArgs e)
        {
            bunifuCheckbox7.Checked = false;
            bunifuCheckbox6.Checked = false;
            bunifuCheckbox8.Checked = false;
        }
    }
}
