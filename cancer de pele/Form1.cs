using DIPLi;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace cancer_de_pele
{
    public partial class frmEncontrarCancerDePele : Form
    {
        public frmEncontrarCancerDePele()
        {
            InitializeComponent();
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "All Files(*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pbImagemOriginal.ImageLocation = dialog.FileName;
                }
            }
            catch
            {
                MessageBox.Show("Ops, ocorreu um erro no upload da imagem", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Bitmap filtroMediana(Bitmap img)
        {
            Bitmap Imagem = new Bitmap(img);
            int largura = img.Width;
            int altura = img.Height;
            Bitmap result = new Bitmap(largura, altura);
            int pixelR = 0, pixelG = 0, pixelB = 0, pixelA = 0, i, j;
            int[] todosPixelsR = new int[9];
            int[] todosPixelsG = new int[9];
            int[] todosPixelsB = new int[9];
            int[] todosPixelsA = new int[9];

            for (i = 1; i < largura - 1; i++)
            {
                for (j = 1; j < altura - 1; j++)
                {

                    todosPixelsR[0] = Imagem.GetPixel(i - 1, j - 1).R;
                    todosPixelsR[1] = Imagem.GetPixel(i - 1, j).R;
                    todosPixelsR[2] = Imagem.GetPixel(i - 1, j + 1).R;

                    todosPixelsR[3] = Imagem.GetPixel(i, j - 1).R;
                    todosPixelsR[4] = Imagem.GetPixel(i, j).R;
                    todosPixelsR[5] = Imagem.GetPixel(i, j + 1).R;

                    todosPixelsR[6] = Imagem.GetPixel(i + 1, j - 1).R;
                    todosPixelsR[7] = Imagem.GetPixel(i + 1, j).R;
                    todosPixelsR[8] = Imagem.GetPixel(i + 1, j + 1).R;

                    Array.Sort(todosPixelsR);
                    pixelR = todosPixelsR[8];

                    /******************************************/

                    todosPixelsG[0] = Imagem.GetPixel(i - 1, j - 1).G;
                    todosPixelsG[1] = Imagem.GetPixel(i - 1, j).G;
                    todosPixelsG[2] = Imagem.GetPixel(i - 1, j + 1).G;

                    todosPixelsG[3] = Imagem.GetPixel(i, j - 1).G;
                    todosPixelsG[4] = Imagem.GetPixel(i, j).G;
                    todosPixelsG[5] = Imagem.GetPixel(i, j + 1).G;

                    todosPixelsG[6] = Imagem.GetPixel(i + 1, j - 1).G;
                    todosPixelsG[7] = Imagem.GetPixel(i + 1, j).G;
                    todosPixelsG[8] = Imagem.GetPixel(i + 1, j + 1).G;

                    Array.Sort(todosPixelsG);
                    pixelG = todosPixelsG[8];

                    /******************************************/

                    todosPixelsB[0] = Imagem.GetPixel(i - 1, j - 1).B;
                    todosPixelsB[1] = Imagem.GetPixel(i - 1, j).B;
                    todosPixelsB[2] = Imagem.GetPixel(i - 1, j + 1).B;

                    todosPixelsB[3] = Imagem.GetPixel(i, j - 1).B;
                    todosPixelsB[4] = Imagem.GetPixel(i, j).B;
                    todosPixelsB[5] = Imagem.GetPixel(i, j + 1).B;

                    todosPixelsB[6] = Imagem.GetPixel(i + 1, j - 1).B;
                    todosPixelsB[7] = Imagem.GetPixel(i + 1, j).B;
                    todosPixelsB[8] = Imagem.GetPixel(i + 1, j + 1).B;

                    Array.Sort(todosPixelsB);
                    pixelB = todosPixelsB[8];

                    /******************************************/

                    todosPixelsA[0] = Imagem.GetPixel(i - 1, j - 1).A;
                    todosPixelsA[1] = Imagem.GetPixel(i - 1, j).A;
                    todosPixelsA[2] = Imagem.GetPixel(i - 1, j + 1).A;

                    todosPixelsA[3] = Imagem.GetPixel(i, j - 1).A;
                    todosPixelsA[4] = Imagem.GetPixel(i, j).A;
                    todosPixelsA[5] = Imagem.GetPixel(i, j + 1).A;

                    todosPixelsA[6] = Imagem.GetPixel(i + 1, j - 1).A;
                    todosPixelsA[7] = Imagem.GetPixel(i + 1, j).A;
                    todosPixelsA[8] = Imagem.GetPixel(i + 1, j + 1).A;

                    Array.Sort(todosPixelsA);
                    pixelA = todosPixelsA[8];

                    /*******************************************/

                    result.SetPixel(i, j, Color.FromArgb(pixelA, pixelR, pixelG, pixelB));
                }
            }

            return  result;
        }

        public Imagem Quantizacao(Imagem I, int subDivision)
        {
            Imagem aux = new Imagem(I.Largura, I.Altura);
            int color = 255 / (subDivision - 1);
            int range = 256 / subDivision;
            for (int i = 0; i < I.Altura; i++)
            {
                for (int j = 0; j < I.Largura; j++)
                {
                    if (I[i, j] >= 0 && I[i, j] <= range)
                    {
                        aux[i, j] = 0;
                    }
                    else
                    {
                        aux[i, j] = color * Math.Floor(I[i, j] / range);
                    }
                }
            }
            return aux;
        }

        private double[] calcularHistograma(Imagem img)
        {
            double[] valores = new double[256];
            int nivelCinza = 0, i, j;
            int altura = img.Altura;
            int largura = img.Largura;

            for (i = 0; i < altura; i++)
            {
                for (j = 0; j < largura; j++)
                {
                    nivelCinza = (int)img[i, j];
                    valores[nivelCinza] += 1;
                }
            }

            return valores;
        }

        public int Otsu(Imagem img)
        {
            double[] histData = new double[256];
            int t, wB = 0, wF = 0, threshold = 0;
            double sum = 0, sumB = 0, varMax = 0;
            int total = img.Altura * img.Largura;

            histData = calcularHistograma(img);

            for (t = 0; t < 256; t++)
                sum += t * histData[t];

            for (t = 0; t < 256; t++)
            {
                wB += (int)histData[t];
                if (wB == 0) continue;

                wF = total - wB;
                if (wF == 0) continue;

                sumB += (double)(t * histData[t]);
                double mB = sumB / wB;
                double mF = (sum - sumB) / wF;
                double varBetween = (double)wB * (double)wF * (mB - mF) * (mB - mF);
                if (varBetween > varMax)
                {
                    varMax = varBetween;
                    threshold = t;
                }
            }
            return threshold;
        }

        public Imagem Limiarizacao(Imagem img)
        {
            int valorLimiarizacao = Otsu(img);
            int i, j;
            int altura = img.Altura;
            int largura = img.Largura;
            Imagem result = new Imagem(largura, altura);

            for (i = 0; i < altura; i++)
            {
                for (j = 0; j < largura; j++)
                {
                    result[i, j] = (img[i, j] > valorLimiarizacao) ? 255 : 0;
                }
            }

            return result;

        }

        public Imagem encontrarBorda(Imagem img)
        {
            int largura = img.Largura;
            int altura = img.Altura;
            Imagem result = new Imagem(largura, altura);
            int[,] Laplace = new int[,] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };
            int i, j, auxInt, auxInt2;
            int todosPixels = 0;
            for (i = 0; i < altura - 2; i++)
            {
                for (j = 0; j < largura - 2; j++)
                {
                    for (auxInt = 0; auxInt < 3; auxInt++)
                    {
                        for (auxInt2 = 0; auxInt2 < 3; auxInt2++)
                        {
                            todosPixels += (int)img[i + auxInt, j + auxInt2] * Laplace[auxInt2, auxInt];
                        }
                    }
                    if (todosPixels < 0)
                    {
                        todosPixels = 0;
                    }
                    else if(todosPixels > 255)
                    {
                        todosPixels = 0;
                    }

                    result[i, j] = todosPixels;
                    todosPixels = 0;
                }
            }
            return result;
        }

        private Imagem marcarCancer(Imagem imagemOriginal, Imagem img)
        {
            int altura = img.Altura, largura = img.Largura, i, j;
            Imagem resutl = new Imagem(largura, altura);
            for(i = 0; i < altura; i++)
            {
                for(j = 0; j < largura; j++)
                {
                    resutl[i, j] = (img[i, j] == 0) ? 0 : imagemOriginal[i, j];
                }
            }
            return resutl;
        }

        private void btnEncontrarCancer_Click(object sender, EventArgs e)
        {
            Imagem imagemOriginal = new Imagem((Bitmap)pbImagemOriginal.Image);
            Imagem img = new Imagem(filtroMediana((Bitmap)pbImagemOriginal.Image));
            img = Quantizacao(img, 2);
            img = encontrarBorda(img);
            img = Limiarizacao(img);
            pbMarcacaoCancer.Image = marcarCancer(imagemOriginal, img).ToBitmap();
        }

    }
}
