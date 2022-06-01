
namespace Otomasyon
{
    partial class Giris
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Musteri = new System.Windows.Forms.Button();
            this.btn_Satici = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Musteri
            // 
            this.btn_Musteri.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_Musteri.ForeColor = System.Drawing.Color.White;
            this.btn_Musteri.Location = new System.Drawing.Point(159, 221);
            this.btn_Musteri.Name = "btn_Musteri";
            this.btn_Musteri.Size = new System.Drawing.Size(145, 105);
            this.btn_Musteri.TabIndex = 1;
            this.btn_Musteri.Text = "MÜŞTERİ";
            this.btn_Musteri.UseVisualStyleBackColor = false;
            this.btn_Musteri.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Satici
            // 
            this.btn_Satici.BackColor = System.Drawing.Color.SaddleBrown;
            this.btn_Satici.ForeColor = System.Drawing.Color.White;
            this.btn_Satici.Location = new System.Drawing.Point(398, 221);
            this.btn_Satici.Name = "btn_Satici";
            this.btn_Satici.Size = new System.Drawing.Size(145, 105);
            this.btn_Satici.TabIndex = 2;
            this.btn_Satici.Text = "YÖNETİCİ";
            this.btn_Satici.UseVisualStyleBackColor = false;
            this.btn_Satici.Click += new System.EventHandler(this.btn_Satici_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label2.Font = new System.Drawing.Font("Lucida Calligraphy", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(222, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "SeaSide Organic";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label3.Font = new System.Drawing.Font("Lucida Calligraphy", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(257, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 36);
            this.label3.TabIndex = 3;
            this.label3.Text = "Baby Wear";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.GhostWhite;
            this.label4.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(270, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 39);
            this.label4.TabIndex = 3;
            this.label4.Text = "Giriş Paneli";
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(700, 442);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Satici);
            this.Controls.Add(this.btn_Musteri);
            this.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Giris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Musteri;
        private System.Windows.Forms.Button btn_Satici;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

