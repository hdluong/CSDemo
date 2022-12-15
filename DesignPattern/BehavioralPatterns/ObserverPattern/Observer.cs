using System;

namespace DesignPattern.BehavioralPatterns.ObserverPattern
{
    public abstract class Observer
    {
        protected Subject _subject;

        public abstract void Notify(object arg);
    }
}