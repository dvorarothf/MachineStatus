using Newtonsoft.Json;
using System.ComponentModel;

namespace MachineStatusDAL.Models
{
    [JsonObject]
    public class MachineStatus : INotifyPropertyChanged
    {
        public MachineStatus()
        {

        }

        private string _machineName;
        public string MachineName
        {
            get { return _machineName; }
            set
            {
                if (_machineName != value)
                {
                    _machineName = value;
                    OnPropertyChanged("MachineName");
                }
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }


        private MachineStatusValuesEnum _status;
        public MachineStatusValuesEnum Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged("Status");
                }
            }
        }

        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set
            {
                if (_notes != value)
                {
                    _notes = value;
                    OnPropertyChanged("Notes");
                }
            }
        }

        #region PropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}