namespace Chatty
{
    partial class Home
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
            this.buttonLaunchTcp = new System.Windows.Forms.Button();
            this.tcpGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonLaunchUdp = new System.Windows.Forms.Button();
            this.tcpGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLaunchTcp
            // 
            this.buttonLaunchTcp.Location = new System.Drawing.Point(26, 19);
            this.buttonLaunchTcp.Name = "buttonLaunchTcp";
            this.buttonLaunchTcp.Size = new System.Drawing.Size(75, 23);
            this.buttonLaunchTcp.TabIndex = 0;
            this.buttonLaunchTcp.Text = "Launch";
            this.buttonLaunchTcp.UseVisualStyleBackColor = true;
            this.buttonLaunchTcp.Click += new System.EventHandler(this.buttonLaunchTcp_Click);
            // 
            // tcpGroupBox
            // 
            this.tcpGroupBox.Controls.Add(this.buttonLaunchTcp);
            this.tcpGroupBox.Location = new System.Drawing.Point(12, 12);
            this.tcpGroupBox.Name = "tcpGroupBox";
            this.tcpGroupBox.Size = new System.Drawing.Size(136, 57);
            this.tcpGroupBox.TabIndex = 1;
            this.tcpGroupBox.TabStop = false;
            this.tcpGroupBox.Text = "TCP Chat";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonLaunchUdp);
            this.groupBox2.Location = new System.Drawing.Point(154, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(125, 57);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "UDP Chat";
            // 
            // buttonLaunchUdp
            // 
            this.buttonLaunchUdp.Location = new System.Drawing.Point(28, 19);
            this.buttonLaunchUdp.Name = "buttonLaunchUdp";
            this.buttonLaunchUdp.Size = new System.Drawing.Size(75, 23);
            this.buttonLaunchUdp.TabIndex = 0;
            this.buttonLaunchUdp.Text = "Launch";
            this.buttonLaunchUdp.UseVisualStyleBackColor = true;
            this.buttonLaunchUdp.Click += new System.EventHandler(this.buttonLaunchUdp_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 80);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tcpGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chatty";
            this.tcpGroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLaunchTcp;
        private System.Windows.Forms.GroupBox tcpGroupBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonLaunchUdp;
    }
}

