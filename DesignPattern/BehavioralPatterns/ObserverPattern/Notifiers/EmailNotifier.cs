using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralPatterns.ObserverPattern.Notifiers
{
    public class EmailNotifier : Observer
    {
        public EmailNotifier(Subject subject)
        {
            _subject = subject;
        }

        public override void Notify(object arg)
        {
            if (_subject is VideoData videoData)
            {
                Console.WriteLine($"Notify via Email with new data" +
                                  $"\n\tTitle: {videoData.Title}" +
                                  $"\n\tDescription: {videoData.Description}");
            }
        }
    }
}
