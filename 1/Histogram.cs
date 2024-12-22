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
    public partial class Histogram : Form
    {
        public Histogram()
        {
            InitializeComponent();
        }
        IplImage sourseImage;
        IplImage resized_image;
        Bitmap editedImage;
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(); 
            this.Hide();   
            form1.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = " ";
            openFileDialog1.Filter = "JPEG|*JPG|Bitmap|*.bmp|All|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    sourseImage = cvlib.CvLoadImage(openFileDialog1.FileName, cvlib.CV_LOAD_IMAGE_COLOR);
                    CvSize size = new CvSize(pictureBox1.Width, pictureBox1.Height);
                    resized_image = cvlib.CvCreateImage(size, sourseImage.depth, sourseImage.nChannels);
                    cvlib.CvResize(ref sourseImage, ref resized_image, cvlib.CV_INTER_LINEAR);
                    pictureBox1.BackgroundImage = (System.Drawing.Image)resized_image;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Bitmap bmpImg = (Bitmap)resized_image;
            int width = resized_image.width;
            int hieght = resized_image.height;
            histoChart.Series["Red"].Points.Clear();
            histoChart.Series["Green"].Points.Clear();
            histoChart.Series["Blue"].Points.Clear();

            int[] ni_Red = new int[256];
            int[] ni_Green = new int[256];
            int[] ni_Blue = new int[256];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < hieght; j++)
                {
                    Color pixelColor = bmpImg.GetPixel(i, j);
                    ni_Red[pixelColor.R]++;
                    ni_Green[pixelColor.G]++;
                    ni_Blue[pixelColor.B]++;
                }
            }

            for (int i = 0; i < 256; i++)
            {
                histoChart.Series["Red"].Points.AddY(ni_Red[i]);
                histoChart.Series["Green"].Points.AddY(ni_Green[i]);
                histoChart.Series["Blue"].Points.AddY(ni_Blue[i]);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void histoChart_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmpImg = (Bitmap)resized_image;
            int width = bmpImg.Width;
            int height = bmpImg.Height;

            Bitmap newImage = new Bitmap(width, height);

            int[] ni_Red = new int[256];
            int[] ni_Green = new int[256];
            int[] ni_Blue = new int[256];

            //** Calculate N(i) **//

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color pixelColor = bmpImg.GetPixel(i, j);
                    ni_Red[pixelColor.R]++;
                    ni_Green[pixelColor.G]++;
                    ni_Blue[pixelColor.B]++;
                }
            }

            //** Calculate P(Ni) **//

            decimal[] prob_ni_Red = new decimal[256];
            decimal[] prob_ni_Green = new decimal[256];
            decimal[] prob_ni_Blue = new decimal[256];

            for (int i = 0; i < 256; i++)
            {
                prob_ni_Red[i] = (decimal)ni_Red[i] / (width * height);
                prob_ni_Green[i] = (decimal)ni_Green[i] / (width * height);
                prob_ni_Blue[i] = (decimal)ni_Blue[i] / (width * height);
            }

            //** Calculate CDF **//

            decimal[] cdf_Red = new decimal[256];
            decimal[] cdf_Green = new decimal[256];
            decimal[] cdf_Blue = new decimal[256];

            cdf_Red[0] = prob_ni_Red[0];
            cdf_Green[0] = prob_ni_Green[0];
            cdf_Blue[0] = prob_ni_Blue[0];

            for (int i = 1; i < 256; i++)
            {
                cdf_Red[i] = prob_ni_Red[i] + cdf_Red[i - 1];
                cdf_Green[i] = prob_ni_Green[i] + cdf_Green[i - 1];
                cdf_Blue[i] = prob_ni_Blue[i] + cdf_Blue[i - 1];
            }

            //** Calculate CDF(L-1) **//
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color pixelColor = bmpImg.GetPixel(i, j);

                    int red = (int)(cdf_Red[pixelColor.R] * 255);
                    int green = (int)(cdf_Green[pixelColor.G] * 255);
                    int blue = (int)(cdf_Blue[pixelColor.B] * 255);

                    Color newColor = Color.FromArgb(red, green, blue);
                    newImage.SetPixel(i, j, newColor);
                }
            }
            editedImage = newImage;
            pictureBox2.Image = newImage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmpImg = editedImage;
            int width = editedImage.Width;
            int hieght = editedImage.Height;
            histoChart2.Series["Red"].Points.Clear();
            histoChart2.Series["Green"].Points.Clear();
            histoChart2.Series["Blue"].Points.Clear();

            int[] ni_Red = new int[256];
            int[] ni_Green = new int[256];
            int[] ni_Blue = new int[256];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < hieght; j++)
                {
                    Color pixelColor = bmpImg.GetPixel(i, j);
                    ni_Red[pixelColor.R]++;
                    ni_Green[pixelColor.G]++;
                    ni_Blue[pixelColor.B]++;
                }
            }

            for (int i = 0; i < 256; i++)
            {
                histoChart2.Series["Red"].Points.AddY(ni_Red[i]);
                histoChart2.Series["Green"].Points.AddY(ni_Green[i]);
                histoChart2.Series["Blue"].Points.AddY(ni_Blue[i]);
            }
        }

        private void Histogram_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
    }
}
