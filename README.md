# ProgramSeeker V0.2!

ProgramSeeker is a GUI utility for the command-line WMIC utility. It's initial purpose was to scan all nodes on a network to retrieve currently installed software. The software is currently functional and can be used, but is somewhat clunky. My time is currently dedicated to finishing up computer labs for the term and this is taking more of a back-burner position (at least for the time being).

####Features

V0.2.1: 
* Supported WMIC Queries
  * Software + version
* View nodes and results
* View software tallies
* Allows username and password for remote nodes
* Import nodes from text file
* Scan individual or multiple endpoints
* Save results state on exit

####New Features!!
* New Queries!
  * Serial Number
  * Computer Model
* Export report to Excel
* Failed nodes are grouped separately

####Planned Features
* Get Usernames - Indefinitely postponed. WMIC is not returning results for this
* Add additional queries
* Additional report types (XML, CSV)
* Trap and display failure reason
* Proper code design with nice classes and patterns =)
