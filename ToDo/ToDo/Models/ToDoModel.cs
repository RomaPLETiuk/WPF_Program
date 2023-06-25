using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ToDo.Models
{
    public class ToDoModel : INotifyPropertyChanged
    {
        public DateTime Date { get; set; } = DateTime.Now;


        private bool _isDone;

        public bool IsDone 
        { 
            get { return _isDone; } 
            set 
            { if (_isDone == value) return;
                _isDone = value; 
                OnPropertyChanged("IsDone");
            } 
        }


        private string _task;

        public string Task
        {
            get { return _task; }
            set 
            { 
                if (_task == value) return;
                _task = value; 
                OnPropertyChanged("Task");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            //PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
        }
    }
}
