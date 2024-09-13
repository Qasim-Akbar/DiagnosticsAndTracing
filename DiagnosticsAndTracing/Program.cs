using System.Diagnostics;
using System.Security;

//Start a stop watch to measure the execution time of some code block
var stopwatch = new Stopwatch();
stopwatch.Start();

Console.WriteLine("Starting the application");

for (int i = 0; i < 100000; i++)
{
    //perform some time consuming operations
}

Console.WriteLine("Work complete.");

//Stop the stopwatch and print the elapsed time
stopwatch.Stop();
Console.WriteLine($"Elapsed Time: {stopwatch.Elapsed}");

//Perform Tracing with EvenLog
try
{
    LogToEventLog("Application started");
}
catch (SecurityException e) {  //Console.WriteLine(e.ToString());
                               }

//Perform Tracing with TraceSource
TraceSource traceSource = new TraceSource("MyTraceSource");
traceSource.TraceEvent(TraceEventType.Information, 0, "This is an informal message.");
traceSource.Flush();

static void LogToEventLog(string message)
{
    if (!EventLog.SourceExists("MyEventLogSource"))
    {
        EventLog.CreateEventSource("MyEventLogSource", "MyEventLog");
    }

    EventLog eventLog = new EventLog("MyEventLog");
    eventLog.Source = "MyEventLogSource";
    eventLog.WriteEntry(message, EventLogEntryType.Information);
}