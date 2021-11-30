
namespace ASSISTENTE_TCC_01
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.barraDeAudio = new System.Windows.Forms.ProgressBar();
            this.labeltext = new System.Windows.Forms.Label();
            this.labelstatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // barraDeAudio
            // 
            this.barraDeAudio.Location = new System.Drawing.Point(106, 370);
            this.barraDeAudio.Maximum = 25;
            this.barraDeAudio.Name = "barraDeAudio";
            this.barraDeAudio.Size = new System.Drawing.Size(245, 37);
            this.barraDeAudio.TabIndex = 0;
            // 
            // labeltext
            // 
            this.labeltext.AutoSize = true;
            this.labeltext.BackColor = System.Drawing.Color.Transparent;
            this.labeltext.ForeColor = System.Drawing.Color.Red;
            this.labeltext.Location = new System.Drawing.Point(24, 24);
            this.labeltext.Name = "labeltext";
            this.labeltext.Size = new System.Drawing.Size(0, 13);
            this.labeltext.TabIndex = 1;
            // 
            // labelstatus
            // 
            this.labelstatus.BackColor = System.Drawing.Color.Black;
            this.labelstatus.Location = new System.Drawing.Point(-3, 439);
            this.labelstatus.Name = "labelstatus";
            this.labelstatus.Size = new System.Drawing.Size(472, 23);
            this.labelstatus.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ASSISTENTE_TCC_01.Properties.Resources._4454;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(467, 450);
            this.Controls.Add(this.labelstatus);
            this.Controls.Add(this.labeltext);
            this.Controls.Add(this.barraDeAudio);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assistente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar barraDeAudio;
        private System.Windows.Forms.Label labeltext;
        private System.Windows.Forms.Label labelstatus;
    }
}

