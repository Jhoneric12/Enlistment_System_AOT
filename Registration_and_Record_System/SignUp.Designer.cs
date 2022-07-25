namespace Registration_and_Record_System
{
    partial class SignUp
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBackToSignIn = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMakeUser = new System.Windows.Forms.TextBox();
            this.txtMakePass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chckBx_ShowPass = new System.Windows.Forms.CheckBox();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(85)))), ((int)(((byte)(63)))));
            this.panel1.Controls.Add(this.btnBackToSignIn);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 30);
            this.panel1.TabIndex = 1;
            // 
            // btnBackToSignIn
            // 
            this.btnBackToSignIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(85)))), ((int)(((byte)(63)))));
            this.btnBackToSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToSignIn.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToSignIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBackToSignIn.Location = new System.Drawing.Point(0, 0);
            this.btnBackToSignIn.Name = "btnBackToSignIn";
            this.btnBackToSignIn.Size = new System.Drawing.Size(191, 30);
            this.btnBackToSignIn.TabIndex = 10;
            this.btnBackToSignIn.TabStop = false;
            this.btnBackToSignIn.Text = "◄  BACK TO SIGN IN";
            this.btnBackToSignIn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBackToSignIn.UseVisualStyleBackColor = false;
            this.btnBackToSignIn.Click += new System.EventHandler(this.btnBackToSignIn_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExit.Location = new System.Drawing.Point(609, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(25, 24);
            this.btnExit.TabIndex = 9;
            this.btnExit.TabStop = false;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(196, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Make Username";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtMakeUser
            // 
            this.txtMakeUser.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMakeUser.Location = new System.Drawing.Point(200, 84);
            this.txtMakeUser.Name = "txtMakeUser";
            this.txtMakeUser.Size = new System.Drawing.Size(273, 28);
            this.txtMakeUser.TabIndex = 4;
            this.txtMakeUser.TextChanged += new System.EventHandler(this.txtMakeUser_TextChanged);
            // 
            // txtMakePass
            // 
            this.txtMakePass.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMakePass.Location = new System.Drawing.Point(200, 144);
            this.txtMakePass.Name = "txtMakePass";
            this.txtMakePass.Size = new System.Drawing.Size(273, 28);
            this.txtMakePass.TabIndex = 6;
            this.txtMakePass.UseSystemPasswordChar = true;
            this.txtMakePass.TextChanged += new System.EventHandler(this.txtMakePass_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(196, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Make Password";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // chckBx_ShowPass
            // 
            this.chckBx_ShowPass.AutoSize = true;
            this.chckBx_ShowPass.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckBx_ShowPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chckBx_ShowPass.Location = new System.Drawing.Point(200, 179);
            this.chckBx_ShowPass.Name = "chckBx_ShowPass";
            this.chckBx_ShowPass.Size = new System.Drawing.Size(135, 23);
            this.chckBx_ShowPass.TabIndex = 8;
            this.chckBx_ShowPass.TabStop = false;
            this.chckBx_ShowPass.Text = "Show Password";
            this.chckBx_ShowPass.UseVisualStyleBackColor = true;
            this.chckBx_ShowPass.CheckedChanged += new System.EventHandler(this.chckBx_ShowPass_CheckedChanged);
            // 
            // btnSignUp
            // 
            this.btnSignUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.btnSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignUp.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSignUp.Location = new System.Drawing.Point(200, 208);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(273, 37);
            this.btnSignUp.TabIndex = 9;
            this.btnSignUp.TabStop = false;
            this.btnSignUp.Text = "SIGN UP";
            this.btnSignUp.UseVisualStyleBackColor = false;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(64)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(642, 269);
            this.ControlBox = false;
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.chckBx_ShowPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMakePass);
            this.Controls.Add(this.txtMakeUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SignUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignUp";
            this.Load += new System.EventHandler(this.SignUp_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMakeUser;
        private System.Windows.Forms.TextBox txtMakePass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chckBx_ShowPass;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Button btnBackToSignIn;
        private System.Windows.Forms.Button btnExit;
    }
}