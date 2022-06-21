
namespace ALIAGA_SERGIO_M06UF2UF4_PRACTICA
{
    partial class NotificacionsITV
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
            this.label1 = new System.Windows.Forms.Label();
            this.listNoti = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(231, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOTIFICACIONS";
            // 
            // listNoti
            // 
            this.listNoti.HideSelection = false;
            this.listNoti.Location = new System.Drawing.Point(12, 118);
            this.listNoti.Name = "listNoti";
            this.listNoti.Size = new System.Drawing.Size(776, 320);
            this.listNoti.TabIndex = 1;
            this.listNoti.UseCompatibleStateImageBehavior = false;
            this.listNoti.View = System.Windows.Forms.View.List;
            // 
            // NotificacionsITV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listNoti);
            this.Controls.Add(this.label1);
            this.Name = "NotificacionsITV";
            this.Text = "NotificacionsITV";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listNoti;
    }
}