namespace DocImageClient
{
    partial class Form1
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
            this.txtExample = new System.Windows.Forms.TextBox();
            this.exit_Btn = new System.Windows.Forms.Button();
            this.account_Btn = new System.Windows.Forms.Button();
            this.chkList_Btn = new System.Windows.Forms.Button();
            this.single_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtExample
            // 
            this.txtExample.Location = new System.Drawing.Point(53, 12);
            this.txtExample.Name = "txtExample";
            this.txtExample.Size = new System.Drawing.Size(100, 20);
            this.txtExample.TabIndex = 0;
            // 
            // exit_Btn
            // 
            this.exit_Btn.Location = new System.Drawing.Point(330, 156);
            this.exit_Btn.Name = "exit_Btn";
            this.exit_Btn.Size = new System.Drawing.Size(75, 23);
            this.exit_Btn.TabIndex = 8;
            this.exit_Btn.Text = "Exit";
            this.exit_Btn.UseVisualStyleBackColor = true;
            // 
            // account_Btn
            // 
            this.account_Btn.Location = new System.Drawing.Point(204, 156);
            this.account_Btn.Name = "account_Btn";
            this.account_Btn.Size = new System.Drawing.Size(75, 23);
            this.account_Btn.TabIndex = 7;
            this.account_Btn.Text = "Account Info";
            this.account_Btn.UseVisualStyleBackColor = true;
            // 
            // chkList_Btn
            // 
            this.chkList_Btn.Location = new System.Drawing.Point(80, 156);
            this.chkList_Btn.Name = "chkList_Btn";
            this.chkList_Btn.Size = new System.Drawing.Size(75, 23);
            this.chkList_Btn.TabIndex = 6;
            this.chkList_Btn.Text = "Check List";
            this.chkList_Btn.UseVisualStyleBackColor = true;
            // 
            // single_Btn
            // 
            this.single_Btn.Location = new System.Drawing.Point(-29, 156);
            this.single_Btn.Name = "single_Btn";
            this.single_Btn.Size = new System.Drawing.Size(75, 23);
            this.single_Btn.TabIndex = 5;
            this.single_Btn.Text = "Single Check";
            this.single_Btn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 496);
            this.Controls.Add(this.exit_Btn);
            this.Controls.Add(this.account_Btn);
            this.Controls.Add(this.chkList_Btn);
            this.Controls.Add(this.single_Btn);
            this.Controls.Add(this.txtExample);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtExample;
        private System.Windows.Forms.Button exit_Btn;
        private System.Windows.Forms.Button account_Btn;
        private System.Windows.Forms.Button chkList_Btn;
        private System.Windows.Forms.Button single_Btn;
    }
}

