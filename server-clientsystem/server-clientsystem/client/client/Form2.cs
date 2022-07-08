using System;

using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace client
{
    public partial class Form2 : Form
    {
        string name;
        bool terminating = false;
        bool connected = false;
        Socket clientSocket;


        public Form2()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connected = false;
            terminating = true;
            Environment.Exit(0);
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            terminating = false; // to connect after disconnect
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = textBox_IP.Text;
            int portNum;
            name = textBox_Name.Text;
            string serverRespond = "";

            if (name != "" && name.Length <= 10000000) // if name is not empty and longer than 10m
            {
                if (Int32.TryParse(textBox_Port.Text, out portNum))
                {
                    if (textBox_IP.Text != "")
                    {
                        try
                        {
                            clientSocket.Connect(IP, portNum);
                            send_message(name); // we send our username to server and wait for respond
                            serverRespond = receiveOneMessage(); // we got our respond
                            if (serverRespond != "already connected" && serverRespond != "not authorized")
                            {
                                button_connect.Enabled = false;
                                button_disconnect.Enabled = true;
                                button_sendmessage.Enabled = true;
                                refresh_button.Enabled = true;
                                refresh_following.Enabled = true;
                                refresh_following.Enabled = true;
                                blocked_refresh_button.Enabled = true;
                                unblock_user.Enabled = true;
                                block_button.Enabled = true;
                                delete_button.Enabled = true;
                                refresh_followers.Enabled = true;
                                user_sweets_button.Enabled = true;
                                unfollow_button.Enabled = true;
                                request_usernames.Enabled = true;
                                follow_user_text.Enabled = true;
                                refresh_friends.Enabled = true;
                                clear_button.Enabled = true;
                                refresh_button.Enabled = true;
                                sweet_id_text_box.Enabled = true;
                                add_friend.Enabled = true;
                                textBox_Message.Enabled = true;
                                connected = true;
                                button_connect.Text = "Connected";
                                button_connect.BackColor = System.Drawing.Color.Green;
                                button_disconnect.BackColor = System.Drawing.Color.Red;
                                logBox.AppendText("Connection established...\n");
                                logBox.ScrollToCaret();

                                Thread receiveThread = new Thread(Receive);
                                receiveThread.Start();
                            }
                            else if (serverRespond == "not authorized")
                            {
                                logBox.AppendText("You are not registered.\n");
                                logBox.ScrollToCaret();
                            }
                            else if (serverRespond == "already connected")
                            {
                                logBox.AppendText("You are already connected.\n");
                                logBox.ScrollToCaret();
                            }
                        }
                        catch
                        {
                            logBox.AppendText("Could not connect to the server!\n");
                            logBox.ScrollToCaret();
                        }
                    }
                    else
                    {
                        logBox.AppendText("Check the IP\n");
                        logBox.ScrollToCaret();
                    }
                }
                else
                {
                    logBox.AppendText("Check the port\n");
                    logBox.ScrollToCaret();
                }
            }
            else
            {
                textBox_Name.Text = "";
                logBox.AppendText("Name length must between 1 and 10m\n");
                logBox.ScrollToCaret();
            }
        }

        private string receiveOneMessage() // this function receives only one message
        {
            Byte[] buffer = new Byte[10000000];
            clientSocket.Receive(buffer);
            string incomingMessage = Encoding.Default.GetString(buffer);
            incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
            return incomingMessage;
        }

        private void Receive()
        {
            while (connected)
            {
                try
                {
                    string incomingMessage = receiveOneMessage();
                    if (incomingMessage.Contains("R-E-F-R-E-F-H-F-O-L-L-O-W-E-R-S-SEC-KEY"))
                    {
                        incomingMessage = incomingMessage.Replace("R-E-F-R-E-F-H-F-O-L-L-O-W-E-R-S-SEC-KEY", "");
                        followers_text_box.AppendText(incomingMessage);
                    }
                    else if (incomingMessage.Contains("F-R-I-E-N-D-S-R-E-F-R-E-S-H-SEC-KEY")) 
                    {
                        incomingMessage = incomingMessage.Replace("F-R-I-E-N-D-S-R-E-F-R-E-S-H-SEC-KEY", "");
                        followings_text_box.AppendText(incomingMessage);
                    }
                    else if (incomingMessage.Contains("R-E-F-R-E-F-H-B-L-O-C-K-E-D-SEC-KEY"))
                    {
                        incomingMessage = incomingMessage.Replace("R-E-F-R-E-F-H-B-L-O-C-K-E-D-SEC-KEY", "");
                        blocked_text_box.AppendText(incomingMessage);
                    }
                    else
                    {
                        logBox.AppendText(incomingMessage);
                        logBox.ScrollToCaret();
                    }

                    
                }
                catch
                {
                    if (!terminating)
                    {

                        button_disconnect.BackColor = default(Color);
                        button_connect.BackColor = default(Color);
                        button_connect.Text = "Connect";
                        button_connect.Enabled = true;
                        refresh_following.Enabled = false;
                        follow_user_text.Enabled = false;
                        refresh_friends.Enabled = false;
                        unfollow_button.Enabled = false;
                        request_usernames.Enabled = false;
                        refresh_following.Enabled = false;
                        blocked_refresh_button.Enabled = false;
                        unblock_user.Enabled = false;
                        block_button.Enabled = false;
                        delete_button.Enabled = false;
                        refresh_followers.Enabled = false;
                        user_sweets_button.Enabled = false;
                        clear_button.Enabled = false;
                        sweet_id_text_box.Enabled = false;
                        refresh_button.Enabled = false;
                        add_friend.Enabled = false;
                        button_disconnect.Enabled = false;
                        button_sendmessage.Enabled = false;
                        textBox_Message.Enabled = false;
                        clientSocket.Disconnect(true);
                        logBox.AppendText("The server has disconnected\n");
                        logBox.ScrollToCaret();
                    }
                    clientSocket.Close();
                    connected = false;
                }
            }
        }

        private void send_message(string message)
        {
            Byte[] buffer = new Byte[10000000];
            buffer = Encoding.Default.GetBytes(message);
            clientSocket.Send(buffer);
        }

        private void button_sendmessage_Click(object sender, EventArgs e)
        {
            string message = DateTime.Now.ToString("dddd, dd MMMM yyyy") + " - " + name + ": " + textBox_Message.Text + "\n";
            if (textBox_Message.Text != "" && textBox_Message.Text.Length <= 10000000)
            {
                textBox_Message.Text = "";
                send_message(message);
                logBox.AppendText(message);
                logBox.ScrollToCaret();
            }
            else
            {
                textBox_Message.Text = "";
                logBox.AppendText("Message length must between 1 and 10m\n");
                logBox.ScrollToCaret();
            }

        }

        private void button_disconnect_Click(object sender, EventArgs e)
        {
            button_disconnect.BackColor = default(Color);
            button_connect.BackColor = default(Color);
            button_connect.Text = "Connect";
            send_message("D-I-S-C-O-N-N-E-C-T-E-D-SEC-KEY");
            connected = false;
            refresh_button.Enabled = false;
            refresh_following.Enabled = false;
            sweet_id_text_box.Enabled = false;
            blocked_refresh_button.Enabled = false;
            unblock_user.Enabled = false;
            block_button.Enabled = false;
            delete_button.Enabled = false;
            refresh_followers.Enabled = false;
            user_sweets_button.Enabled = false;
            follow_user_text.Enabled = false;
            refresh_friends.Enabled = false;
            add_friend.Enabled = false;
            unfollow_button.Enabled = false;
            clear_button.Enabled = false;
            request_usernames.Enabled = false;
            button_connect.Enabled = true;
            button_disconnect.Enabled = false;
            button_sendmessage.Enabled = false;
            textBox_Message.Enabled = false;
            clientSocket.Disconnect(false);
            logBox.AppendText("Disconnected\n");
            logBox.ScrollToCaret();
        }



        private void refresh_following_Click(object sender, EventArgs e)
        {
            followers_text_box.Clear();
            send_message("R-E-F-R-E-F-H-F-R-I-E-N-D-S-F-E-E-D-SEC-KEY");
            logBox.AppendText("You requested the following users feed...\n");
        }



        private void add_friend_Click(object sender, EventArgs e)
        {
            if (follow_user_text.Text != "")
            {
                string message = "A-D-D-SEC-KEY" + follow_user_text.Text;
                send_message(message);
                logBox.AppendText("You are trying the follow user: " + follow_user_text.Text + "\n");
            }
            else
            {
                logBox.AppendText("You need to write username to follow.\n");
            }

        }

        private void refresh_friends_Click(object sender, EventArgs e)
        {
            followings_text_box.Clear();
            send_message("R-E-F-R-E-F-H-F-R-I-E-N-D-S-SEC-KEY");
            logBox.AppendText("You refreshed your following list...\n");
        }

        private void refresh_button_Click(object sender, EventArgs e)
        {
            send_message("R-E-F-R-E-F-H-F-E-E-D-SEC-KEY");
            logBox.AppendText("You requested the feed..\n");
        }

        private void unfollow_button_Click(object sender, EventArgs e)
        {
            if (follow_user_text.Text != "")
            {
                string message = "R-E-M-O-V-E-SEC-KEY" + follow_user_text.Text;
                send_message(message);
                logBox.AppendText("You are trying the unfollow user: " + follow_user_text.Text + "\n");
            }
            else
            {
                logBox.AppendText("You need to write username to unfollow.\n");
            }
        }

        private void request_usernames_Click(object sender, EventArgs e)
        {
            send_message("R-E-Q-U-E-S-T-U-S-E-R-N-A-M-E-S-SEC-KEY");
            logBox.AppendText("You requested the username list..\n");
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            logBox.Clear();
            logBox.AppendText("You cleared the log..\n");

        }

        private void block_button_Click(object sender, EventArgs e)
        {
            if (follow_user_text.Text == "")
            {
                logBox.AppendText("First enter a username!\n");
            }
            else
            {
                string message = "B-L-O-C-K-U-S-E-R-SEC-KEY" + follow_user_text.Text;
                send_message(message);
                logBox.AppendText("You are trying to block " + follow_user_text + "..\n");
            }
        }

        private void unblock_user_Click(object sender, EventArgs e)
        {
            if (follow_user_text.Text == "")
            {
                logBox.AppendText("First enter a username!\n");
            }
            else
            {
                string message = "U-N-B-L-C-K-U-S-R-SEC-KEY" + follow_user_text.Text;
                send_message(message);
                logBox.AppendText("You are trying to unblock " + follow_user_text.Text + "..\n");
            }
        }

        private void refresh_followers_Click(object sender, EventArgs e)
        {
            followers_text_box.Clear();
            send_message("R-E-F-R-E-F-H-F-O-L-L-O-W-E-R-S-SEC-KEY");
            logBox.AppendText("You refreshed your followers list...\n");
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            if (sweet_id_text_box.Text == "")
            {
                logBox.AppendText("First enter a Sweet ID!\n");
            }
            else
            {
                string message = "D-E-L-E-T-E-S-W-E-E-T-SEC-KEY" + sweet_id_text_box.Text;
                send_message(message);
                logBox.AppendText("You are trying to delete sweet with id " + sweet_id_text_box.Text + "..\n");
            }
        }

        private void user_sweets_button_Click(object sender, EventArgs e)
        {
            send_message("R-E-Q-U-E-S-T-U-S-E-R-S-W-E-E-T-S-SEC-KEY");
            logBox.AppendText("You requested your own sweets...\n");
        }

        private void blocked_refresh_button_Click(object sender, EventArgs e)
        {
            blocked_text_box.Clear();
            send_message("R-E-F-R-E-F-H-B-L-O-C-K-E-D-SEC-KEY");
            logBox.AppendText("You refreshed your followers list...\n");
        }
    }
}
