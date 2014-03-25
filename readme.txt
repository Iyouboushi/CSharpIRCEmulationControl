///////////////////////////////////////////////
////// IRC Emulation Control version 1.6 //////
////// By James "Iyouboushi" of esper.net /////
///////////////////////////////////////////////

Not too long ago an anonymous programmer created a way for Twitch users to interact using the Twitch chat and they've been trying to collectively play the first Pokemon game (to some funny results).  You can google it to learn more about that.

After seeing that I said "I bet I can do that in C#!" and set out on a frustrating journey to get it to work.  However, I'm happy to report that thanks to a guy on the Tech Life Forum for providing a quick IRC GUI client demo and to the Input Manager Library (http://www.codeproject.com/Articles/117657/InputManager-library-Track-user-input-and-simulate), I've managed to get it to work.

I'm providing a few different things here in this topic.  First, I'm providing the IRC version of the project, which includes the source code.  It still has a LOT of work to do and isn't perfect but it does work 99% of the time now.  Second, I'm providing a console bot version that randomly selects keys and attempts to play games on its own (no AI behind it, it's all random baby; the source is not provided at this time for this one as I'm still changing things around on it and this is just a quick copy I'm including).

Let me tell you how to get it working.

First things to know, the IRC version works with VisualBoyAdvance, BoycottAdvance, nester, fceux, and ZSNES all out of the box as long as you set the keys to the emulators correctly. 

The DEFAULT key bindings are set up like this:

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


With version 1.4 it is now possible to redefine the key bindings to your liking.  You can read more about that towards the bottom of this document. 


So first things first, load IRCEmulationControl.exe and you'll see a fairly basic IRC client.  Now run the emulator of your choice and load your ROM of choice (you'll have to find those on your own).  Now, back in IRC Emulation Control click Emulators-> (console) -> (your emulator choice here). 

You can leave the default nickname, channel and server if you want but I would recommend changing those.  If you're going to be connecting to Twitch's chat, you'll need your Oauth twitch password and to make sure the username and channel both match and are in lower case. Put the Oauth password into the password field (don't worry, once you hit connect the password will be **** out).

When you're satisfied with that, you're ready to connect.  Hit CONNECT. 

After the bot connects to the channel of your choice, connect to the same channel with another client (such as Mibbit or mIRC, or log into twitch with another account if you're connecting to twitch) and you can type the following commands (one at a time):

UP, DOWN, LEFT, RIGHT, A, B, C, R, L, X, Y, AB, DOWNA, DOWNB, SELECT, START, TRIANGLE, CIRCLE, SQUARE R1, R2, L1, L2, ANARCHY, DEMOCRACY

Obviously some of these commands only work in certain emulators/systems (X and Y won't have any effect in an NES emulator, for example).

If you type "UP" and nothing seems to be happening, give it a few seconds (maybe check the emulator to make sure it's working normally by moving the character around on the keyboard) and try again.  Sometimes, for whatever weird reason, it takes a few tries to make it work right.   But once you have it working any user can type those commands to control the emulator.


*** The program saves your current config settings when you hit "CONNECT" and will attempt to reload them the next time you run the program.



CUSTOM EMULATORS NOT ON THE LIST
With version 1.3 is now possible to try to make the program hook into any emulator of your choice, even if it's not on the list.  To do this, load the emulator that you want and set up the keys properly (see top of this text file).  Then type /setemu nameofemulatorhere   For example, if you're running ePSXe you can type /setemu ePSXE    

This is still experimental and may not work properly with every emulator but it does seem to work with a lot of them.  



KEY BINDING SETTINGS
As mentioned above, it is now possible (as of version 1.4) to change the default key control settings that the emulators use.

You can use the following keys:

A B C D E F G H I J K L M N O P Q R S T U V W X Y Z
LCTRL RCTRL ALT SPACE LSHIFT RSHIFT ENTER
NumPad0 NumPad1 NumPad2 NumPad3 NumPad4 NumPad5 NumPad6 NumPad7 NumPad8 NumPad9
HOME INSERT DELETE END PAGEUP PAGEDOWN
UP DOWN LEFT RIGHT    (these are the arrow keys)


To change the keys, load the program and click on the menu option Settings -> Control Settings -> Key Bindings
You have to type in the key names (using the ones listed above) for each key you want to change. As of this version it cannot detect which key you press.

Your settings will be saved upon hitting "OK" and loaded back into the program each time you run it.