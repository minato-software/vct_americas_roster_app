namespace presentationLayer
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnCreateTeam = new Button();
            btnViewTeam = new Button();
            btnUpdateTeam = new Button();
            btnDeleteTeam = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(43, 96);
            flowLayoutPanel1.Margin = new Padding(4, 2, 4, 2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(6, 4, 6, 4);
            flowLayoutPanel1.Size = new Size(700, 774);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnCreateTeam
            // 
            btnCreateTeam.Location = new Point(776, 224);
            btnCreateTeam.Margin = new Padding(4, 2, 4, 2);
            btnCreateTeam.Name = "btnCreateTeam";
            btnCreateTeam.Size = new Size(375, 81);
            btnCreateTeam.TabIndex = 1;
            btnCreateTeam.Text = "Create a Team";
            btnCreateTeam.UseVisualStyleBackColor = true;
            btnCreateTeam.Click += btnCreateTeam_Click;
            // 
            // btnViewTeam
            // 
            btnViewTeam.Location = new Point(776, 341);
            btnViewTeam.Margin = new Padding(4, 2, 4, 2);
            btnViewTeam.Name = "btnViewTeam";
            btnViewTeam.Size = new Size(375, 81);
            btnViewTeam.TabIndex = 2;
            btnViewTeam.Text = "View a Team";
            btnViewTeam.UseVisualStyleBackColor = true;
            btnViewTeam.Click += btnViewTeam_Click;
            // 
            // btnUpdateTeam
            // 
            btnUpdateTeam.Location = new Point(776, 467);
            btnUpdateTeam.Margin = new Padding(4, 2, 4, 2);
            btnUpdateTeam.Name = "btnUpdateTeam";
            btnUpdateTeam.Size = new Size(375, 81);
            btnUpdateTeam.TabIndex = 3;
            btnUpdateTeam.Text = "Update a Team";
            btnUpdateTeam.UseVisualStyleBackColor = true;
            btnUpdateTeam.Click += btnUpdateTeam_Click;
            // 
            // btnDeleteTeam
            // 
            btnDeleteTeam.Location = new Point(776, 580);
            btnDeleteTeam.Margin = new Padding(4, 2, 4, 2);
            btnDeleteTeam.Name = "btnDeleteTeam";
            btnDeleteTeam.Size = new Size(375, 81);
            btnDeleteTeam.TabIndex = 4;
            btnDeleteTeam.Text = "Delete a Team";
            btnDeleteTeam.UseVisualStyleBackColor = true;
            btnDeleteTeam.Click += btnDeleteTeam_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(54, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(612, 55);
            label1.TabIndex = 5;
            label1.Text = "VCT Americas Roster Engine";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(823, 55);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(174, 32);
            label2.TabIndex = 6;
            label2.Text = "Selected Team:";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1194, 911);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDeleteTeam);
            Controls.Add(btnUpdateTeam);
            Controls.Add(btnViewTeam);
            Controls.Add(btnCreateTeam);
            Controls.Add(flowLayoutPanel1);
            Margin = new Padding(4, 2, 4, 2);
            Name = "Main";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnCreateTeam;
        private Button btnViewTeam;
        private Button btnUpdateTeam;
        private Button btnDeleteTeam;
        private Label label1;
        private Label label2;
    }
}
