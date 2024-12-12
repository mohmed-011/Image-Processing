using openCV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace _1
{
    public partial class aqualizationHistogram : Form
    {
        public aqualizationHistogram()
        {
            InitializeComponent();
        }
        IplImage image1;


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = " ";
            openFileDialog1.Filter = "JPEG|*JPG|Bitmap|*.bmp|All|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    image1 = cvlib.CvLoadImage(openFileDialog1.FileName, cvlib.CV_LOAD_IMAGE_COLOR);
                    CvSize size = new CvSize(pictureBox1.Width, pictureBox1.Height);
                    IplImage resized_image = cvlib.CvCreateImage(size, image1.depth, image1.nChannels);
                    cvlib.CvResize(ref image1, ref resized_image, cvlib.CV_INTER_LINEAR);
                    pictureBox1.BackgroundImage = (System.Drawing.Image)resized_image;

                    //pictureBox1.BackgroundImage = (Image)image1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(); // Create an instance of the second form
            this.Hide();               // Hide the current form
            form1.Show();
        }

        private void aqualizationHistogram_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmpImg = (Bitmap)image1;
            Bitmap newImsge = bmpImg;
            int width = newImsge.Width;
            int height = newImsge.Height;

            //************ Calculate N(i) ***************//
            int[] ni_Red = new int[256];
            int[] ni_Green = new int[256];
            int[] ni_Blue = new int[256];
            for (int i = 0; i< width; i++) {
                for (int j = 0; j< height; j++) {
                    Color pixelCorol = bmpImg.GetPixel(i, j);
                    ni_Red[pixelCorol.R]++;
                    ni_Green[pixelCorol.G]++;
                    ni_Blue[pixelCorol.B]++;
                }
            }

            //************** Calculate P(Ni) ***************//

            decimal[] prob_ni_Red = new decimal[256];
            decimal[] prob_ni_Green = new decimal[256];
            decimal[] prob_ni_Blue = new decimal[256];

            for (int i = 0; i < 256; i++) {
                prob_ni_Red[i] = (decimal)prob_ni_Red[i] / (decimal)(width * height);
                prob_ni_Green[i] = (decimal)prob_ni_Green[i] /(decimal)(height * width);
                prob_ni_Blue[i] = (decimal)prob_ni_Blue[i] / (decimal)(height * width);
            }
            //************** Calculate CDF ***************//
            decimal[] cdf_Red = new decimal[256];
            decimal[] cdf_Green = new decimal[256];
            decimal[] cdf_Blue = new decimal[256];

            cdf_Red[0] = prob_ni_Red[0];
            cdf_Green[0] = prob_ni_Green[0];
            cdf_Blue[0] = prob_ni_Blue[0];

            for (int i = 1; i< 256; i++) {
                cdf_Red[i] = prob_ni_Red[i] + cdf_Red[i - 1];
                cdf_Green[i] = prob_ni_Green[i - 1] + cdf_Green[i - 1];
                cdf_Blue[i] = prob_ni_Blue[i - 1] + cdf_Blue[i - 1];
            }
            //************** Calculate CDF(L-1) ***************//
            int red , green , blue ;
            int constant = 255;

            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    Color pixelColor = bmpImg.GetPixel(i, j);

                    red = (int)(cdf_Red[pixelColor.R] * constant);
                    green = (int)(cdf_Red[pixelColor.G] * constant);
                    blue = (int)(cdf_Red[pixelColor.B] * constant);

                    Color newColor = Color.FromArgb(red, green, blue);
                    newImsge.SetPixel(i, j, newColor);

                }
            }
            for (int i = 0; i < 256; i++)
            {
                histoChart.Series["Red"].Points.AddY(cdf_Red[i]);
                histoChart.Series["Green"].Points.AddY(cdf_Green[i]);
                histoChart.Series["Blue"].Points.AddY(cdf_Blue[i]);
            }
            pictureBox2.Image = (System.Drawing.Image)newImsge;

        }
    }
}
