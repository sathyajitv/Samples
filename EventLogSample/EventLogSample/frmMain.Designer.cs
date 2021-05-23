
namespace EventLogSample
{
    partial class frmMain
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
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnWriteMessage = new System.Windows.Forms.Button();
            this.btnWriteException = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(30, 38);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(498, 67);
            this.txtMessage.TabIndex = 0;
            // 
            // btnWriteMessage
            // 
            this.btnWriteMessage.Location = new System.Drawing.Point(547, 38);
            this.btnWriteMessage.Name = "btnWriteMessage";
            this.btnWriteMessage.Size = new System.Drawing.Size(106, 23);
            this.btnWriteMessage.TabIndex = 1;
            this.btnWriteMessage.Text = "Write Message";
            this.btnWriteMessage.UseVisualStyleBackColor = true;
            this.btnWriteMessage.Click += new System.EventHandler(this.btnWriteMessage_Click);
            // 
            // btnWriteException
            // 
            this.btnWriteException.Location = new System.Drawing.Point(547, 82);
            this.btnWriteException.Name = "btnWriteException";
            this.btnWriteException.Size = new System.Drawing.Size(106, 23);
            this.btnWriteException.TabIndex = 2;
            this.btnWriteException.Text = "Write Exception";
            this.btnWriteException.UseVisualStyleBackColor = true;
            this.btnWriteException.Click += new System.EventHandler(this.btnWriteException_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 194);
            this.Controls.Add(this.btnWriteException);
            this.Controls.Add(this.btnWriteMessage);
            this.Controls.Add(this.txtMessage);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Write To Event Log";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnWriteMessage;
        private System.Windows.Forms.Button btnWriteException;
    }
}

