namespace client
{
    partial class Form2
    {
        
        private System.ComponentModel.IContainer components = null;

        
        
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_sendmessage = new System.Windows.Forms.Button();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.refresh_button = new System.Windows.Forms.Button();
            this.follow_user_text = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.blocked_refresh_button = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.blocked_text_box = new System.Windows.Forms.RichTextBox();
            this.refresh_followers = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.followers_text_box = new System.Windows.Forms.RichTextBox();
            this.unblock_user = new System.Windows.Forms.Button();
            this.block_button = new System.Windows.Forms.Button();
            this.unfollow_button = new System.Windows.Forms.Button();
            this.refresh_friends = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.add_friend = new System.Windows.Forms.Button();
            this.followings_text_box = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.refresh_following = new System.Windows.Forms.Button();
            this.request_usernames = new System.Windows.Forms.Button();
            this.clear_button = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.sweet_id_text_box = new System.Windows.Forms.TextBox();
            this.delete_button = new System.Windows.Forms.Button();
            this.user_sweets_button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 173);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Name:";
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(454, 77);
            this.logBox.Margin = new System.Windows.Forms.Padding(6);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(706, 279);
            this.logBox.TabIndex = 14;
            this.logBox.Text = "";
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(102, 254);
            this.button_connect.Margin = new System.Windows.Forms.Padding(6);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(266, 44);
            this.button_connect.TabIndex = 13;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(102, 167);
            this.textBox_Name.Margin = new System.Windows.Forms.Padding(6);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(262, 31);
            this.textBox_Name.TabIndex = 12;
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(102, 117);
            this.textBox_Port.Margin = new System.Windows.Forms.Padding(6);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(262, 31);
            this.textBox_Port.TabIndex = 11;
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(102, 67);
            this.textBox_IP.Margin = new System.Windows.Forms.Padding(6);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(262, 31);
            this.textBox_IP.TabIndex = 10;
            // 
            // textBox_Message
            // 
            this.textBox_Message.Enabled = false;
            this.textBox_Message.Location = new System.Drawing.Point(454, 431);
            this.textBox_Message.Margin = new System.Windows.Forms.Padding(6);
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.Size = new System.Drawing.Size(496, 31);
            this.textBox_Message.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 25);
            this.label4.TabIndex = 19;
            this.label4.Text = "Server Log - Feed: ";
            // 
            // button_sendmessage
            // 
            this.button_sendmessage.Enabled = false;
            this.button_sendmessage.Location = new System.Drawing.Point(966, 427);
            this.button_sendmessage.Margin = new System.Windows.Forms.Padding(6);
            this.button_sendmessage.Name = "button_sendmessage";
            this.button_sendmessage.Size = new System.Drawing.Size(198, 44);
            this.button_sendmessage.TabIndex = 20;
            this.button_sendmessage.Text = "Send To Feed";
            this.button_sendmessage.UseVisualStyleBackColor = true;
            this.button_sendmessage.Click += new System.EventHandler(this.button_sendmessage_Click);
            // 
            // button_disconnect
            // 
            this.button_disconnect.Enabled = false;
            this.button_disconnect.Location = new System.Drawing.Point(102, 321);
            this.button_disconnect.Margin = new System.Windows.Forms.Padding(6);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(266, 44);
            this.button_disconnect.TabIndex = 21;
            this.button_disconnect.Text = "Disconnect";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(24, 10);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 63);
            this.label7.TabIndex = 39;
            this.label7.Text = "Switter";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_disconnect);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button_connect);
            this.groupBox1.Controls.Add(this.textBox_Name);
            this.groupBox1.Controls.Add(this.textBox_Port);
            this.groupBox1.Controls.Add(this.textBox_IP);
            this.groupBox1.Location = new System.Drawing.Point(28, 77);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(402, 394);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect";
            // 
            // refresh_button
            // 
            this.refresh_button.Enabled = false;
            this.refresh_button.Location = new System.Drawing.Point(966, 371);
            this.refresh_button.Margin = new System.Windows.Forms.Padding(6);
            this.refresh_button.Name = "refresh_button";
            this.refresh_button.Size = new System.Drawing.Size(198, 44);
            this.refresh_button.TabIndex = 41;
            this.refresh_button.Text = "Refresh Feed";
            this.refresh_button.UseVisualStyleBackColor = true;
            this.refresh_button.Click += new System.EventHandler(this.refresh_button_Click);
            // 
            // follow_user_text
            // 
            this.follow_user_text.Enabled = false;
            this.follow_user_text.Location = new System.Drawing.Point(152, 50);
            this.follow_user_text.Margin = new System.Windows.Forms.Padding(6);
            this.follow_user_text.Name = "follow_user_text";
            this.follow_user_text.Size = new System.Drawing.Size(234, 31);
            this.follow_user_text.TabIndex = 42;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.blocked_refresh_button);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.blocked_text_box);
            this.groupBox2.Controls.Add(this.refresh_followers);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.followers_text_box);
            this.groupBox2.Controls.Add(this.unblock_user);
            this.groupBox2.Controls.Add(this.block_button);
            this.groupBox2.Controls.Add(this.unfollow_button);
            this.groupBox2.Controls.Add(this.refresh_friends);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.add_friend);
            this.groupBox2.Controls.Add(this.followings_text_box);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.follow_user_text);
            this.groupBox2.Location = new System.Drawing.Point(28, 524);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(1132, 227);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Friends";
            // 
            // blocked_refresh_button
            // 
            this.blocked_refresh_button.Enabled = false;
            this.blocked_refresh_button.Location = new System.Drawing.Point(907, 179);
            this.blocked_refresh_button.Margin = new System.Windows.Forms.Padding(6);
            this.blocked_refresh_button.Name = "blocked_refresh_button";
            this.blocked_refresh_button.Size = new System.Drawing.Size(172, 40);
            this.blocked_refresh_button.TabIndex = 55;
            this.blocked_refresh_button.Text = "Refresh";
            this.blocked_refresh_button.UseVisualStyleBackColor = true;
            this.blocked_refresh_button.Click += new System.EventHandler(this.blocked_refresh_button_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(902, 19);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 25);
            this.label10.TabIndex = 54;
            this.label10.Text = "Blocked:";
            // 
            // blocked_text_box
            // 
            this.blocked_text_box.Location = new System.Drawing.Point(907, 50);
            this.blocked_text_box.Margin = new System.Windows.Forms.Padding(6);
            this.blocked_text_box.Name = "blocked_text_box";
            this.blocked_text_box.ReadOnly = true;
            this.blocked_text_box.Size = new System.Drawing.Size(213, 117);
            this.blocked_text_box.TabIndex = 53;
            this.blocked_text_box.Text = "";
            // 
            // refresh_followers
            // 
            this.refresh_followers.Enabled = false;
            this.refresh_followers.Location = new System.Drawing.Point(660, 179);
            this.refresh_followers.Margin = new System.Windows.Forms.Padding(6);
            this.refresh_followers.Name = "refresh_followers";
            this.refresh_followers.Size = new System.Drawing.Size(172, 40);
            this.refresh_followers.TabIndex = 52;
            this.refresh_followers.Text = "Refresh";
            this.refresh_followers.UseVisualStyleBackColor = true;
            this.refresh_followers.Click += new System.EventHandler(this.refresh_followers_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(655, 19);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 25);
            this.label8.TabIndex = 51;
            this.label8.Text = "Followers:";
            // 
            // followers_text_box
            // 
            this.followers_text_box.Location = new System.Drawing.Point(660, 50);
            this.followers_text_box.Margin = new System.Windows.Forms.Padding(6);
            this.followers_text_box.Name = "followers_text_box";
            this.followers_text_box.ReadOnly = true;
            this.followers_text_box.Size = new System.Drawing.Size(213, 117);
            this.followers_text_box.TabIndex = 50;
            this.followers_text_box.Text = "";
            // 
            // unblock_user
            // 
            this.unblock_user.Enabled = false;
            this.unblock_user.Location = new System.Drawing.Point(214, 168);
            this.unblock_user.Margin = new System.Windows.Forms.Padding(6);
            this.unblock_user.Name = "unblock_user";
            this.unblock_user.Size = new System.Drawing.Size(172, 40);
            this.unblock_user.TabIndex = 49;
            this.unblock_user.Text = "Unblock User";
            this.unblock_user.UseVisualStyleBackColor = true;
            this.unblock_user.Click += new System.EventHandler(this.unblock_user_Click);
            // 
            // block_button
            // 
            this.block_button.Enabled = false;
            this.block_button.Location = new System.Drawing.Point(12, 168);
            this.block_button.Margin = new System.Windows.Forms.Padding(6);
            this.block_button.Name = "block_button";
            this.block_button.Size = new System.Drawing.Size(172, 40);
            this.block_button.TabIndex = 48;
            this.block_button.Text = "Block User";
            this.block_button.UseVisualStyleBackColor = true;
            this.block_button.Click += new System.EventHandler(this.block_button_Click);
            // 
            // unfollow_button
            // 
            this.unfollow_button.Enabled = false;
            this.unfollow_button.Location = new System.Drawing.Point(12, 106);
            this.unfollow_button.Margin = new System.Windows.Forms.Padding(6);
            this.unfollow_button.Name = "unfollow_button";
            this.unfollow_button.Size = new System.Drawing.Size(172, 40);
            this.unfollow_button.TabIndex = 47;
            this.unfollow_button.Text = "Unfollow User";
            this.unfollow_button.UseVisualStyleBackColor = true;
            this.unfollow_button.Click += new System.EventHandler(this.unfollow_button_Click);
            // 
            // refresh_friends
            // 
            this.refresh_friends.Enabled = false;
            this.refresh_friends.Location = new System.Drawing.Point(411, 179);
            this.refresh_friends.Margin = new System.Windows.Forms.Padding(6);
            this.refresh_friends.Name = "refresh_friends";
            this.refresh_friends.Size = new System.Drawing.Size(172, 40);
            this.refresh_friends.TabIndex = 46;
            this.refresh_friends.Text = "Refresh";
            this.refresh_friends.UseVisualStyleBackColor = true;
            this.refresh_friends.Click += new System.EventHandler(this.refresh_friends_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(411, 19);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 25);
            this.label6.TabIndex = 45;
            this.label6.Text = "Following: ";
            // 
            // add_friend
            // 
            this.add_friend.Enabled = false;
            this.add_friend.Location = new System.Drawing.Point(214, 106);
            this.add_friend.Margin = new System.Windows.Forms.Padding(6);
            this.add_friend.Name = "add_friend";
            this.add_friend.Size = new System.Drawing.Size(172, 40);
            this.add_friend.TabIndex = 22;
            this.add_friend.Text = "Follow User";
            this.add_friend.UseVisualStyleBackColor = true;
            this.add_friend.Click += new System.EventHandler(this.add_friend_Click);
            // 
            // followings_text_box
            // 
            this.followings_text_box.Location = new System.Drawing.Point(411, 50);
            this.followings_text_box.Margin = new System.Windows.Forms.Padding(6);
            this.followings_text_box.Name = "followings_text_box";
            this.followings_text_box.ReadOnly = true;
            this.followings_text_box.Size = new System.Drawing.Size(213, 117);
            this.followings_text_box.TabIndex = 44;
            this.followings_text_box.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 56);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 25);
            this.label5.TabIndex = 22;
            this.label5.Text = "Username:";
            // 
            // refresh_following
            // 
            this.refresh_following.Enabled = false;
            this.refresh_following.Location = new System.Drawing.Point(454, 371);
            this.refresh_following.Margin = new System.Windows.Forms.Padding(6);
            this.refresh_following.Name = "refresh_following";
            this.refresh_following.Size = new System.Drawing.Size(198, 44);
            this.refresh_following.TabIndex = 44;
            this.refresh_following.Text = "Refresh Following";
            this.refresh_following.UseVisualStyleBackColor = true;
            this.refresh_following.Click += new System.EventHandler(this.refresh_following_Click);
            // 
            // request_usernames
            // 
            this.request_usernames.Enabled = false;
            this.request_usernames.Location = new System.Drawing.Point(664, 371);
            this.request_usernames.Margin = new System.Windows.Forms.Padding(6);
            this.request_usernames.Name = "request_usernames";
            this.request_usernames.Size = new System.Drawing.Size(234, 44);
            this.request_usernames.TabIndex = 45;
            this.request_usernames.Text = "Request Usernames";
            this.request_usernames.UseVisualStyleBackColor = true;
            this.request_usernames.Click += new System.EventHandler(this.request_usernames_Click);
            // 
            // clear_button
            // 
            this.clear_button.Enabled = false;
            this.clear_button.Location = new System.Drawing.Point(1050, 23);
            this.clear_button.Margin = new System.Windows.Forms.Padding(6);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(114, 44);
            this.clear_button.TabIndex = 46;
            this.clear_button.Text = "Clear";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(471, 496);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 25);
            this.label9.TabIndex = 23;
            this.label9.Text = "Delete Sweet:";
            // 
            // sweet_id_text_box
            // 
            this.sweet_id_text_box.Enabled = false;
            this.sweet_id_text_box.Location = new System.Drawing.Point(628, 490);
            this.sweet_id_text_box.Margin = new System.Windows.Forms.Padding(6);
            this.sweet_id_text_box.Name = "sweet_id_text_box";
            this.sweet_id_text_box.Size = new System.Drawing.Size(120, 31);
            this.sweet_id_text_box.TabIndex = 22;
            // 
            // delete_button
            // 
            this.delete_button.Enabled = false;
            this.delete_button.Location = new System.Drawing.Point(760, 483);
            this.delete_button.Margin = new System.Windows.Forms.Padding(6);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(194, 44);
            this.delete_button.TabIndex = 54;
            this.delete_button.Text = "Delete";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // user_sweets_button
            // 
            this.user_sweets_button.Enabled = false;
            this.user_sweets_button.Location = new System.Drawing.Point(966, 483);
            this.user_sweets_button.Margin = new System.Windows.Forms.Padding(6);
            this.user_sweets_button.Name = "user_sweets_button";
            this.user_sweets_button.Size = new System.Drawing.Size(194, 44);
            this.user_sweets_button.TabIndex = 53;
            this.user_sweets_button.Text = "Your Sweets";
            this.user_sweets_button.UseVisualStyleBackColor = true;
            this.user_sweets_button.Click += new System.EventHandler(this.user_sweets_button_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 766);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.user_sweets_button);
            this.Controls.Add(this.sweet_id_text_box);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.request_usernames);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.refresh_following);
            this.Controls.Add(this.refresh_button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button_sendmessage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.logBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.Text = "Form2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_sendmessage;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button refresh_button;
        private System.Windows.Forms.TextBox follow_user_text;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button refresh_friends;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button add_friend;
        private System.Windows.Forms.RichTextBox followings_text_box;
        private System.Windows.Forms.Button refresh_following;
        private System.Windows.Forms.Button unfollow_button;
        private System.Windows.Forms.Button request_usernames;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Button refresh_followers;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox followers_text_box;
        private System.Windows.Forms.Button unblock_user;
        private System.Windows.Forms.Button block_button;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox sweet_id_text_box;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button user_sweets_button;
        private System.Windows.Forms.Button blocked_refresh_button;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox blocked_text_box;
    }
}

