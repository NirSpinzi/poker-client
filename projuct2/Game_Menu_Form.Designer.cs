namespace projuct2
{
    partial class Game_Menu_Form
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
            this.Menu_label = new System.Windows.Forms.Label();
            this.Find_Match_button = new System.Windows.Forms.Button();
            this.Host_Game_button = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // Menu_label
            // 
            this.Menu_label.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Menu_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Menu_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Menu_label.Location = new System.Drawing.Point(390, 9);
            this.Menu_label.MaximumSize = new System.Drawing.Size(500, 500);
            this.Menu_label.Name = "Menu_label";
            this.Menu_label.Size = new System.Drawing.Size(213, 90);
            this.Menu_label.TabIndex = 2;
            this.Menu_label.Text = "Poker";
            this.Menu_label.Click += new System.EventHandler(this.Menu_label_Click);
            // 
            // Find_Match_button
            // 
            this.Find_Match_button.Font = new System.Drawing.Font("Microsoft JhengHei Light", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Find_Match_button.Location = new System.Drawing.Point(402, 204);
            this.Find_Match_button.Name = "Find_Match_button";
            this.Find_Match_button.Size = new System.Drawing.Size(186, 58);
            this.Find_Match_button.TabIndex = 3;
            this.Find_Match_button.Text = "Join Match";
            this.Find_Match_button.UseVisualStyleBackColor = true;
            this.Find_Match_button.Click += new System.EventHandler(this.Find_Match_button_Click);
            // 
            // Host_Game_button
            // 
            this.Host_Game_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Host_Game_button.Location = new System.Drawing.Point(402, 334);
            this.Host_Game_button.Name = "Host_Game_button";
            this.Host_Game_button.Size = new System.Drawing.Size(186, 58);
            this.Host_Game_button.TabIndex = 4;
            this.Host_Game_button.Text = "Host Game";
            this.Host_Game_button.UseVisualStyleBackColor = true;
            this.Host_Game_button.Click += new System.EventHandler(this.Host_Game_button_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.columnHeader1, this.columnHeader2 });
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(741, 195);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(203, 229);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Lobby";
            this.columnHeader1.Width = 99;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Players";
            this.columnHeader2.Width = 99;
            // 
            // Game_Menu_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 615);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.Host_Game_button);
            this.Controls.Add(this.Find_Match_button);
            this.Controls.Add(this.Menu_label);
            this.Name = "Game_Menu_Form";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;

        private System.Windows.Forms.ListView listView1;

        #endregion

        private System.Windows.Forms.Label Menu_label;
        private System.Windows.Forms.Button Find_Match_button;
        private System.Windows.Forms.Button Host_Game_button;
    }
}