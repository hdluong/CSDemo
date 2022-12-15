using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralPatterns.ObserverPattern
{
    public class VideoData : Subject
    {
        private string _title;
        public string Title {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                NotifyDataChanged();
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                NotifyDataChanged();
            }
        }

        private void NotifyDataChanged()
        {
            NotifyObservers(null);
        }
    }
}
