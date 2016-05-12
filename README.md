# ProgramSeeker V0.1

ProgramSeeker is a GUI utility for the command-line WMIC utility. It's initial purpose was to scan all nodes on a network to retrieve currently installed software.

####Features

V0.1.1: 
* Get Software and Version
* View nodes and results
* View software tallies
* Allows username and password for remote nodes
* Import nodes from text file
* Scan individual or multiple endpoints
* Save results state on exit

####Planned Features
* Get PC Model and Serial Number
* Get Usernames
* Export report (Excel, CSV, XML)
* Split nodes into chunks and dedicate a thread to a chunk (Currently each node spawns a task)
