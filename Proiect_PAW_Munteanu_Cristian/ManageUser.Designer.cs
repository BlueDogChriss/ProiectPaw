
namespace Proiect_PAW_Munteanu_Cristian
{
    partial class ManageUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2GradientPanelTitle = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.guna2GradientPanelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GradientPanelTitle
            // 
            this.guna2GradientPanelTitle.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanelTitle.Controls.Add(this.label1);
            this.guna2GradientPanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanelTitle.FillColor = System.Drawing.Color.SkyBlue;
            this.guna2GradientPanelTitle.FillColor2 = System.Drawing.Color.MediumSpringGreen;
            this.guna2GradientPanelTitle.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.guna2GradientPanelTitle.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanelTitle.Name = "guna2GradientPanelTitle";
            this.guna2GradientPanelTitle.ShadowDecoration.Parent = this.guna2GradientPanelTitle;
            this.guna2GradientPanelTitle.Size = new System.Drawing.Size(1035, 100);
            this.guna2GradientPanelTitle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Users";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 127);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // ManageUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 650);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.guna2GradientPanelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageUser";
            this.guna2GradientPanelTitle.ResumeLayout(false);
            this.guna2GradientPanelTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanelTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}