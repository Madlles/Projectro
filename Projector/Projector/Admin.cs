using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Projector
{
    public partial class Admin : Form
    {
        int r = 0;
        int g = 0;
        int b = 0;

        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        public Admin()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panel1.Controls.Add(leftBorderBtn);
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(139, 0, 255);
            public static Color color5 = Color.FromArgb(204, 0, 7);

            public static Color BC = Color.FromArgb(37, 36, 81);
            public static Color DS = Color.FromArgb(26, 32, 40);
            public static Color TX = Color.FromArgb(255, 255, 255);
        }

        public void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = RGBColors.BC;
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                iconPictureBox1.IconChar = currentBtn.IconChar;
                iconPictureBox1.IconColor = color;

                if (panel1.Width == 55)
                {
                    currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                    currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                    currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                }

                else if (panel1.Width == 260)
                {
                    currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                    currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                    currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                }

            }
        }

        async private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.BackColor = panel3.BackColor;
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            label1.Text = childForm.Text;

        }

        private void Reset(object sender) // cброс кнопки на всякий
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconPictureBox1.IconChar = IconChar.Home;
            iconPictureBox1.IconColor = Color.MediumPurple;

        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = RGBColors.DS;
                currentBtn.ForeColor = RGBColors.TX;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = RGBColors.TX;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 55)
            {
                panel1.Visible = false;
                bunifuTransition3.Show(panel1);
                panel1.Width = 260;
                bunifuTransition2.ShowSync(pictureBox1);
            }

            else
            {
                bunifuTransition2.HideSync(pictureBox1);
                panel1.Visible = false;
                panel1.Width = 55;
                bunifuTransition1.ShowSync(panel1);

            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Reset(sender);
            ActivateButton(sender, RGBColors.color1);
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new FormInformattionAdmin());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FormConfigyrationPCAdmin());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            Login ld = new Login();
            ld.Owner = this;
            ld.Show();
            Hide();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new FormAYTHAdmin());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
