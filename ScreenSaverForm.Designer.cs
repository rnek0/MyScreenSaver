namespace MyScreenSaver
{
    partial class ScreenSaverForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textLabel = new System.Windows.Forms.Label();
            this.moveTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureJack = new System.Windows.Forms.PictureBox();
            this.panelJack = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureJack)).BeginInit();
            this.panelJack.SuspendLayout();
            this.SuspendLayout();
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLabel.ForeColor = System.Drawing.Color.Red;
            this.textLabel.Location = new System.Drawing.Point(13, 201);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(292, 73);
            this.textLabel.TabIndex = 0;
            this.textLabel.Text = "20:08:30";
            // 
            // moveTimer
            // 
            this.moveTimer.Tick += new System.EventHandler(this.moveTimer_Tick);
            // 
            // pictureJack
            // 
            this.pictureJack.BackColor = System.Drawing.Color.Transparent;
            this.pictureJack.Image = global::MyScreenSaver.Properties.Resources.JackSparrow;
            this.pictureJack.Location = new System.Drawing.Point(36, 0);
            this.pictureJack.Name = "pictureJack";
            this.pictureJack.Size = new System.Drawing.Size(238, 200);
            this.pictureJack.TabIndex = 1;
            this.pictureJack.TabStop = false;
            // 
            // panelJack
            // 
            this.panelJack.Controls.Add(this.pictureJack);
            this.panelJack.Controls.Add(this.textLabel);
            this.panelJack.Location = new System.Drawing.Point(241, 78);
            this.panelJack.Name = "panelJack";
            this.panelJack.Size = new System.Drawing.Size(313, 275);
            this.panelJack.TabIndex = 2;
            // 
            // ScreenSaverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelJack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenSaverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureJack)).EndInit();
            this.panelJack.ResumeLayout(false);
            this.panelJack.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.Timer moveTimer;
        private System.Windows.Forms.PictureBox pictureJack;
        private System.Windows.Forms.Panel panelJack;
    }
}

