namespace server
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
            this.label1 = new System.Windows.Forms.Label();
            this.portTextPort = new System.Windows.Forms.TextBox();
            this.button_listen = new System.Windows.Forms.Button();
            this.textBox_logs = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clientServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToClientServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // portTextPort
            // 
            this.portTextPort.Location = new System.Drawing.Point(45, 75);
            this.portTextPort.Margin = new System.Windows.Forms.Padding(2);
            this.portTextPort.Name = "portTextPort";
            this.portTextPort.Size = new System.Drawing.Size(132, 20);
            this.portTextPort.TabIndex = 3;
            this.portTextPort.TextChanged += new System.EventHandler(this.textBox_port_TextChanged);
            // 
            // button_listen
            // 
            this.button_listen.Location = new System.Drawing.Point(191, 75);
            this.button_listen.Margin = new System.Windows.Forms.Padding(2);
            this.button_listen.Name = "button_listen";
            this.button_listen.Size = new System.Drawing.Size(80, 20);
            this.button_listen.TabIndex = 4;
            this.button_listen.Text = "Listen";
            this.button_listen.UseVisualStyleBackColor = true;
            this.button_listen.Click += new System.EventHandler(this.button_listen_Click);
            // 
            // textBox_logs
            // 
            this.textBox_logs.Location = new System.Drawing.Point(15, 129);
            this.textBox_logs.Name = "textBox_logs";
            this.textBox_logs.ReadOnly = true;
            this.textBox_logs.Size = new System.Drawing.Size(256, 176);
            this.textBox_logs.TabIndex = 5;
            this.textBox_logs.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(74, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Switter Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Server Log:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientServerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(285, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clientServerToolStripMenuItem
            // 
            this.clientServerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToClientServerToolStripMenuItem});
            this.clientServerToolStripMenuItem.Name = "clientServerToolStripMenuItem";
            this.clientServerToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.clientServerToolStripMenuItem.Text = "Client Side";
            // 
            // goToClientServerToolStripMenuItem
            // 
            this.goToClientServerToolStripMenuItem.Name = "goToClientServerToolStripMenuItem";
            this.goToClientServerToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.goToClientServerToolStripMenuItem.Text = "Go to Client Side";
            this.goToClientServerToolStripMenuItem.Click += new System.EventHandler(this.goToClientServerToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 319);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_logs);
            this.Controls.Add(this.button_listen);
            this.Controls.Add(this.portTextPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox portTextPort;
        private System.Windows.Forms.Button button_listen;
        private System.Windows.Forms.RichTextBox textBox_logs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clientServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToClientServerToolStripMenuItem;
    }
}

