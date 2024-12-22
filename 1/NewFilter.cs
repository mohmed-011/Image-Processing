using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using openCV;

namespace _1
{

    public partial class NewFilter : Form
    {
        private Bitmap originalImage;
        private Bitmap processedImage;
        IplImage image1;


        public NewFilter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(); // Create an instance of the second form
            this.Hide();               // Hide the current form
            form1.Show();
        }

        private void Open_Click(object sender, EventArgs e)
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
                    pictureBox1.Image = (Bitmap)resized_image;
                    originalImage = (Bitmap)resized_image;
                    //pictureBox1.BackgroundImage = (Image)image1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void detection_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                
                processedImage = ApplyCannyEdgeDetection(originalImage);
                pictureBox1.Image = processedImage;
            }
        }

        private void Blur_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                processedImage = ApplyGaussianBlur(originalImage);
                pictureBox1.Image = processedImage;
            }
        }

        private void Smoothing_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                processedImage = ApplySmoothing(originalImage);
                pictureBox1.Image = processedImage;
            }
        }

        private void Laplacian_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                processedImage = ApplyLaplacianEdgeDetection(originalImage);
                pictureBox1.Image = processedImage;
            }
        }

        private Bitmap ConvertToGrayscale(Bitmap input)
        {
            Bitmap grayImage = new Bitmap(input.Width, input.Height);

            for (int x = 0; x < input.Width; x++)
            {
                for (int y = 0; y < input.Height; y++)
                {
                    Color original = input.GetPixel(x, y);
                    int gray = (int)(original.R * 0.3 + original.G * 0.59 + original.B * 0.11);
                    grayImage.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            
            /*
            int width = input.Width;
            int height = input.Height;
            Color p;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    p = input.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;
                    int avg = (r + g + b) / 3;
                    input.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                    

                }
            }
            */
            return input;
        }
        private Bitmap ApplyCannyEdgeDetection(Bitmap input)
        {
            // Simplified edge detection using grayscale and thresholds
            Bitmap grayImage = ConvertToGrayscale(input);
            Bitmap edges = new Bitmap(grayImage.Width, grayImage.Height);

            for (int x = 1; x < grayImage.Width - 1; x++)
            {
                for (int y = 1; y < grayImage.Height - 1; y++)
                {
                    int gx = Math.Abs(grayImage.GetPixel(x + 1, y).G - grayImage.GetPixel(x - 1, y).G);
                    int gy = Math.Abs(grayImage.GetPixel(x, y + 1).G - grayImage.GetPixel(x, y - 1).G);
                    int magnitude = Math.Min(255, (int)Math.Sqrt(gx * gx + gy * gy));

                    edges.SetPixel(x, y, Color.FromArgb(magnitude, magnitude, magnitude));
                }
            }

            return edges;
        }
        private Bitmap ApplyGaussianBlur(Bitmap input)
        {
            // 3x3 Gaussian kernel
            double[,] kernel = {
                { 1, 1, 1 },
                { 1, 10, 1 },
                { 1, 1, 1 }
            };
            return ApplyConvolutionFilter(input, kernel, 18);
        }
        private Bitmap ApplySmoothing(Bitmap input)
        {
            // 3x3 mean filter
            double[,] kernel = {
                { 3,3,3 },
                { 3,3,3 },
                {3,3,3 }
            };
            return ApplyConvolutionFilter(input, kernel, 27 );
        }
        private Bitmap ApplyLaplacianEdgeDetection(Bitmap input)
        {
            // 3x3 Laplacian kernel
            double[,] kernel = {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };
            return ApplyConvolutionFilter(input, kernel, 1);
        }
        private Bitmap ApplyConvolutionFilter(Bitmap input, double[,] kernel, double kernelSum)
        {
            Bitmap output = new Bitmap(input.Width, input.Height);
            int kSize = kernel.GetLength(0);
            int offset = kSize / 2;

            for (int x = offset; x < input.Width - offset; x++)
            {
                for (int y = offset; y < input.Height - offset; y++)
                {
                    double r = 0, g = 0, b = 0;

                    for (int i = -offset; i <= offset; i++)
                    {
                        for (int j = -offset; j <= offset; j++)
                        {
                            Color pixel = input.GetPixel(x + i, y + j);
                            r += pixel.R * kernel[i + offset, j + offset];
                            g += pixel.G * kernel[i + offset, j + offset];
                            b += pixel.B * kernel[i + offset, j + offset];
                        }
                    }

                    r = Math.Min(255, Math.Max(0, r / kernelSum));
                    g = Math.Min(255, Math.Max(0, g / kernelSum));
                    b = Math.Min(255, Math.Max(0, b / kernelSum));

                    output.SetPixel(x, y, Color.FromArgb((int)r, (int)g, (int)b));
                }
            }

            return output;
        }

        private void NewFilter_Load(object sender, EventArgs e)
        {

        }
    }
}
