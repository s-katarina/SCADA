using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmDisplay.Models
{
    public class AlarmTableItem : INotifyPropertyChanged
    {
        private string _tagName;
        public string TagName
        {
            get { return _tagName; }
            set
            {
                if (_tagName != value)
                {
                    _tagName = value;
                    RaisePropertyChanged(nameof(TagName));
                }
            }
        }

        private string _alarmType;
        public string AlarmType
        {
            get { return _alarmType; }
            set
            {
                if (_alarmType != value)
                {
                    _alarmType = value;
                    RaisePropertyChanged(nameof(AlarmType));
                }
            }
        }

        private string _alarmPriority;
        public string AlarmPriority
        {
            get { return _alarmPriority; }
            set
            {
                if (_alarmPriority != value)
                {
                    _alarmPriority = value;
                    RaisePropertyChanged(nameof(AlarmPriority));
                }
            }
        }

        private double _value;
        public double Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    RaisePropertyChanged(nameof(Value));
                }
            }
        }

        private string _timeStamp;
        public string TimeStamp
        {
            get { return _timeStamp; }
            set
            {
                if (_timeStamp == value)
                {
                    _timeStamp = value;
                    RaisePropertyChanged(nameof(TimeStamp));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
