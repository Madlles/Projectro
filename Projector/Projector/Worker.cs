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
    public partial class Worker : Form
    {
        
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        public Worker()
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
            timer1.Start();
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(139, 0, 255);
            public static Color color5 = Color.FromArgb(204, 0, 7);
        }

        public void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
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

        private void OpenChildForm(Form childForm)
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
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            label1.Text = childForm.Text;
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(26, 32, 40);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            
            if(panel1.Width==55)
            {
                panel1.Visible = false;
                panel1.Width = 260;
                bunifuTransition3.ShowSync(panel1);
                bunifuTransition2.ShowSync(pictureBox1);

                guna2CirclePictureBox1.Location = new Point(476, 136);
                bunifuCustomLabel1.Location = new Point(476, 339);
                bunifuCustomLabel2.Location = new Point(476, 380);
                guna2CirclePictureBox1.Visible = false;
                bunifuCustomLabel1.Visible = false;
                bunifuCustomLabel2.Visible = false;
                bunifuTransition4.ShowSync(guna2CirclePictureBox1);
                bunifuTransition4.ShowSync(bunifuCustomLabel1);
                bunifuTransition4.ShowSync(bunifuCustomLabel2);
            }

            else
            {
                bunifuTransition2.HideSync(pictureBox1);
                panel1.Visible = false;
                panel1.Width = 55;
                bunifuTransition1.ShowSync(panel1);

                guna2CirclePictureBox1.Location = new Point(363, 136);
                bunifuCustomLabel1.Location = new Point(363, 339);
                bunifuCustomLabel2.Location = new Point(363, 380);
                guna2CirclePictureBox1.Visible = false;
                bunifuCustomLabel1.Visible = false;
                bunifuCustomLabel2.Visible = false;
                bunifuTransition4.ShowSync(guna2CirclePictureBox1);
                bunifuTransition4.ShowSync(bunifuCustomLabel1);
                bunifuTransition4.ShowSync(bunifuCustomLabel2);
            }
        }
        private void Reset() // cброс кнопки на всякий
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconPictureBox1.IconChar = IconChar.Home;
            iconPictureBox1.IconColor = Color.MediumPurple;
            label1.Text = "Home";
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new FormInformation());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FormConfigyrationPC());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new FormSettings());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bunifuCustomLabel2.Text = DateTime.Now.ToLongTimeString();
        }

        async private void Worker_Load(object sender, EventArgs e)
        {
            for (Opacity = 0; Opacity < 1; Opacity += 0.01)
                await Task.Delay(1);
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            Login ld = new Login();
            ld.Owner = this;
            ld.Show();
            Hide();
        }
    }
}
