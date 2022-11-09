using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LoggingManager
{
    public static void LogMessageToConsole(string message)
    {
        Debug.Log("Message: " + message);
    }
    public static void LogMessageToFile(string message)
    {
        //ToDo
        //WriteToFile("Message: " + message);
    }
    public static void CompleteLog(string message)
    {
        LogMessageToConsole(message);
        LogMessageToFile(message);
    }
}
