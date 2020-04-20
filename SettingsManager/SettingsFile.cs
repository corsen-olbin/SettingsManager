using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SettingsManager
{
    public class SettingsFile : INotifyPropertyChanged
    {
        private bool _inUse;
        public bool InUse {
            get
            {
                return this._inUse;
            }
            set
            {
                this._inUse = value;
                this.NotifyPropertyChanged("Name");
            }
        }

        private string _description;
        public string Description {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
                this.NotifyPropertyChanged("Description");
            }
        }

        private string _fileLocation;
        public string FileLocation {
            get
            {
                return this._fileLocation;
            }
            set
            {
                this._fileLocation = value;
                this.NotifyPropertyChanged("FileLocation");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
