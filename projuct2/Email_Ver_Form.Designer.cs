namespace projuct2
{
    partial class Email_Ver_Form
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
            this.Ver_Code_Box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Ver_Code_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Ver_Code_Box
            // 
            this.Ver_Code_Box.Location = new System.Drawing.Point(140, 151);
            this.Ver_Code_Box.Name = "Ver_Code_Box";
            this.Ver_Code_Box.Size = new System.Drawing.Size(107, 20);
            this.Ver_Code_Box.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 99);
            this.label1.TabIndex = 1;
            this.label1.Text = "We have sent an Email verification code to your Email. Please insert the code in " +
    "the box bellow to verify your acount.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Ver_Code_Button
            // 
            this.Ver_Code_Button.Location = new System.Drawing.Point(159, 221);
            this.Ver_Code_Button.Name = "Ver_Code_Button";
            this.Ver_Code_Button.Size = new System.Drawing.Size(75, 23);
            this.Ver_Code_Button.TabIndex = 2;
            this.Ver_Code_Button.Text = "Verify";
            this.Ver_Code_Button.UseVisualStyleBackColor = true;
            this.Ver_Code_Button.Click += new System.EventHandler(this.Ver_Code_Button_Click);
            // 
            // Email_Ver_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 339);
            this.Controls.Add(this.Ver_Code_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Ver_Code_Box);
            this.Name = "Email_Ver_Form";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Ver_Code_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Ver_Code_Button;
    }
}