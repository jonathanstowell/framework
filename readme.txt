Please locate the source code in a folder such as c:\git annoyingly I was unaware of Windows restrictions on filepath lengths until it was too late!

Download SpecFlow https://github.com/techtalk/SpecFlow/downloads

Download NUnit which can be found http://www.nunit.org/index.php?p=download

Download SQLite 1.0.66.0 http://sourceforge.net/projects/sqlite-dotnet2/files/SQLite%20for%20ADO.NET%202.0/

Download Membase Server http://www.couchbase.com/downloads/membase-server/community

Useful article on getting it working for a local environment after install. http://blog.ovesens.net/2011/02/membase-local-development-machine-ip-problem-fixed/

Enable MSMQ by going to Control Panel -> Programs -> Turn Windows Features on or off -> Tick everything under Microsoft Message Queue (MSMQ) Server

Make sure you have a SQL Server 2008 database installed. A free edition can be found http://www.microsoft.com/sqlserver/en/us/editions/express.aspx

Run the Build.And.Distribute.All.bat which builds all the projects and copies their libraries to the lib/internal folder for shared projects and copies the libraries for plugins into the relevant plugin folders. Usually found in WebUI/Plugins and ServiceHost/bin/Debug/Plugins

The Build all bat has been playing up so it may be required to run the build files individually! Not sure why this is happening.

Deploy the database projects. The default settings are to deploy to .\SQLEXPRESS using Windows Authentication. Change the deployment settings to suit your environment.

Also check in the ServiceHost project properties that on the Debug tab “Start External Program” is pointing to the NServiceBus.Host.exe in the correct file structure to suite your machine.

Now the User System and Email System are seperate solutions and have their own service host. I have setup Project Hollywood as a small example of how you can easily drop plugins into your site.
The frontend plugins are deployed to Project Hollywood during the build process and the needed configuration setup in the webconfig. The pages in these plugins are then available in the Project Hollywood
site. For any of these processes to actually do anything you need to have the service hosts running. These can be found in the Solution Folder\{ProjectName}.ServiceHost\bin\Debug\NServiceBus.Host.exe
It's best to run up all the service hosts from the solution in debug mode first as they will automatically create the queues they need to function.