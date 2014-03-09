///////////////////////////////////////////////
////// IRC Emulation Control version 1.5 //////
////// By James "Iyouboushi" of esper.net /////
///////////////////////////////////////////////
// Default Key Bindings for Emu Controls:
/*
ALL EMULATORS:
  UP: up arrow
  DOWN: down arrow
  LEFT/RIGHT: left and right arrows
  A: HOME
  B: END
  START: PAGE UP
  SELECT: PAGE DOWN

GBA:
  L: INSERT
  R: DELETE

SNES:
  X: P
  Y: O
  L: INSERT
  R: DELETE

SEGA:
  C: I

PSX:
  L1: INSERT
  R1: DELETE
  R2: T
  L2: E
  TRIANGLE: D
  SQUARE: S
  CIRCLE: X
  X: P
*/
///////////////////////////////////////////////
// TO DO: 
// * Add more emulator options.
///////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TechLifeForum;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using InputManager;


namespace IrcClientDemoCS
{
    public partial class IRCEmulationControl
    {

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, Keys wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SetFocus(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int SendMessage(
        uint hWnd, // handle to destination window
        uint Msg, // message
        uint wParam, // first message parameter
        uint lParam // second message parameter
        );

        String windowHandle = "";
        IntPtr handle;
        bool controlPause = false;

        // Start with BoycottAdvance selected at the start just as a default.
        String emulatorRunning = "BoycottAdvance";

        // Timers.
        const double TIMEOUT = 5000; // milliseconds
        System.Threading.Timer idleTimer;
        System.Threading.Timer democracyTimer;

        // getEmulatorHandle finds the windows handle ID necessary for this program to work based on which emulator is selected.
        // TODO: Make it so it can find the handle of any emulator rather than very specific ones.
        void getEmulatorHandle()
        {

            if (emulatorRunning == "VisualBoyAdvance") { windowHandle = "VisualBoyAdvance"; }
            if (emulatorRunning == "BoycottAdvance") { windowHandle = "BoycottAdvance"; }
            if (emulatorRunning == "nester") { windowHandle = "nester"; }
            if (emulatorRunning == "ZSNES") { windowHandle = "ZSNES"; }
            if (emulatorRunning == "FCEUX") { windowHandle = "FCEUX"; }

            handle = FindWindow(null, windowHandle);

            if (handle.Equals(IntPtr.Zero))
                handle = findWindowHandle();

            if (!handle.Equals(IntPtr.Zero)) { rtbOutput.AppendText("WINDOW HANDLE: " + handle + "\r\n"); }

        }

        // This function attempts to find the window handle if it fails in the above section.
        // This function should make it possible to use any emulator.
#region FindWindowHandle
        IntPtr findWindowHandle()
        {

            IntPtr hWnd = IntPtr.Zero;
            foreach (Process pList in Process.GetProcesses())
            {
                if (pList.MainWindowTitle.Contains(windowHandle))
                {
                    hWnd = pList.MainWindowHandle;
                }
            }
            return hWnd;

        }
#endregion


        // Tries to control the emulator of choice..
        void controlEmulator(string m, string u)
        {
            if (controlPause) { return; }


            // If we're in democracy mode, check to see if the bot is able to send a command.  
            // If not, add it to a count.
            // If in anarchy mode, just go.

            if (controlMode == "DEMOCRACY")
            {
                if (democracyModeCanSend == false)
                {
                    // add the command to the array to be sorted.
                    democracyCommandList.Add(m.ToUpper());
                    return;

                }
            }

            SetForegroundWindow(handle);
            SetFocus(handle);
            Thread.Sleep(100);

            if (!handle.Equals(IntPtr.Zero))
            {

                int attempts = 0;
                do
                {
                    SetForegroundWindow(handle);
                    attempts++;
                } while ((!SetForegroundWindow(handle) || (attempts <= 3)));


                if (SetForegroundWindow(handle))
                {
                    Thread.Sleep(100);
                    // m is the command, such as UP, DOWN, RIGHT.
                    // need to figure out which command and get the key defined for the button
                    // then send to switch to determine the Keys.

                    if (m.ToUpper() == "UP")
                        pressButton(DpadUpButton);
                    if (m.ToUpper() == "DOWN")
                        pressButton(DpadDownButton);
                    if (m.ToUpper() == "LEFT")
                        pressButton(DpadLeftButton);
                    if (m.ToUpper() == "RIGHT")
                        pressButton(DpadRightButton);

                    if (m.ToUpper() == "A")
                        pressButton(Abutton);
                    if (m.ToUpper() == "B")
                        pressButton(Bbutton);
                    if (m.ToUpper() == "C")
                        pressButton(Cbutton);
                    if (m.ToUpper() == "L")
                        pressButton(Lbutton);
                    if (m.ToUpper() == "R")
                        pressButton(Rbutton);
                    if (m.ToUpper() == "X")
                        pressButton(Xbutton);
                    if (m.ToUpper() == "Y")
                        pressButton(Ybutton);
                    if (m.ToUpper() == "R1")
                        pressButton(R1button);
                    if (m.ToUpper() == "R2")
                        pressButton(R2button);
                    if (m.ToUpper() == "L1")
                        pressButton(L1button);
                    if (m.ToUpper() == "L2")
                        pressButton(L2button);

                    if (m.ToUpper() == "START")
                        pressButton(StartButton);
                    if (m.ToUpper() == "SELECT")
                        pressButton(SelectButton);

                    if ((m.ToUpper() == "CIRCLE") || (m.ToUpper() == "O"))
                        pressButton(CircleButton);
                    if (m.ToUpper() == "SQUARE")
                        pressButton(SquareButton);
                    if (m.ToUpper() == "TRIANGLE")
                        pressButton(TriangleButton);

                    if (m.ToUpper() == "AB")
                    {
                        pressButton(Abutton);
                        Thread.Sleep(50);
                        pressButton(Bbutton);
                    }
                    if (m.ToUpper() == "BA")
                    {
                        pressButton(Bbutton);
                        Thread.Sleep(50);
                        pressButton(Abutton);
                    }

                    // TO DO: Make this better so that it's not so static like this and to offer more choices (like LEFT 9 instead of just LEFT2)
                    if (m.ToUpper() == "LEFT2")
                    {
                        pressButton(DpadLeftButton);
                        Thread.Sleep(50);
                        pressButton(DpadLeftButton);
                    }
                    if (m.ToUpper() == "RIGHT2")
                    {
                        pressButton(DpadRightButton);
                        Thread.Sleep(50);
                        pressButton(DpadRightButton);
                    }

       
                }

            }
            else
            {
                rtbOutput.AppendText("The emulator is not on or found. Attempting to find it.\r\n");
                getEmulatorHandle();

            }

            // Reset the idle timer back to 10 minutes.
            idleTimer.Change(600000, 0);

            // return democracy mode to a waiting mode and clear the counts.
            democracyModeCanSend = false;

        }

#region PressButton
        private void pressButton(string buttonPressed)
        {

            switch (buttonPressed.ToUpper())
            {
                case "UP":
                    Keyboard.KeyDown(Keys.Up);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.Up);
                    break;

                case "DOWN":
                    Keyboard.KeyDown(Keys.Down);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.Down);
                    break;

                case "LEFT":
                    Keyboard.KeyDown(Keys.Left);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.Left);
                    break;

                case "RIGHT":
                    Keyboard.KeyDown(Keys.Right);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.Right);
                    break;

                case "A":
                    Keyboard.KeyDown(Keys.A);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.A);
                    break;

                case "B":
                    Keyboard.KeyDown(Keys.B);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.B);
                    break;

                case "C":
                    Keyboard.KeyDown(Keys.C);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.C);
                    break;

                case "D":
                    Keyboard.KeyDown(Keys.D);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.D);
                    break;

                case "E":
                    Keyboard.KeyDown(Keys.E);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.E);
                    break;

                case "F":
                    Keyboard.KeyDown(Keys.F);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.F);
                    break;

                case "G":
                    Keyboard.KeyDown(Keys.G);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.G);
                    break;

                case "H":
                    Keyboard.KeyDown(Keys.H);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.H);
                    break;

                case "I":
                    Keyboard.KeyDown(Keys.I);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.I);
                    break;

                case "J":
                    Keyboard.KeyDown(Keys.J);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.J);
                    break;

                case "K":
                    Keyboard.KeyDown(Keys.K);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.K);
                    break;

                case "L":
                    Keyboard.KeyDown(Keys.L);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.L);
                    break;

                case "M":
                    Keyboard.KeyDown(Keys.M);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.M);
                    break;

                case "N":
                    Keyboard.KeyDown(Keys.N);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.N);
                    break;

                case "O":
                    Keyboard.KeyDown(Keys.O);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.O);
                    break;

                case "P":
                    Keyboard.KeyDown(Keys.P);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.P);
                    break;

                case "Q":
                    Keyboard.KeyDown(Keys.Q);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.Q);
                    break;

                case "R":
                    Keyboard.KeyDown(Keys.R);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.R);
                    break;

                case "S":
                    Keyboard.KeyDown(Keys.S);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.S);
                    break;

                case "T":
                    Keyboard.KeyDown(Keys.T);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.T);
                    break;

                case "U":
                    Keyboard.KeyDown(Keys.U);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.U);
                    break;

                case "V":
                    Keyboard.KeyDown(Keys.V);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.V);
                    break;

                case "W":
                    Keyboard.KeyDown(Keys.W);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.W);
                    break;

                case "X":
                    Keyboard.KeyDown(Keys.X);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.X);
                    break;

                case "Y":
                    Keyboard.KeyDown(Keys.Y);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.Y);
                    break;

                case "Z":
                    Keyboard.KeyDown(Keys.Z);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.Z);
                    break;

                case "LCTRL":
                    Keyboard.KeyDown(Keys.LControlKey);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.LControlKey);
                    break;

                case "RCTRL":
                    Keyboard.KeyDown(Keys.RControlKey);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.RControlKey);
                    break;

                case "ALT":
                    Keyboard.KeyDown(Keys.Alt);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.Alt);
                    break;

                case "SPACE":
                    Keyboard.KeyDown(Keys.Space);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.Space);
                    break;

                case "LSHIFT":
                    Keyboard.KeyDown(Keys.LShiftKey);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.LShiftKey);
                    break;

                case "RSHIFT":
                    Keyboard.KeyDown(Keys.RShiftKey);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.RShiftKey);
                    break;

                case "ENTER":
                    Keyboard.KeyDown(Keys.Enter);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.Enter);
                    break;

                case "NUMPAD0":
                    Keyboard.KeyDown(Keys.NumPad0);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.NumPad0);
                    break;

                case "NUMPAD1":
                    Keyboard.KeyDown(Keys.NumPad1);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.NumPad1);
                    break;

                case "NUMPAD2":
                    Keyboard.KeyDown(Keys.NumPad2);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.NumPad2);
                    break;

                case "NUMPAD3":
                    Keyboard.KeyDown(Keys.NumPad3);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.NumPad3);
                    break;

                case "NUMPAD4":
                    Keyboard.KeyDown(Keys.NumPad4);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.NumPad4);
                    break;

                case "NUMPAD5":
                    Keyboard.KeyDown(Keys.NumPad5);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.NumPad5);
                    break;

                case "NUMPAD6":
                    Keyboard.KeyDown(Keys.NumPad6);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.NumPad6);
                    break;

                case "NUMPAD7":
                    Keyboard.KeyDown(Keys.NumPad7);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.NumPad7);
                    break;

                case "NUMPAD8":
                    Keyboard.KeyDown(Keys.NumPad8);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.NumPad8);
                    break;

                case "NUMPAD9":
                    Keyboard.KeyDown(Keys.NumPad9);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.NumPad9);
                    break;

                case "HOME":
                    Keyboard.KeyDown(Keys.Home);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.Home);
                    break;

                case "INSERT":
                    Keyboard.KeyDown(Keys.Insert);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.Insert);
                    break;

                case "DELETE":
                    Keyboard.KeyDown(Keys.Delete);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.Delete);
                    break;

                case "END":
                    Keyboard.KeyDown(Keys.End);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.End);
                    break;

                case "PAGEUP":
                    Keyboard.KeyDown(Keys.PageUp);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.PageUp);
                    break;

                case "PAGEDOWN":
                    Keyboard.KeyDown(Keys.PageDown);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.PageDown);
                    break;

                case ";":
                    Keyboard.KeyDown(Keys.OemSemicolon);
                    Thread.Sleep(sleepDelay);
                    Keyboard.KeyUp(Keys.OemSemicolon);
                    break;
            }
        }
#endregion


        // Function for the timer action. Basically if the program idles for 10 minutes it will send the "UP" button to the emulator
        // This is to help some emulators from locking up when no input is entered for a lengthy period of time.
        private void TimerProc(object state)
        {
            // Send an "UP" to the emulator if it's not in pause mode.
            if (!controlPause)
            {
                rtbCommands.Invoke(new MethodInvoker(delegate { rtbCommands.AppendText("idleTimer: \u2191 \r\n"); }));
                rtbCommands.Invoke(new MethodInvoker(delegate { rtbCommands.ScrollToCaret(); }));
                controlEmulator("UP", "idleTimer");
                adjustControlMode("ANARCHY");
            }

            // Reset the timer back to 10 minutes.
            idleTimer.Change(600000, 0);

        }

        private void democracyTimeUp(object state)
        {
            democracyTimer.Change(10000, 0);

            if (controlMode != "DEMOCRACY")
            {
                democracyTimer.Change(10000, 0);
                return;
            }

            if (controlMode == "DEMOCRACY")
            {
                String democracyCommand = getMostCommonCommand();

                if (democracyCommand == "NONE")
                    return;

                rtbOutput.Invoke(new MethodInvoker(delegate { rtbOutput.AppendText("most popular command is: " + democracyCommand + "\r\n"); }));
                rtbOutput.Invoke(new MethodInvoker(delegate { rtbOutput.ScrollToCaret(); }));


                String commandString = democracyCommand;


                // TODO: This needs to be nicer.
                if (commandString == "UP")
                    commandString = "\u2191";
                if (commandString == "LEFT")
                    commandString = "\u2190";
                if (commandString == "DOWN")
                    commandString = "\u2193";
                if (commandString == "RIGHT")
                    commandString = "\u2192";
                if (commandString == "DOWNA")
                    commandString = "\u2193 A";
                if (commandString == "DOWNB")
                    commandString = "\u2193 B";
                if (commandString == "CIRCLE")
                    commandString = "O";
                if (commandString == "TRIANGLE")
                    commandString = "▲";
                if (commandString == "SQUARE")
                    commandString = "[]";


                rtbCommands.Invoke(new MethodInvoker(delegate { rtbCommands.AppendText("Democratic Vote: " + commandString + "\r\n"); }));
                rtbCommands.Invoke(new MethodInvoker(delegate { rtbCommands.ScrollToCaret(); }));

                democracyModeCanSend = true;
                controlEmulator(democracyCommand, "Democracy");
                democracyCommand = null;
                democracyCommandList = new List<string>();
            }




        }

        private string getMostCommonCommand()
        {
            try
            {
                return (from i in democracyCommandList
                        group i by i into grp
                        orderby grp.Count() descending
                        select grp.Key).First();
            }
            catch (Exception democracyEmpty)
            {
                return "NONE";
            }
            
        }



    }

}