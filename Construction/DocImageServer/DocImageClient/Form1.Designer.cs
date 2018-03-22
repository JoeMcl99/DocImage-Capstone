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
            this.exit_Btn = new System.Windows.Forms.Button();
            this.account_Btn = new System.Windows.Forms.Button();
            this.chkList_Btn = new System.Windows.Forms.Button();
            this.single_Btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSingleSearch = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtSingleBusinessName = new System.Windows.Forms.TextBox();
            this.txtSingleHstNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSingleResult = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // exit_Btn
            // 
            this.exit_Btn.Location = new System.Drawing.Point(416, 16);
            this.exit_Btn.Name = "exit_Btn";
            this.exit_Btn.Size = new System.Drawing.Size(75, 23);
            this.exit_Btn.TabIndex = 8;
            this.exit_Btn.Text = "Exit";
            this.exit_Btn.UseVisualStyleBackColor = true;
            // 
            // account_Btn
            // 
            this.account_Btn.Location = new System.Drawing.Point(295, 16);
            this.account_Btn.Name = "account_Btn";
            this.account_Btn.Size = new System.Drawing.Size(75, 23);
            this.account_Btn.TabIndex = 7;
            this.account_Btn.Text = "Account Info";
            this.account_Btn.UseVisualStyleBackColor = true;
            // 
            // chkList_Btn
            // 
            this.chkList_Btn.Location = new System.Drawing.Point(171, 16);
            this.chkList_Btn.Name = "chkList_Btn";
            this.chkList_Btn.Size = new System.Drawing.Size(75, 23);
            this.chkList_Btn.TabIndex = 6;
            this.chkList_Btn.Text = "Check List";
            this.chkList_Btn.UseVisualStyleBackColor = true;
            // 
            // single_Btn
            // 
            this.single_Btn.Location = new System.Drawing.Point(62, 16);
            this.single_Btn.Name = "single_Btn";
            this.single_Btn.Size = new System.Drawing.Size(75, 23);
            this.single_Btn.TabIndex = 5;
            this.single_Btn.Text = "Single Check";
            this.single_Btn.UseVisualStyleBackColor = true;
            this.single_Btn.Click += new System.EventHandler(this.single_Btn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.single_Btn);
            this.panel1.Controls.Add(this.exit_Btn);
            this.panel1.Controls.Add(this.chkList_Btn);
            this.panel1.Controls.Add(this.account_Btn);
            this.panel1.Location = new System.Drawing.Point(90, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 341);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSingleSearch);
            this.panel2.Controls.Add(this.btnBack);
            this.panel2.Controls.Add(this.txtSingleBusinessName);
            this.panel2.Controls.Add(this.txtSingleHstNumber);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(90, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 341);
            this.panel2.TabIndex = 10;
            // 
            // btnSingleSearch
            // 
            this.btnSingleSearch.Location = new System.Drawing.Point(238, 144);
            this.btnSingleSearch.Name = "btnSingleSearch";
            this.btnSingleSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSingleSearch.TabIndex = 6;
            this.btnSingleSearch.Text = "Search";
            this.btnSingleSearch.UseVisualStyleBackColor = true;
            this.btnSingleSearch.Click += new System.EventHandler(this.btnSingleSearch_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(59, 191);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtSingleBusinessName
            // 
            this.txtSingleBusinessName.Location = new System.Drawing.Point(238, 99);
            this.txtSingleBusinessName.Name = "txtSingleBusinessName";
            this.txtSingleBusinessName.Size = new System.Drawing.Size(100, 20);
            this.txtSingleBusinessName.TabIndex = 4;
            // 
            // txtSingleHstNumber
            // 
            this.txtSingleHstNumber.Location = new System.Drawing.Point(238, 71);
            this.txtSingleHstNumber.Name = "txtSingleHstNumber";
            this.txtSingleHstNumber.Size = new System.Drawing.Size(100, 20);
            this.txtSingleHstNumber.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Business Name (required)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "GST/HST number (required)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(251, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Single";
            // 
            // txtSingleResult
            // 
            this.txtSingleResult.Location = new System.Drawing.Point(149, 441);
            this.txtSingleResult.Name = "txtSingleResult";
            this.txtSingleResult.Size = new System.Drawing.Size(469, 20);
            this.txtSingleResult.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 496);
            this.Controls.Add(this.txtSingleResult);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button exit_Btn;
        private System.Windows.Forms.Button account_Btn;
        private System.Windows.Forms.Button chkList_Btn;
        private System.Windows.Forms.Button single_Btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSingleSearch;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtSingleBusinessName;
        private System.Windows.Forms.TextBox txtSingleHstNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSingleResult;
    }
}

