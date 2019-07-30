# WinRobot

Current Solution implements a Client – Server Desktop App with the following Functionalities:

•	Dual Http Connection between the client and the server through a WCF contract

•	The Server App is implemented as a WPF Application which has a basic UI for:

    o	Creating a sequence of Actions, called action script

    o	Sending this action script to the Client

    o	Receiving the client’s response regarding the success or failure of the script execution

•	The Client App, is a Console Application which Host A WCF Service. The Client App receives the Action scripts from the server and executes them. The available Actions are:
    
    o	Set Active Window based on Window Title
    
    o	Move Mouse on certain position

    o	Click Mouse
    
    o	Send Key Strokes


# Deployment Steps:

•	Build The entire Solution

•	Make sure both App Config Files  of Server and Client App are set up correctly. More precisely make sure that the Server App has its Http endpoint address to be the same as the one configured in the client App (WCF Host)

• Run The executable file of the Server  App (../WpfRobotServer/Bin/Release/ WpfRobotServer.exe)

•	Run the executable file of the Client App  (../Client/Bin/Release/ Client.exe)
