using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralPatterns.ObserverPattern
{
    public class Subject
    {
        private readonly List<Observer> _observers = new List<Observer>();

        public void AttachObserver(Observer observer)
        {
            _observers.Add(observer);
        }

        public void DetachObserver(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers(object arg)
        {
            _observers.ForEach((observer) => observer.Notify(arg));
        }
    }
}
