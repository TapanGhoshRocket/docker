using IBM.Data.Db2;

Console.WriteLine("Using DB2 .NET provider");

string uid = Environment.GetEnvironmentVariable("uid");
string pwd = Environment.GetEnvironmentVariable("pwd");
string server = Environment.GetEnvironmentVariable("server");
string db = Environment.GetEnvironmentVariable("db");
string security = Environment.GetEnvironmentVariable("security");

//Connection String
string connString = "uid=" + uid + ";pwd=" + pwd + ";server=" + server + ";database=" + db + ";Security=" + security;

#region Instantiating 7 connection objects
DB2Connection con1 = new DB2Connection(connString);
DB2Connection con2 = new DB2Connection(connString);
DB2Connection con3 = new DB2Connection(connString);
DB2Connection con4 = new DB2Connection(connString);
DB2Connection con5 = new DB2Connection(connString);
DB2Connection con6 = new DB2Connection(connString);
DB2Connection con7 = new DB2Connection(connString);
#endregion

#region Opening 5 connections
con1.Open();
Console.WriteLine("con1 Connection Opened");

con2.Open();
Console.WriteLine("con2 Connection Opened");

con3.Open();
Console.WriteLine("con3 Connection Opened");

con4.Open();
Console.WriteLine("con4 Connection Opened");

con5.Open();
Console.WriteLine("con5 Connection Opened");
#endregion

#region Closing 3 connections and putting it back to pool
con1.Close();
Console.WriteLine("con1 Connection Closed");

con2.Close();
Console.WriteLine("con2 Connection Closed");

con3.Close();
Console.WriteLine("con3 Connection Closed");
#endregion

#region Opening 2 connections from the pool
con6.Open();
Console.WriteLine("con6 Connection Opened");

con7.Open();
Console.WriteLine("con7 Connection Opened");
#endregion

#region Exiting app and closing the remaing connections
con4.Close();
Console.WriteLine("con4 Connection Closed");

con5.Close();
Console.WriteLine("con5 Connection Closed");

con6.Close();
Console.WriteLine("con6 Connection Closed");

con7.Close();
Console.WriteLine("con7 Connection Closed");

Console.WriteLine("Exiting Application");
#endregion
