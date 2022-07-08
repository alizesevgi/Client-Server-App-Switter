
using client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace server
{
    public partial class Form1 : Form
    {
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Dictionary<string, Socket> clientSocketsDictionary = new Dictionary<string, Socket>(); // keeps (username->client) tuples
        Dictionary<string, List<string>> clientFollowsDictionary = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> clientBlockedDictionary = new Dictionary<string, List<string>>();
        List<string> connectedNames = new List<string>(); // keeps names of connected users
        List<string> registeredUsers = new List<string>(); // keeps names of registered users
        List<string> feed = new List<string>(); // keeps feed
        string feed_path = Path.Combine(Directory.GetCurrentDirectory(), "feed-db.txt");
        string user_path = Path.Combine(Directory.GetCurrentDirectory(), "user-db.txt");
        string following_path = Path.Combine(Directory.GetCurrentDirectory(), "following-db.txt");
        string blocked_path = Path.Combine(Directory.GetCurrentDirectory(), "blocked-db.txt");
        long id = 1;

        bool terminating = false;
        bool listening = false;


        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }
        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listening = false;
            terminating = true;
            Environment.Exit(0);
        }

        private void readFile()
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(user_path);
            while ((line = file.ReadLine()) != null)
            {
                registeredUsers.Add(line); // adds all the names to the registered users hashset
            }
            file.Close();


            System.IO.StreamReader file_2 = new System.IO.StreamReader(feed_path);

            while ((line = file_2.ReadLine()) != null)
            {
                feed.Add(line + "\n"); // adds all the names to the registered users hashset
            }
            id = Int32.Parse(feed[feed.Count - 1]);
            feed.RemoveAt(feed.Count - 1);
            file_2.Close();

            System.IO.StreamReader file_3 = new System.IO.StreamReader(following_path);
            while ((line = file_3.ReadLine()) != null)
            {
                String[] arr = line.Split(';');
                if (arr[1] == "")
                {
                    List<string> temp = new List<string>();
                    clientFollowsDictionary.Add(arr[0], temp);
                }
                else
                {
                    String[] temp = arr[1].Split(',');
                    List<string> temp_list = new List<string>();
                    clientFollowsDictionary.Add(arr[0], temp_list);
                    foreach (var x in temp)
                    {
                        clientFollowsDictionary[arr[0]].Add(x);
                    }
                }
            }

            System.IO.StreamReader file_4 = new System.IO.StreamReader(blocked_path);
            while ((line = file_4.ReadLine()) != null)
            {
                String[] arr = line.Split(';');
                if (arr[1] == "")
                {
                    List<string> temp = new List<string>();
                    clientBlockedDictionary.Add(arr[0], temp);
                }
                else
                {
                    String[] temp = arr[1].Split(',');
                    List<string> temp_list = new List<string>();
                    clientBlockedDictionary.Add(arr[0], temp_list);
                    foreach (var x in temp)
                    {
                        clientBlockedDictionary[arr[0]].Add(x);
                    }
                }
            }
            file_3.Close();

        }
        private void writeFeedToFile()
        {
            using (TextWriter tw = new StreamWriter(feed_path))
            {
                foreach (String s in feed)
                    tw.Write(s);
                tw.WriteLine(id.ToString());
            }
        }

        private void writeFollowingToFile()
        {
            using (TextWriter tw = new StreamWriter(following_path))
            {
                string temp = "";
                foreach (string x in clientFollowsDictionary.Keys)
                {
                    tw.Write(x + ";");
                    foreach (string y in clientFollowsDictionary[x])
                    {
                        temp += y + ",";
                    }
                    if (clientFollowsDictionary[x].Count != 0)
                    {
                        temp = temp.Remove(temp.Length - 1);
                    }
                    tw.Write(temp + "\n");
                    temp = "";
                }
                    
            }
        }

        private void writeBlockedToFile()
        {
            using (TextWriter tw = new StreamWriter(blocked_path))
            {
                string temp = "";
                foreach (string x in clientBlockedDictionary.Keys)
                {
                    tw.Write(x + ";");
                    foreach (string y in clientBlockedDictionary[x])
                    {
                        temp += y + ",";
                    }
                    if (clientBlockedDictionary[x].Count != 0)
                    {
                        temp = temp.Remove(temp.Length - 1);
                    }
                    tw.Write(temp + "\n");
                    temp = "";
                }

            }
        }


        private void send_message(Socket clientSocket,string message) // takes socket and message then sends the message to that socket
        {
            Byte[] buffer = new Byte[10000000];
            buffer = Encoding.Default.GetBytes(message);
            clientSocket.Send(buffer);
        }
        private string recieveNewMessage(Socket clientSocket) // this function receives only one message and returns it
        {
            Byte[] buffer = new Byte[10000000];
            clientSocket.Receive(buffer);
            string incomingMessage = Encoding.Default.GetString(buffer);
            incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
            return incomingMessage;
        }

        private void Accept()
        {
            while (listening)
            {
                try
                {
                    string name =""; // we initialize name to empty string
                    Socket newClient = serverSocket.Accept(); // first we accept the new connection request
                    if (checkClient(newClient,ref name)){ // gets the name and check if name is registered
                        if (!clientSocketsDictionary.ContainsKey(name)) // checks if the user already connected
                        {
                            send_message(newClient, "authorized\n");
                            clientSocketsDictionary.Add(name, newClient);
                            connectedNames.Add(name);
                            textBox_logs.AppendText(name + " is connected.\n");
                            textBox_logs.ScrollToCaret();
                            foreach (string clientName in connectedNames)
                            {
                                if (clientName != name) // check for to don't send it to sender client
                                {
                                    Socket tempSocket = clientSocketsDictionary[clientName]; // we got the socket
                                    send_message(tempSocket, (name + " is connected\n"));
                                }
                            }
                            Thread receiveThread = new Thread(Receive);
                            receiveThread.Start();
                        }
                        else
                        {
                            textBox_logs.AppendText(name + " is trying to connect again\n");
                            textBox_logs.ScrollToCaret();
                            send_message(newClient, "already connected");
                            newClient.Close();
                        }
                    }
                    else{
                        textBox_logs.AppendText(name + " is trying to connect but not registered\n");
                        textBox_logs.ScrollToCaret();
                        send_message(newClient, "not authorized");
                        newClient.Close();
                    }
                }
                catch
                {
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        textBox_logs.AppendText("The socket stopped working.\n");
                        textBox_logs.ScrollToCaret();
                    }

                }
            }
        }

        private bool checkClient(Socket thisClient, ref string name) // gets the name of user and returns that users registiration status
        {
            try
            {
                string incomingMessage = recieveNewMessage(thisClient); // get the name

                if (registeredUsers.Contains(incomingMessage)) // check if name is registered
                {
                    name = incomingMessage;
                    return true;
                }
                else
                {
                    name = incomingMessage;
                    return false;
                }
            }
            catch (Exception ex)
            {
                textBox_logs.AppendText("Fail: " + ex.ToString() + "\n");
                textBox_logs.ScrollToCaret();
                throw;
            }
        }

        private void Receive()
        {
            string name = connectedNames[connectedNames.Count() - 1]; // we got the username
            Socket thisClient = clientSocketsDictionary[name]; // we got the socket that related to the username
            bool connected = true;
            bool flag = false;
            while (connected && !terminating)
            {
                try
                {
                    string incomingMessage = recieveNewMessage(thisClient); // if there are any messages we take it
                    if (incomingMessage == "D-I-S-C-O-N-N-E-C-T-E-D-SEC-KEY")
                    {
                        connected = false;
                        textBox_logs.AppendText(name + " has disconnected\n");
                        textBox_logs.ScrollToCaret();
                    }
                    else if (incomingMessage == "R-E-F-R-E-F-H-F-E-E-D-SEC-KEY")
                    {
                        textBox_logs.AppendText(name + " has requested feed\n");
                        if (feed.Count == 0)
                        {
                            textBox_logs.AppendText("No one shared a sweet yet\n");
                            Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                            send_message(tempSocket, ("Sorry, no one shared a sweet yet :(\n")); // send name and message
                        }
                        else
                        {
                            int sent = 0;
                            int check = 1;
                            foreach (string sweet in feed)
                            {
                                check = 1;
                                foreach (string x in clientBlockedDictionary[name])
                                {
                                    if (sweet.Contains(x))
                                    {
                                        check = 0;
                                    }
                                }
                                if (!sweet.Contains(name) && check == 1)
                                {
                                    sent = 1;
                                    Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                                    send_message(tempSocket, (sweet)); // send name and message
                                }
                            }
                            if (sent != 1)
                            {
                                Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                                send_message(tempSocket, ("Sorry, you are the only one shared a sweet yet :(\n")); // send name and message
                            }
                        }
                        textBox_logs.ScrollToCaret();
                    }
                    else if (incomingMessage == "R-E-F-R-E-F-H-F-R-I-E-N-D-S-SEC-KEY")
                    {
                        textBox_logs.AppendText(name + " has refreshed following list\n");
                        if (clientFollowsDictionary[name].Count == 0)
                        {
                            textBox_logs.AppendText(name + " is not following anyone\n");
                            Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                            send_message(tempSocket, ("Sorry, you are not following anyone yet\n")); // send name and message
                        }
                        else
                        {
                            foreach (string friend in clientFollowsDictionary[name])
                            {
                                Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                                send_message(tempSocket, ("F-R-I-E-N-D-S-R-E-F-R-E-S-H-SEC-KEY" + friend + "\n")); // send name and message
                            }
                        }
                        textBox_logs.ScrollToCaret();
                    }
                    else if (incomingMessage == "R-E-Q-U-E-S-T-U-S-E-R-N-A-M-E-S-SEC-KEY")
                    {
                        textBox_logs.AppendText(name + " has requested username list\n");

                        foreach (string username in registeredUsers)
                        {
                            string message = username + "\n";
                            Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                            send_message(tempSocket, (message)); // send name and message
                        }

                        textBox_logs.ScrollToCaret();
                    }
                    else if (incomingMessage.Contains("A-D-D-SEC-KEY"))
                    {
                        string user = incomingMessage.Substring(13);
                        textBox_logs.AppendText(name + " trys to follow: " + user + "\n");
                        if (user == name)
                        {
                            textBox_logs.AppendText("Users cannot follow theirselves\n");
                            Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                            send_message(tempSocket, ("Sorry, you cannot follow yourself\n")); // send name and message
                        }
                        else if (registeredUsers.Contains(user))
                        {
                            if (clientFollowsDictionary[name].Contains(user))
                            {
                                textBox_logs.AppendText(name + " already follows the user: " + user + "\n");
                                Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                                send_message(tempSocket, ("You already following the user " + user + ", please refresh friends to see\n")); // send name and message
                            }
                            else
                            {
                                clientFollowsDictionary[name].Add(user);
                                textBox_logs.AppendText(name + " sucessfully followed the user: " + user + "\n");
                                Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                                send_message(tempSocket, ("You sucessfully followed the user " + user + ", please refresh friends to see\n")); // send name and message
                                writeFollowingToFile();
                            }

                        }
                        else
                        {
                            textBox_logs.AppendText("Username cannot found\n");
                            Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                            send_message(tempSocket, ("Sorry, username you entered is not registered. Try again\n")); // send name and message
                        }
                        textBox_logs.ScrollToCaret();
                    }
                    else if (incomingMessage.Contains("R-E-M-O-V-E-SEC-KEY"))
                    {
                        string user = incomingMessage.Substring(19);
                        textBox_logs.AppendText(name + " trys to unfollow: " + user + "\n");
                        if (user == name)
                        {
                            textBox_logs.AppendText("Users cannot unfollow theirselves\n");
                            Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                            send_message(tempSocket, ("Sorry, you cannot unfollow yourself\n")); // send name and message
                        }
                        else if (clientFollowsDictionary[name].Contains(user))
                        {
                            clientFollowsDictionary[name].Remove(user);
                            textBox_logs.AppendText(name + " sucessfully unfollowed the user: " + user + "\n");
                            Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                            send_message(tempSocket, ("You sucessfully unfollowed the user " + user + ", please refresh friends to see\n")); // send name and message
                            writeFollowingToFile();

                        }
                        else
                        {
                            textBox_logs.AppendText("There is no user following with given username\n");
                            Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                            send_message(tempSocket, ("Sorry, there is no user following with given username. Try again\n")); // send name and message
                        }
                        textBox_logs.ScrollToCaret();
                    }
                    else if (incomingMessage == "R-E-F-R-E-F-H-F-R-I-E-N-D-S-F-E-E-D-SEC-KEY")
                    {
                        textBox_logs.AppendText(name + " has requested following users feed\n");
                        if (feed.Count == 0)
                        {
                            textBox_logs.AppendText("No one shared a sweet yet\n");
                            Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                            send_message(tempSocket, ("Sorry, no one shared a sweet yet :(\n")); // send name and message
                        }
                        else if (clientFollowsDictionary[name] == null)
                        {
                            Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                            send_message(tempSocket, ("Sorry, no following user shared a tweet yet :(\n")); // send name and message
                        }
                        else
                        {
                            int sent = 0;
                            foreach (string sweet in feed)
                            {
                                foreach (string following in clientFollowsDictionary[name])
                                {
                                    if (!sweet.Contains(name) && sweet.Contains(following))
                                    {
                                        sent = 1;
                                        Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                                        send_message(tempSocket, (sweet)); // send name and message
                                    }
                                }

                            }
                            if (sent != 1)
                            {
                                Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                                send_message(tempSocket, ("Sorry, no following user shared a sweet yet :(\n")); // send name and message
                            }
                        }
                        textBox_logs.ScrollToCaret();
                    }
                    else if (incomingMessage == "R-E-Q-U-E-S-T-U-S-E-R-S-W-E-E-T-S-SEC-KEY")
                    {
                        textBox_logs.AppendText(name + " has requested his/her own feed\n");
                        int sent = 0;
                        foreach (string sweet in feed)
                        {
                            if (sweet.Contains(name))
                            {
                                sent = 1;
                                Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                                send_message(tempSocket, (sweet)); // send name and message
                            }
                        }
                        if (sent != 1)
                        {
                            Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                            send_message(tempSocket, ("Sorry, you didn't shared any sweet yet :(\n")); // send name and message
                        }
                        textBox_logs.ScrollToCaret();
                    }
                    else if (incomingMessage == "R-E-F-R-E-F-H-F-O-L-L-O-W-E-R-S-SEC-KEY")
                    {
                        textBox_logs.AppendText(name + " has refreshed followers list\n");
                        int sent = 0;
                        foreach (string user in clientFollowsDictionary.Keys)
                        {
                            if (clientFollowsDictionary[user].Contains(name))
                            {
                                sent = 1;
                                Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                                send_message(tempSocket, ("R-E-F-R-E-F-H-F-O-L-L-O-W-E-R-S-SEC-KEY" + user + "\n")); // send name and message
                            }
                        }
                        
                        if (sent != 1)
                        {
                            Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                            send_message(tempSocket, ("Sorry, you don't have any follower yet :(\n")); // send name and message
                        }
                        textBox_logs.ScrollToCaret();
                    }
                    else if (incomingMessage == "R-E-F-R-E-F-H-B-L-O-C-K-E-D-SEC-KEY")
                    {
                        textBox_logs.AppendText(name + " has refreshed blocked users list\n");
                        if (clientBlockedDictionary[name].Count != 0)
                        {
                            foreach (string banned in clientBlockedDictionary[name])
                            {
                                Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                                send_message(tempSocket, ("R-E-F-R-E-F-H-B-L-O-C-K-E-D-SEC-KEY" + banned + "\n")); // send name and message
                            }
                        }
                       else
                        {
                            Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                            send_message(tempSocket, ("Sorry, you didn't blocked any user yet :(\n")); // send name and message
                        }
                        textBox_logs.ScrollToCaret();
                    }
                    else if (incomingMessage.Contains("U-N-B-L-C-K-U-S-R-SEC-KEY"))
                    {
                        string user = incomingMessage.Substring(25);
                        textBox_logs.AppendText(name + " trys to unblock: " + user + "\n");
                        if (user == name)
                        {
                            textBox_logs.AppendText("Users cannot ublock theirselves\n");
                            Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                            send_message(tempSocket, ("Sorry, you cannot unblock yourself\n")); // send name and message
                        }
                        else if (registeredUsers.Contains(user))
                        {
                            if (clientBlockedDictionary[name].Contains(user))
                            {
                                clientBlockedDictionary[name].Remove(user);
                                textBox_logs.AppendText(name + " sucessfully unblocked the user: " + user + "\n");
                                Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                                send_message(tempSocket, ("You sucessfully unblocked the user " + user + ", please refresh blocked users to see\n")); // send name and message
                                writeBlockedToFile();
                            }
                            else
                            {
                                textBox_logs.AppendText(name + " already blocked the user: " + user + "\n");
                                Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                                send_message(tempSocket, ("You already unblocked the user " + user + ", please refresh unblocked users to see\n")); // send name and message
                            }
                        }
                        else
                        {
                            textBox_logs.AppendText("Username cannot found\n");
                            Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                            send_message(tempSocket, ("Sorry, username you entered is not registered. Try again\n")); // send name and message
                        }
                        textBox_logs.ScrollToCaret();
                    }
                    else if (incomingMessage.Contains("D-E-L-E-T-E-S-W-E-E-T-SEC-KEY"))
                    {
                        string id = incomingMessage.Substring(29);
                        textBox_logs.AppendText(name + " trys to delete sweet with id " + id +"\n");
                        int found = -1;
                        foreach (string sweet in feed)
                        {
                            if (sweet.StartsWith(id) && sweet.Contains(name))
                            {
                                feed.Remove(sweet);
                                found = 1;
                                textBox_logs.AppendText(name + " sucessfully deleted the sweet with id: " + id + "\n");
                                Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                                string message = "You sucessfully deleted the sweet with id: " + id + "\n";
                                send_message(tempSocket, ("You sucessfully deleted the sweet with id: " + id + "\n"));
                                writeFeedToFile();
                                break; 
                            }
                        }
                        if (found !=1)
                        {
                            Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                            send_message(tempSocket, ("Sorry, there is no tweet of yours with given id. Try again\n"));
                        }
                        textBox_logs.ScrollToCaret();
                    }
                    else if (incomingMessage.Contains("B-L-O-C-K-U-S-E-R-SEC-KEY"))
                    {
                        string user = incomingMessage.Substring(25);
                        textBox_logs.AppendText(name + " trys to block: " + user + "\n");
                        if (user == name)
                        {
                            textBox_logs.AppendText("Users cannot block theirselves\n");
                            Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                            send_message(tempSocket, ("Sorry, you cannot block yourself\n")); // send name and message
                        }
                        else if (registeredUsers.Contains(user))
                        {
                            if (clientBlockedDictionary[name].Contains(user))
                            {
                                textBox_logs.AppendText(name + " already blocked the user: " + user + "\n");
                                Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                                send_message(tempSocket, ("You already blocked the user " + user + ", please refresh blocked users to see\n")); // send name and message
                            }
                            else
                            {
                                clientBlockedDictionary[name].Add(user);
                                if (clientFollowsDictionary[name].Contains(user))
                                {
                                    clientFollowsDictionary[name].Remove(user);
                                }
                                if (clientFollowsDictionary[user].Contains(name))
                                {
                                    clientFollowsDictionary[user].Remove(name);
                                }
                                textBox_logs.AppendText(name + " sucessfully blocked the user: " + user + "\n");
                                Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                                send_message(tempSocket, ("You sucessfully blocked the user " + user + ", please refresh blocked users to see\n")); // send name and message
                                writeFollowingToFile();
                                writeBlockedToFile();
                            }
                        }
                        else
                        {
                            textBox_logs.AppendText("Username cannot found\n");
                            Socket tempSocket = clientSocketsDictionary[name]; // we got the socket
                            send_message(tempSocket, ("Sorry, username you entered is not registered. Try again\n")); // send name and message
                        }
                        textBox_logs.ScrollToCaret();
                    }
                    else
                    {
                        incomingMessage = id.ToString() + " - " + incomingMessage;
                        id++;
                        textBox_logs.AppendText(incomingMessage);
                        textBox_logs.ScrollToCaret();
                        feed.Add(incomingMessage);
                        writeFeedToFile();
                    }
                }
                catch
                {
                    flag = true;
                    foreach (string clientName in connectedNames)
                    {
                        if (clientName != name) // check for to don't send it to sender client
                        {
                            Socket tempSocket = clientSocketsDictionary[clientName]; // we got the socket
                            send_message(tempSocket, (name + " has disconnected\n"));
                        }
                    }
                    textBox_logs.AppendText(name +" has disconnected\n");
                    textBox_logs.ScrollToCaret();
                    thisClient.Close();
                    connectedNames.Remove(name);
                    clientSocketsDictionary.Remove(name);
                    connected = false;
                }
            }
            if (!connected && !flag)
            {
                foreach (string clientName in connectedNames)
                {
                    if (clientName != name) // check for to don't send it to sender client
                    {
                        Socket tempSocket = clientSocketsDictionary[clientName]; // we got the socket
                        send_message(tempSocket, (name + " has disconnected\n"));
                    }
                }
                thisClient.Close();
                connectedNames.Remove(name);
                clientSocketsDictionary.Remove(name);
            }
        }

        private void button_listen_Click(object sender, EventArgs e)
        {
            int serverPort;
            readFile(); // reads the database
            if (Int32.TryParse(portTextPort.Text, out serverPort)) // if we can parse the input port number
            {
                if (serverPort <= 65535 && serverPort>=0)
                {
                    try
                    {
                        IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                        serverSocket.Bind(endPoint);
                        serverSocket.Listen(300);
                    }
                    catch (Exception ex)
                    {
                        textBox_logs.AppendText("Fail: " + ex.ToString() + "\n");
                        textBox_logs.ScrollToCaret();
                    }

                    listening = true;
                    button_listen.Enabled = false;
                    button_listen.Text = "Listening";
                    button_listen.BackColor = Color.Green;

                    Thread acceptThread = new Thread(Accept);
                    acceptThread.Start();

                    textBox_logs.AppendText("Started listening on port: " + serverPort + "\n");
                    textBox_logs.ScrollToCaret();
                }
                else
                {
                    textBox_logs.AppendText("Port number should be between 0 and 65535\n");
                    textBox_logs.ScrollToCaret();
                }
            }
            else
            {
                textBox_logs.AppendText("Please check port number \n");
                textBox_logs.ScrollToCaret();
            }
        }

        private void textBox_port_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void goToClientServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();


        }


    }
}
