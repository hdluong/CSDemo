using DesignPattern.BehavioralPatterns.ObserverPattern.Notifiers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralPatterns.ObserverPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var videoData = new VideoData();

            var observer1 = new EmailNotifier(videoData);
            var observer2 = new FacebookNotifier(videoData);
            var observer3 = new YoutubeNotifier(videoData);

            videoData.AttachObserver(observer1);
            videoData.AttachObserver(observer2);
            videoData.Title = "New Title";

            Console.WriteLine("-----------------------------------------");
            videoData.AttachObserver(observer3);
            videoData.DetachObserver(observer2);
            videoData.DetachObserver(observer1);
            videoData.Description = "New Description";
        }
    }
}
