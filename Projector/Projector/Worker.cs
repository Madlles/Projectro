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
        int r = 0;
        int g = 0;
        int b = 0;

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

            public static Color BC = Color.FromArgb(37, 36, 81);
            public static Color DS = Color.FromArgb(26, 32, 40);
            public static Color TX = Color.FromArgb(255,255, 255);
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

            if(GN == true)
            {
                for (int i = 0; i < 1000000; i++)
                {
                    if (step >= 1f)
                    {
                        step = 0;

                        int R = rnd.Next(0, 255);
                        int G = rnd.Next(0, 255);
                        int B = rnd.Next(0, 255);
                        currentColor = targetColor;
                        targetColor = Color.FromArgb(R, G, B);
                    }
                    int mixR = (int)(currentColor.R * (1f - step) + targetColor.R * step);
                    int mixG = (int)(currentColor.G * (1f - step) + targetColor.G * step);
                    int mixB = (int)(currentColor.B * (1f - step) + targetColor.B * step);
                    await Task.Delay(1);
                    childForm.BackColor = Color.FromArgb(mixR, mixG, mixB);

                }
                

            }
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

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            
            if(panel1.Width==55)
            {
                panel1.Visible = false;
                bunifuTransition3.Show(panel1);
                panel1.Width = 260;
                bunifuTransition2.ShowSync(pictureBox1);

                if(guna2CirclePictureBox1.Visible == true)
                {
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
                
            }

            else
            {
                bunifuTransition2.HideSync(pictureBox1);
                panel1.Visible = false;
                panel1.Width = 55;
                bunifuTransition1.ShowSync(panel1);

               
                if(guna2CirclePictureBox1.Visible == true)
                {
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
        }
        private void Reset(object sender) // cброс кнопки на всякий
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconPictureBox1.IconChar = IconChar.Home;
            iconPictureBox1.IconColor = Color.MediumPurple;
            
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Reset(sender);
            ActivateButton(sender, RGBColors.color1);
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            guna2CirclePictureBox1.Visible = true;
            bunifuCustomLabel1.Show();
            bunifuCustomLabel2.Show();
            bunifuSlider1.Visible = false;
            bunifuSlider2.Visible = false;
            bunifuSlider3.Visible = false;
            bunifuSlider4.Visible = false;
            bunifuSlider5.Visible = false;
            bunifuSlider6.Visible = false;
            bunifuSlider7.Visible = false;
            bunifuSlider8.Visible = false;
            bunifuSlider9.Visible = false;
            bunifuSlider10.Visible = false;
            bunifuSlider11.Visible = false;
            bunifuSlider12.Visible = false;
            bunifuCustomLabel4.Visible = false;
            bunifuCustomLabel3.Visible = false;
            bunifuCustomLabel5.Visible = false;
            bunifuLabel1.Visible = false;
            bunifuLabel2.Visible = false;
            guna2GradientButton1.Visible = false;



        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new FormInformation());
            bunifuSlider1.Visible = false;
            bunifuSlider2.Visible = false;
            bunifuSlider3.Visible = false;
            bunifuSlider4.Visible = false;
            bunifuSlider5.Visible = false;
            bunifuSlider6.Visible = false;
            bunifuSlider7.Visible = false;
            bunifuSlider8.Visible = false;
            bunifuSlider9.Visible = false;
            bunifuSlider10.Visible = false;
            bunifuSlider11.Visible = false;
            bunifuSlider12.Visible = false;
            bunifuCustomLabel4.Visible = false;
            bunifuCustomLabel3.Visible = false;
            bunifuCustomLabel5.Visible = false;
            bunifuLabel1.Visible = false;
            bunifuLabel2.Visible = false;
            guna2GradientButton1.Visible = false;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FormConfigyrationPC());
            bunifuSlider1.Visible = false;
            bunifuSlider2.Visible = false;
            bunifuSlider3.Visible = false;
            bunifuSlider4.Visible = false;
            bunifuSlider5.Visible = false;
            bunifuSlider6.Visible = false;
            bunifuSlider7.Visible = false;
            bunifuSlider8.Visible = false;
            bunifuSlider9.Visible = false;
            bunifuSlider10.Visible = false;
            bunifuSlider11.Visible = false;
            bunifuSlider12.Visible = false;
            bunifuCustomLabel4.Visible = false;
            bunifuCustomLabel3.Visible = false;
            bunifuCustomLabel5.Visible = false;
            bunifuLabel1.Visible = false;
            bunifuLabel2.Visible = false;
            guna2GradientButton1.Visible = false;
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {

            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            label1.Text = "Настройки";
            ActivateButton(sender, RGBColors.color4);
            guna2CirclePictureBox1.Visible = false;
            bunifuCustomLabel1.Hide();
            bunifuCustomLabel2.Hide();
            bunifuSlider1.Visible = true;
            bunifuSlider2.Visible = true;
            bunifuSlider3.Visible = true;
            bunifuSlider4.Visible = true;
            bunifuSlider5.Visible = true;
            bunifuSlider6.Visible = true;
            bunifuSlider7.Visible = true;
            bunifuSlider8.Visible = true;
            bunifuSlider9.Visible = true;
            bunifuSlider10.Visible = true;
            bunifuSlider11.Visible = true;
            bunifuSlider12.Visible = true;
            bunifuCustomLabel4.Visible = true;
            bunifuCustomLabel3.Visible = true;
            bunifuCustomLabel5.Visible = true;
            bunifuLabel1.Visible = true;
            bunifuLabel2.Visible = true;
            guna2GradientButton1.Visible = true;




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

        async private void bunifuSlider1_ValueChanged(object sender, EventArgs e)
        {
            r = bunifuSlider1.Value; ;
            bunifuSlider1.Value++;
            await Task.Delay(1);
            panel1.BackColor = Color.FromArgb(r, g, b);
            RGBColors.DS = Color.FromArgb(r, g, b);
        }

        async private void bunifuSlider2_ValueChanged(object sender, EventArgs e)
        {
            b = bunifuSlider2.Value; ;
            bunifuSlider2.Value++;
            await Task.Delay(1);
            panel1.BackColor = Color.FromArgb(r, g, b);
            RGBColors.DS = Color.FromArgb(r, g, b);
        }

        async private void bunifuSlider3_ValueChanged(object sender, EventArgs e)
        {
            g = bunifuSlider3.Value; ;
            bunifuSlider3.Value++;
            await Task.Delay(1);
            panel1.BackColor = Color.FromArgb(r, g, b);
            RGBColors.DS = Color.FromArgb(r, g, b);
        }

        async private void bunifuSlider6_ValueChanged(object sender, EventArgs e)
        {
            r = bunifuSlider6.Value; ;
            bunifuSlider6.Value++;
            await Task.Delay(1);
            panel3.BackColor = Color.FromArgb(r, g, b);
        }

        async private void bunifuSlider4_ValueChanged(object sender, EventArgs e)
        {
            g = bunifuSlider4.Value; ;
            bunifuSlider4.Value++;
            await Task.Delay(1);
            panel3.BackColor = Color.FromArgb(r, g, b);
        }

        async private void bunifuSlider5_ValueChanged(object sender, EventArgs e)
        {
            b = bunifuSlider5.Value; ;
            bunifuSlider5.Value++;
            await Task.Delay(1);
            panel3.BackColor = Color.FromArgb(r, g, b);
        }

        async private void bunifuSlider9_ValueChanged(object sender, EventArgs e)
        {
            r = bunifuSlider9.Value; ;
            bunifuSlider9.Value++;
            await Task.Delay(1);
            panel2.BackColor = Color.FromArgb(r, g, b);
        }

        async private void bunifuSlider7_ValueChanged(object sender, EventArgs e)
        {
            g = bunifuSlider7.Value; ;
            bunifuSlider7.Value++;
            await Task.Delay(1);
            panel2.BackColor = Color.FromArgb(r, g, b);
        }

        async private void bunifuSlider8_ValueChanged(object sender, EventArgs e)
        {
            b = bunifuSlider8.Value; ;
            bunifuSlider8.Value++;
            await Task.Delay(1);
            panel2.BackColor = Color.FromArgb(r, g, b);
        }

        async private void bunifuSlider12_ValueChanged(object sender, EventArgs e)
        {
            r = bunifuSlider12.Value; ;
            bunifuSlider12.Value++;
            await Task.Delay(1);
            RGBColors.TX = Color.FromArgb(r, g, b);
            bunifuCustomLabel1.ForeColor = Color.FromArgb(r, g, b);
            bunifuCustomLabel2.ForeColor = Color.FromArgb(r, g, b);
            bunifuLabel1.ForeColor = Color.FromArgb(r, g, b);
            bunifuLabel2.ForeColor = Color.FromArgb(r, g, b);
            bunifuCustomLabel3.ForeColor = Color.FromArgb(r, g, b);
            bunifuCustomLabel4.ForeColor = Color.FromArgb(r, g, b);
            bunifuCustomLabel5.ForeColor = Color.FromArgb(r, g, b);
            label1.ForeColor = Color.FromArgb(r, g, b);
        }

        async private void bunifuSlider10_ValueChanged(object sender, EventArgs e)
        {
            g = bunifuSlider10.Value; ;
            bunifuSlider10.Value++;
            await Task.Delay(1);
            RGBColors.TX = Color.FromArgb(r, g, b);
            bunifuCustomLabel1.ForeColor = Color.FromArgb(r, g, b);
            bunifuCustomLabel2.ForeColor = Color.FromArgb(r, g, b);
            bunifuLabel1.ForeColor = Color.FromArgb(r, g, b);
            bunifuLabel2.ForeColor = Color.FromArgb(r, g, b);
            bunifuCustomLabel3.ForeColor = Color.FromArgb(r, g, b);
            bunifuCustomLabel4.ForeColor = Color.FromArgb(r, g, b);
            bunifuCustomLabel5.ForeColor = Color.FromArgb(r, g, b);
            label1.ForeColor = Color.FromArgb(r, g, b);
        }

        async private void bunifuSlider11_ValueChanged(object sender, EventArgs e)
        {
            b = bunifuSlider11.Value; ;
            bunifuSlider11.Value++;
            await Task.Delay(1);
            RGBColors.TX = Color.FromArgb(r, g, b);
            bunifuCustomLabel1.ForeColor = Color.FromArgb(r, g, b);
            bunifuCustomLabel2.ForeColor = Color.FromArgb(r, g, b);
            bunifuLabel1.ForeColor = Color.FromArgb(r, g, b);
            bunifuLabel2.ForeColor = Color.FromArgb(r, g, b);
            bunifuCustomLabel3.ForeColor = Color.FromArgb(r, g, b);
            bunifuCustomLabel4.ForeColor = Color.FromArgb(r, g, b);
            bunifuCustomLabel5.ForeColor = Color.FromArgb(r, g, b);
            label1.ForeColor = Color.FromArgb(r, g, b);
        }

        float step = 0;

        Color currentColor = Color.DarkGreen;
        Color targetColor = Color.LightBlue;
        Random rnd = new Random();
        bool GN = false;


        async private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            GN = true;
            timer2.Interval = 20;
            timer2.Enabled = true;

            for(int i =0; i < 1000000;i++)
            {
                if (step >= 1f)
                {
                    step = 0;

                    int R = rnd.Next(0, 255);
                    int G = rnd.Next(0, 255);
                    int B = rnd.Next(0, 255);
                    currentColor = targetColor;
                    targetColor = Color.FromArgb(R, G, B);
                }
                int mixR = (int)(currentColor.R * (1f - step) + targetColor.R * step);
                int mixG = (int)(currentColor.G * (1f - step) + targetColor.G * step);
                int mixB = (int)(currentColor.B * (1f - step) + targetColor.B * step);
                await Task.Delay(1);
                panel1.BackColor = Color.FromArgb(mixR, mixG, mixB);
                panel2.BackColor = Color.FromArgb(mixR, mixG, mixB);
                panel3.BackColor = Color.FromArgb(mixR, mixG, mixB);
                RGBColors.DS = Color.FromArgb(mixR, mixG, mixB);

                

                step += 0.03f;
            }
            


        }
    }
}
