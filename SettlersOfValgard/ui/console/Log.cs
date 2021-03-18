using System;
using System.Collections.Generic;

namespace SettlersOfValgardGame.ui.console
{
    public class Log
    {
        public enum MessageType
        {
            Output,
            Warning,
            Error,
            Debug
        }
        
        public Log(int maxContents)
        {
            MaxContents = maxContents;
            Contents = new List<(string, MessageType)>();
        }

        public void Add(string message, MessageType type)
        {
            Contents.Insert(0, (message, type));

            //Removes last messages
            while (Contents.Count > MaxContents) 
            {
                Contents.RemoveAt(Contents.Count - 1);
            }
        }
        
        public List<(string, MessageType)> Contents { get; }
        public int MaxContents { get; }
    }
}