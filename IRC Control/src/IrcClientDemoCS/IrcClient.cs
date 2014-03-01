/* ***********************************
* Created by KoBE at TechLifeForum
* http://tech.reboot.pro
*
* Updated for this project by
* James Iyouboushi
*************************************/

using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.ComponentModel;
namespace TechLifeForum
{
    /// <summary>
    /// IRC Client class written at http://tech.reboot.pro
    /// </summary>
    public class IrcClient
    {
        #region Variables
        // default server
        private string _server = "irc.esper.net";

        // default port
        private int _port = 6667;

        private string _ServerPass = "";

        // default nick
        private string _nick = "BadGamingBot";

        // default alternate nick
        private string _altNick = "";

        // private TcpClient used to talk to the server
        private TcpClient irc;

        // private network stream used to read/write from/to
        private NetworkStream stream;

        // global variable used to read input from the client
        private string inputLine;

        // stream reader to read from the network stream
        private StreamReader reader;

        // stream writer to write to the stream
        private StreamWriter writer;

        // AsyncOperation used to handle cross-thread wonderness
        private AsyncOperation op;

        #endregion

        #region Constructors
        /// <summary>
        /// IrcClient used to connect to an IRC Server
        /// </summary>
        /// <param name="Server">IRC Server</param>
        /// <param name="Port">IRC Port (6667 if you are unsure)</param>
        public IrcClient(string Server, int Port)
        {
            op = AsyncOperationManager.CreateOperation(null);
            _server = Server;
            _port = Port;
        }
        public IrcClient(string Server) : this(Server,6667)
        {
            op = AsyncOperationManager.CreateOperation(null);
            _server = Server;
            _port = 6667;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Returns the Server address used
        /// </summary>
        public string Server
        {
            get { return _server; }
        }
        /// <summary>
        /// Returns the Port used
        /// </summary>
        public int Port
        {
            get { return _port; }
        }
        /// <summary>
        /// Returns the password used to auth to the server
        /// </summary>
        public string ServerPass
        {
            get { return _ServerPass; }
            set { _ServerPass = value; }
        }
        /// <summary>
        /// Returns the current nick being used.
        /// </summary>
        public string Nick
        {
            get { return _nick; }
            set { _nick = value; }
        }
        /// <summary>
        /// Returns the alternate nick being used
        /// </summary>
        public string AltNick
        {
            get { return _altNick; }
            set { _altNick = value; }
        }
        /// <summary>
        /// Returns true if the client is connected.
        /// </summary>
        public bool Connected
        {
            get
            {
                if (irc != null)
                    if (irc.Connected)
                        return true;
                return false;
            }
        }
        #endregion

        #region Events

        public event UpdateUserListEventDelegate UpdateUsers;
        public event UserJoinedEventDelegate UserJoined;
        public event UserLeftEventDelegate UserLeft;
        public event UserNickChangeEventDelegate UserNickChange;

        public event ChannelMesssageEventDelegate ChannelMessage;
        public event NoticeMessageEventDelegate NoticeMessage;
        public event PrivateMessageEventDelegate PrivateMessage;
        public event ServerMessageEventDelegate ServerMessage;

        public event NickTakenEventDelegate NickTaken;

        public event ConnectedEventDelegate OnConnect;
        //public event DisconnectedEventDelegate Disconnected;

        public event ExceptionThrownEventDelegate ExceptionThrown;

        private void Fire_UpdateUsers(oUserList o)
        {
            //
            // op.Post(x => Fire_UpdateUsers((oUserList)x), new oUserList(channel,users));
            //

            if (UpdateUsers != null) UpdateUsers(o.Channel, o.UserList);
        }
        private void Fire_UserJoined(oUserJoined o)
        {
            //
            // op.Post(x => Fire_UserJoined((oUserJoined)x), new oUserJoined(channel,user));
            //

            if (UserJoined != null) UserJoined(o.Channel, o.User);
        }
        private void Fire_UserLeft(oUserLeft o)
        {
            //
            // op.Post(x => Fire_UserLeft((oUserLeft)x), new oUserLeft(channel,user));
            //

            if (UserLeft != null) UserLeft(o.Channel, o.User);
        }
        private void Fire_NickChanged(oUserNickChanged o)
        {
            //
            // op.Post(x => Fire_NickChanged((oUserNickChanged)x), new oUserNickChanged(old,new));
            //

            if (UserNickChange != null) UserNickChange(o.Old, o.New);
        }
        private void Fire_ChannelMessage(oChannelMessage o)
        {
            //
            // op.Post(x => Fire_ChannelMessage((oChannelMessage)x), new oChannelMessage(channel,user,message));
            //

            if (ChannelMessage != null) ChannelMessage(o.Channel, o.From, o.Message);
        }
        private void Fire_NoticeMessage(oNoticeMessage o)
        {
            //
            // op.Post(x => Fire_NoticeMessage((oNoticeMessage)x), new oNoticeMessage(user,message));
            //

            if (NoticeMessage != null) NoticeMessage(o.From, o.Message);
        }
        private void Fire_PrivateMessage(oPrivateMessage o)
        {
            //
            // op.Post(x => Fire_PrivateMessage((oPrivateMessage)x), new oPrivateMessage(user,message));
            //

            if (PrivateMessage != null) PrivateMessage(o.From, o.Message);
        }
        private void Fire_ServerMesssage(string s)
        {
            //
            // op.Post(x => Fire_ServerMesssage((string)x), message);
            //

            if (ServerMessage != null) ServerMessage(s);
        }
        private void Fire_NickTaken(string s)
        {
            //
            // op.Post(x => Fire_NickTaken((string)x), nick);
            //

            if (NickTaken != null) NickTaken(s);
        }
        private void Fire_Connected()
        {
            //
            // op.Post((x)=>Fire_Connected(),null);
            //
            if (OnConnect != null) OnConnect();
        }
        private void Fire_ExceptionThrown(Exception ex)
        {
            //
            // op.Post(x => OnExceptionThrown((Exception)x),e); <- code to throw the exception
            //

            if (ExceptionThrown != null) ExceptionThrown(ex);
        }
        #endregion

        #region PublicMethods
        /// <summary>
        /// Connect to the IRC server
        /// </summary>
        public void Connect()
        {
            Thread t = new Thread(DoConnect);
            t.IsBackground = true;
            t.Start();
            //DoConnect();
        }
        private void DoConnect()
        {
            try
            {
                irc = new TcpClient(_server, _port);
                stream = irc.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);

                if (!string.IsNullOrEmpty(_ServerPass))
                    Send("PASS " + _ServerPass);

                Send("NICK " + _nick);
                Send("USER " + _nick + " 0 * :" + _nick);

                Listen();
            }
            catch (Exception ex)
            {
                op.Post(x => Fire_ExceptionThrown((Exception)x),ex); 
            }
        }
        /// <summary>
        /// Disconnect from the IRC server
        /// </summary>
        public void Disconnect()
        {
            if (irc != null)
            {
                if (irc.Connected)
                {
                    Send("QUIT Client Disconnected: http://tech.reboot.pro");
                }
                irc = null;
                //if (Disconnected != null)  // TODO: shouldn't need this event,
                //    Disconnected();        //       it's only fired her
            }
        }
        /// <summary>
        /// Sends the JOIN command to the server
        /// </summary>
        /// <param name="Channel">Channel to join</param>
        public void JoinChannel(string Channel)
        {
            if (irc != null && irc.Connected)
            {
                Send("JOIN " + Channel);
            }
        }
        /// <summary>
        /// Sends the PART command for a given channel
        /// </summary>
        /// <param name="Channel">Channel to leave</param>
        public void PartChannel(string Channel)
        {
            Send("PART " + Channel);
        }
        /// <summary>
        /// Send a notice to a user
        /// </summary>
        /// <param name="Nick">User to send the notice to</param>
        /// <param name="message">The message to send</param>
        public void SendNotice(string Nick, string message)
        {
            Send("NOTICE " + Nick + " :" + message);
        }
        /// <summary>
        /// Send a message to the channel
        /// </summary>
        /// <param name="message">Message to send</param>
        public void SendMessage(string Channel, string Message)
        {
            Send("PRIVMSG " + Channel + " :" + Message);
        }
        /// <summary>
        /// Send RAW IRC commands
        /// </summary>
        /// <param name="message"></param>
        public void SendRAW(string message)
        {
            Send(message);
        }
        #endregion

        #region PrivateMethods
        /// <summary>
        /// Listens for messages from the server
        /// </summary>
        private void Listen()
        {

            while ((inputLine = reader.ReadLine()) != null)
            {
                ParseData(inputLine);
                Console.Write(inputLine);
            }//end while
        }
        /// <summary>
        /// Parses data sent from the server
        /// </summary>
        /// <param name="data">message from the server</param>
        private void ParseData(string data)
        {
            // split the data into parts
            string[] ircData = data.Split(' ');

            // if the message starts with PING we must PONG back
            if (data.Length > 4)
            {
                if (data.Substring(0, 4) == "PING")
                {
                    Send("PONG " + ircData[1]);
                    return;
                }

            }

            // re-act according to the IRC Commands
            switch (ircData[1])
            {
                case "001": // server welcome message, after this we can join
                    Send("MODE " + _nick + " +B");
                    op.Post((x) => Fire_Connected(), null);    //TODO: this might not work
                    //if (OnConnect != null) OnConnect();
                    break;

                case "353": // member list
                    op.Post(x => Fire_UpdateUsers((oUserList)x), new oUserList(ircData[4], JoinArray(ircData, 5).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)));
                    //if (UpdateUsers != null)
                    //    UpdateUsers(ircData[4], JoinArray(ircData, 5).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                    break;

                case "433":  // Nick is taken
                    op.Post(x => Fire_NickTaken((string)x), ircData[3]);
                    //if (NickTaken != null)
                    //{
                    //    NickTaken(ircData[3]);
                    //}

                    if (ircData[3] == _altNick)
                    {
                        Random rand = new Random();
                        string randomNick = "Guest" + rand.Next(0, 9) + rand.Next(0, 9) + rand.Next(0, 9);
                        Send("NICK " + randomNick);
                        Send("USER " + randomNick + " 0 * :" + randomNick);
                        _nick = randomNick;
                    }
                    else
                    {
                        Send("NICK " + _altNick);
                        Send("USER " + _altNick + " 0 * :" + _altNick);
                        _nick = _altNick;
                    }
                    break;

                case "JOIN": // someone joined
                    if (Server != "199.9.252.26")
                    {
                        op.Post(x => Fire_UserJoined((oUserJoined)x), new oUserJoined(ircData[2], ircData[0].Substring(1, ircData[0].IndexOf("!") - 1)));
                    }
                    //if (UserJoined != null)
                    //    UserJoined(ircData[2], ircData[0].Substring(1, ircData[0].IndexOf("!") - 1));
                    //Send("NAMES " + ircData[2]);
                    break;

                case "NICK": // someone changed their nick
                    if (Server != "199.9.252.26")
                    {
                        op.Post(x => Fire_NickChanged((oUserNickChanged)x), new oUserNickChanged(ircData[0].Substring(1, ircData[0].IndexOf("!") - 1), JoinArray(ircData, 3)));
                    }
                    //if (UserNickChange != null)
                    //    UserNickChange(ircData[0].Substring(1, ircData[0].IndexOf("!") - 1), JoinArray(ircData, 3));
                    break;

                case "NOTICE": // someone sent a notice
                    if (ircData[0].Contains("!"))
                    {
                        if (Server != "199.9.252.26")
                        {
                            op.Post(x => Fire_NoticeMessage((oNoticeMessage)x), new oNoticeMessage(ircData[0].Substring(1, ircData[0].IndexOf('!') - 1), JoinArray(ircData, 3)));
                            //NoticeMessage(ircData[0].Substring(1, ircData[0].IndexOf('!') - 1),
                            //    JoinArray(ircData, 3));
                        }
                    }
                    else
                    {
                        if (Server != "199.9.252.26")
                        {
                            op.Post(x => Fire_NoticeMessage((oNoticeMessage)x), new oNoticeMessage(_server, JoinArray(ircData, 3)));
                        }
                    }
                    //NoticeMessage(_server, JoinArray(ircData, 3));
                    break;

                case "PRIVMSG": // message was sent to the channel or as private
                    // if it's a private message
                    if (ircData[2].ToLower() == _nick.ToLower())
                    {
                        op.Post(x => Fire_PrivateMessage((oPrivateMessage)x), new oPrivateMessage(ircData[0].Substring(1, ircData[0].IndexOf('!') - 1), JoinArray(ircData, 3)));
                        //if (PrivateMessage != null)
                        //{
                        //    PrivateMessage(ircData[0].Substring(1, ircData[0].IndexOf('!') - 1),
                        //        JoinArray(ircData, 3));
                        //}
                    }
                    else
                    {
                        op.Post(x => Fire_ChannelMessage((oChannelMessage)x), new oChannelMessage(ircData[2], ircData[0].Substring(1, ircData[0].IndexOf('!') - 1), JoinArray(ircData, 3)));
                        //if (ChannelMessage != null)
                        //{
                        //    ChannelMessage(ircData[2],
                        //        ircData[0].Substring(1, ircData[0].IndexOf('!') - 1),
                        //        JoinArray(ircData, 3));
                        //}
                    }
                    break;

                case "PART":
                case "QUIT":// someone left
                    op.Post(x => Fire_UserLeft((oUserLeft)x), new oUserLeft(ircData[2], ircData[0].Substring(1, data.IndexOf("!") - 1)));
                    //if (UserLeft != null)
                    //    UserLeft(ircData[2], ircData[0].Substring(1, data.IndexOf("!") - 1));
                    if (Server != "199.9.252.26") { Send("NAMES " + ircData[2]); }
                    break;

                default:
                    // still using this while debugging
                    if (ircData.Length > 3)
                        op.Post(x => Fire_ServerMesssage((string)x), JoinArray(ircData, 3));

                    //ServerMessage(JoinArray(ircData, 3));
                    break;
            }

        }
        /// <summary>
        /// Strips the message of unnecessary characters
        /// </summary>
        /// <param name="message">Message to strip</param>
        /// <returns>Stripped message</returns>
        private string StripMessage(string message)
        {
            // remove IRC Color Codes
            foreach (Match m in new Regex((char)3 + @"(?:\d{1,2}(?:,\d{1,2})?)?").Matches(message))
                message = message.Replace(m.Value, "");

            // if there is nothing to strip
            if (message == "")
                return "";
            else if (message.Substring(0, 1) == ":" && message.Length > 2)
                return message.Substring(1, message.Length - 1);
            else
                return message;
        }
        /// <summary>
        /// Joins the array into a string after a specific index
        /// </summary>
        /// <param name="strArray">Array of strings</param>
        /// <param name="startIndex">Starting index</param>
        /// <returns>String</returns>
        private string JoinArray(string[] strArray, int startIndex)
        {
            return StripMessage(String.Join(" ", strArray, startIndex, strArray.Length - startIndex));
        }
        /// <summary>
        /// Send message to server
        /// </summary>
        /// <param name="message">Message to send</param>
        private void Send(string message)
        {
            writer.WriteLine(message);
            writer.Flush();
        }
        #endregion

        #region Structs

        public struct oUserList
        {
            public string Channel;
            public string[] UserList;
            public oUserList(string Channel, string[] UserList)
            {
                this.Channel = Channel;
                this.UserList = UserList;
            }
        }
        public struct oUserJoined
        {
            public string Channel;
            public string User;
            public oUserJoined(string Channel, string User)
            {
                this.Channel = Channel;
                this.User = User;
            }
        }
        public struct oUserLeft
        {
            public string Channel;
            public string User;
            public oUserLeft(string Channel, string User)
            {
                this.Channel = Channel;
                this.User = User;
            }
        }

        public struct oChannelMessage
        {
            public string Channel;
            public string From;
            public string Message;
            public oChannelMessage(string Channel, string From, string Message)
            {
                this.Channel = Channel;
                this.From = From;
                this.Message = Message;
            }
        }
        public struct oNoticeMessage
        {
            public string From;
            public string Message;
            public oNoticeMessage(string From, string Message)
            {
                this.From = From;
                this.Message = Message;
            }
        }
        public struct oPrivateMessage
        {
            public string From;
            public string Message;
            public oPrivateMessage(string From, string Message)
            {
                this.From = From;
                this.Message = Message;
            }
        }
        public struct oUserNickChanged
        {
            public string Old;
            public string New;
            public oUserNickChanged(string Old, string New)
            {
                this.Old = Old;
                this.New = New;
            }
        }

        #endregion
    }

}