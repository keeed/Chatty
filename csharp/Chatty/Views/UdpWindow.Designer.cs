namespace Chatty.Views
{
    partial class UdpWindow
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
            this.groupboxServerControls = new System.Windows.Forms.GroupBox();
            this.buttonServerToggle = new System.Windows.Forms.Button();
            this.labelServerStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textboxPort = new System.Windows.Forms.TextBox();
            this.textboxServerIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textboxChat = new System.Windows.Forms.TextBox();
            this.textboxChatInput = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.groupboxChat = new System.Windows.Forms.GroupBox();
            this.groupboxClientControls = new System.Windows.Forms.GroupBox();
            this.buttonCreateClient = new System.Windows.Forms.Button();
            this.textboxClientPort = new System.Windows.Forms.TextBox();
            this.textboxClientIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupboxServerControls.SuspendLayout();
            this.groupboxChat.SuspendLayout();
            this.groupboxClientControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupboxServerControls
            // 
            this.groupboxServerControls.Controls.Add(this.buttonServerToggle);
            this.groupboxServerControls.Controls.Add(this.labelServerStatus);
            this.groupboxServerControls.Controls.Add(this.label3);
            this.groupboxServerControls.Controls.Add(this.textboxPort);
            this.groupboxServerControls.Controls.Add(this.textboxServerIP);
            this.groupboxServerControls.Controls.Add(this.label2);
            this.groupboxServerControls.Controls.Add(this.label1);
            this.groupboxServerControls.Location = new System.Drawing.Point(12, 12);
            this.groupboxServerControls.Name = "groupboxServerControls";
            this.groupboxServerControls.Size = new System.Drawing.Size(398, 109);
            this.groupboxServerControls.TabIndex = 0;
            this.groupboxServerControls.TabStop = false;
            this.groupboxServerControls.Text = "Server Controls";
            // 
            // buttonServerToggle
            // 
            this.buttonServerToggle.Location = new System.Drawing.Point(285, 49);
            this.buttonServerToggle.Name = "buttonServerToggle";
            this.buttonServerToggle.Size = new System.Drawing.Size(75, 23);
            this.buttonServerToggle.TabIndex = 8;
            this.buttonServerToggle.Text = "Start Server";
            this.buttonServerToggle.UseVisualStyleBackColor = true;
            this.buttonServerToggle.Click += new System.EventHandler(this.buttonServerToggle_Click);
            // 
            // labelServerStatus
            // 
            this.labelServerStatus.AutoSize = true;
            this.labelServerStatus.ForeColor = System.Drawing.Color.Red;
            this.labelServerStatus.Location = new System.Drawing.Point(293, 28);
            this.labelServerStatus.Name = "labelServerStatus";
            this.labelServerStatus.Size = new System.Drawing.Size(67, 13);
            this.labelServerStatus.TabIndex = 7;
            this.labelServerStatus.Text = "Not Running";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Server Status:";
            // 
            // textboxPort
            // 
            this.textboxPort.Location = new System.Drawing.Point(107, 51);
            this.textboxPort.Name = "textboxPort";
            this.textboxPort.Size = new System.Drawing.Size(100, 20);
            this.textboxPort.TabIndex = 3;
            this.textboxPort.Text = "3000";
            // 
            // textboxServerIP
            // 
            this.textboxServerIP.Location = new System.Drawing.Point(107, 25);
            this.textboxServerIP.Name = "textboxServerIP";
            this.textboxServerIP.Size = new System.Drawing.Size(100, 20);
            this.textboxServerIP.TabIndex = 2;
            this.textboxServerIP.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP Address:";
            // 
            // textboxChat
            // 
            this.textboxChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxChat.BackColor = System.Drawing.SystemColors.Window;
            this.textboxChat.Location = new System.Drawing.Point(6, 19);
            this.textboxChat.Multiline = true;
            this.textboxChat.Name = "textboxChat";
            this.textboxChat.ReadOnly = true;
            this.textboxChat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textboxChat.Size = new System.Drawing.Size(614, 222);
            this.textboxChat.TabIndex = 1;
            this.textboxChat.WordWrap = false;
            // 
            // textboxChatInput
            // 
            this.textboxChatInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxChatInput.Location = new System.Drawing.Point(6, 249);
            this.textboxChatInput.Name = "textboxChatInput";
            this.textboxChatInput.Size = new System.Drawing.Size(533, 20);
            this.textboxChatInput.TabIndex = 2;
            this.textboxChatInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textboxChatInput_KeyUp);
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Location = new System.Drawing.Point(545, 246);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 3;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // groupboxChat
            // 
            this.groupboxChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxChat.Controls.Add(this.textboxChat);
            this.groupboxChat.Controls.Add(this.buttonSend);
            this.groupboxChat.Controls.Add(this.textboxChatInput);
            this.groupboxChat.Location = new System.Drawing.Point(12, 127);
            this.groupboxChat.Name = "groupboxChat";
            this.groupboxChat.Size = new System.Drawing.Size(626, 278);
            this.groupboxChat.TabIndex = 4;
            this.groupboxChat.TabStop = false;
            this.groupboxChat.Text = "Chat Client";
            // 
            // groupboxClientControls
            // 
            this.groupboxClientControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxClientControls.Controls.Add(this.buttonCreateClient);
            this.groupboxClientControls.Controls.Add(this.textboxClientPort);
            this.groupboxClientControls.Controls.Add(this.textboxClientIP);
            this.groupboxClientControls.Controls.Add(this.label4);
            this.groupboxClientControls.Controls.Add(this.label5);
            this.groupboxClientControls.Location = new System.Drawing.Point(416, 12);
            this.groupboxClientControls.Name = "groupboxClientControls";
            this.groupboxClientControls.Size = new System.Drawing.Size(222, 109);
            this.groupboxClientControls.TabIndex = 5;
            this.groupboxClientControls.TabStop = false;
            this.groupboxClientControls.Text = "Client Controls";
            // 
            // buttonCreateClient
            // 
            this.buttonCreateClient.Location = new System.Drawing.Point(102, 77);
            this.buttonCreateClient.Name = "buttonCreateClient";
            this.buttonCreateClient.Size = new System.Drawing.Size(100, 23);
            this.buttonCreateClient.TabIndex = 10;
            this.buttonCreateClient.Text = "Create Client";
            this.buttonCreateClient.UseVisualStyleBackColor = true;
            this.buttonCreateClient.Click += new System.EventHandler(this.buttonCreateClient_Click);
            // 
            // textboxClientPort
            // 
            this.textboxClientPort.Location = new System.Drawing.Point(102, 51);
            this.textboxClientPort.Name = "textboxClientPort";
            this.textboxClientPort.Size = new System.Drawing.Size(100, 20);
            this.textboxClientPort.TabIndex = 9;
            this.textboxClientPort.Text = "3500";
            // 
            // textboxClientIP
            // 
            this.textboxClientIP.Location = new System.Drawing.Point(102, 25);
            this.textboxClientIP.Name = "textboxClientIP";
            this.textboxClientIP.Size = new System.Drawing.Size(100, 20);
            this.textboxClientIP.TabIndex = 8;
            this.textboxClientIP.Text = "127.0.0.1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Client Port:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Client IP Address:";
            // 
            // UdpWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 413);
            this.Controls.Add(this.groupboxClientControls);
            this.Controls.Add(this.groupboxChat);
            this.Controls.Add(this.groupboxServerControls);
            this.Name = "UdpWindow";
            this.Text = "UdpClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UdpWindow_FormClosing);
            this.groupboxServerControls.ResumeLayout(false);
            this.groupboxServerControls.PerformLayout();
            this.groupboxChat.ResumeLayout(false);
            this.groupboxChat.PerformLayout();
            this.groupboxClientControls.ResumeLayout(false);
            this.groupboxClientControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupboxServerControls;
        private System.Windows.Forms.TextBox textboxChat;
        private System.Windows.Forms.TextBox textboxChatInput;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.GroupBox groupboxChat;
        private System.Windows.Forms.GroupBox groupboxClientControls;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textboxPort;
        private System.Windows.Forms.TextBox textboxServerIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelServerStatus;
        private System.Windows.Forms.Button buttonServerToggle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textboxClientIP;
        private System.Windows.Forms.TextBox textboxClientPort;
        private System.Windows.Forms.Button buttonCreateClient;
    }
}