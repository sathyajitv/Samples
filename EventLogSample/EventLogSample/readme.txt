
This application writes an informational and warning message to the Application Event Log. 

Steps:
1. Check System.Diagnostic.EventLog to see if the target EventSource exists 
2. If it does not exist, use EventLog.CreateEventSource to create the event source in the target Event Log
3. Use EventLog.Write to write messages to the target Event Log

