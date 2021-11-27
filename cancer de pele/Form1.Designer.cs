
namespace cancer_de_pele
{
    partial class frmEncontrarCancerDePele
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbImagemOriginal = new System.Windows.Forms.PictureBox();
            this.pbMarcacaoCancer = new System.Windows.Forms.PictureBox();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.btnEncontrarCancer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagemOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMarcacaoCancer)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImagemOriginal
            // 
            this.pbImagemOriginal.Location = new System.Drawing.Point(13, 13);
            this.pbImagemOriginal.Name = "pbImagemOriginal";
            this.pbImagemOriginal.Size = new System.Drawing.Size(391, 393);
            this.pbImagemOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagemOriginal.TabIndex = 0;
            this.pbImagemOriginal.TabStop = false;
            // 
            // pbMarcacaoCancer
            // 
            this.pbMarcacaoCancer.Location = new System.Drawing.Point(426, 12);
            this.pbMarcacaoCancer.Name = "pbMarcacaoCancer";
            this.pbMarcacaoCancer.Size = new System.Drawing.Size(405, 393);
            this.pbMarcacaoCancer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMarcacaoCancer.TabIndex = 1;
            this.pbMarcacaoCancer.TabStop = false;
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.Location = new System.Drawing.Point(13, 432);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(128, 39);
            this.btnUploadImage.TabIndex = 2;
            this.btnUploadImage.Text = "Seleciona Imagem";
            this.btnUploadImage.UseVisualStyleBackColor = true;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // btnEncontrarCancer
            // 
            this.btnEncontrarCancer.Location = new System.Drawing.Point(161, 432);
            this.btnEncontrarCancer.Name = "btnEncontrarCancer";
            this.btnEncontrarCancer.Size = new System.Drawing.Size(158, 39);
            this.btnEncontrarCancer.TabIndex = 3;
            this.btnEncontrarCancer.Text = "Procurar Câncer de Pele";
            this.btnEncontrarCancer.UseVisualStyleBackColor = true;
            this.btnEncontrarCancer.Click += new System.EventHandler(this.btnEncontrarCancer_Click);
            // 
            // frmEncontrarCancerDePele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 547);
            this.Controls.Add(this.btnEncontrarCancer);
            this.Controls.Add(this.btnUploadImage);
            this.Controls.Add(this.pbMarcacaoCancer);
            this.Controls.Add(this.pbImagemOriginal);
            this.Name = "frmEncontrarCancerDePele";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encontrar Câncer de Pele";
            ((System.ComponentModel.ISupportInitialize)(this.pbImagemOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMarcacaoCancer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImagemOriginal;
        private System.Windows.Forms.PictureBox pbMarcacaoCancer;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Button btnEncontrarCancer;
    }
}

