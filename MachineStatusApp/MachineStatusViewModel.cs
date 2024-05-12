using MachineStatusBL;
using MachineStatusDAL.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MachineStatusApp
{
    public class MachineStatusViewModel : NotificationObject, IDisposable
    {
        #region members
        private MachineStatusBLFunctions _bl;
        #endregion

        #region Properties
        private ObservableCollection<MachineStatusValuesEnum> _statusEnumList;
        public ObservableCollection<MachineStatusValuesEnum> StatusEnumList
        {
            get { return _statusEnumList; }
            set
            {
                _statusEnumList = value;
                RaisePropertyChanged(() => StatusEnumList);
            }
        }

        private ObservableCollection<MachineStatus> _machineStatusList;
        public ObservableCollection<MachineStatus> MachineStatusList
        {
            get { return _machineStatusList; }
            set
            {
                _machineStatusList = value;
                RaisePropertyChanged(() => MachineStatusList);
            }
        }

        //private MachineStatus _selectedMachineStatus;
        //public MachineStatus SelectedMachineStatus
        //{
        //    get { return _selectedMachineStatus; }
        //    set
        //    {
        //        _selectedMachineStatus = value;
        //        RaisePropertyChanged(() => SelectedMachineStatus);
        //    }
        //}
        #endregion

        #region Commands
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        #endregion

        public void Init()
        {
            try
            {
                StatusEnumList = new ObservableCollection<MachineStatusValuesEnum>
                {
                    MachineStatusValuesEnum.Running,
                    MachineStatusValuesEnum.Idle,
                    MachineStatusValuesEnum.Offline
                };

                _bl = new MachineStatusBLFunctions();

                MachineStatusList = new ObservableCollection<MachineStatus>(_bl.Load());
                //{
                //    new MachineStatus
                //    {
                //        MachineName = "xx",
                //        Description = "v",
                //        Notes = "hgfjghgcv",
                //        Status = MachineStatusValuesEnum.Running
                //    }
                //};

                if (MachineStatusList.Count == 0)
                {
                    MachineStatusList.Add(new MachineStatus());
                    _bl.InitFile(MachineStatusList.ToList());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"sorry for exception: \n{ex.Message}");
            }

            AddCommand = new DelegateCommand(OnAddClick);
            DeleteCommand = new DelegateCommand<MachineStatus>(OnDeleteClick);
            SaveCommand = new DelegateCommand(OnSaveClick);
        }

        public void OnAddClick()
        {
            MachineStatusList.Add(new MachineStatus());
            if (Save())
                MessageBox.Show("Machine status added successfully");
        }

        public void OnDeleteClick(MachineStatus item)
        {
            if (MessageBox.Show("Are you sure you want to delete this machine?") == MessageBoxResult.OK)
            {
                MachineStatusList.Remove(item);
                if (Save())
                    MessageBox.Show("Machine status removed successfully");
            }
        }

        public void OnSaveClick()
        {
            if (Save())
                MessageBox.Show("Machine statuses saved successfully");
        }

        private bool Save()
        {
            try
            {
                for (int i = 0; i < MachineStatusList.Count; i++)
                {
                    var item = MachineStatusList[i];
                    if (item.MachineName == null || item.MachineName == "")
                    {
                        MessageBox.Show($"MachineName for machine number {i + 1} cannot be empty");
                        return false;
                    }
                }

                return _bl.Save(MachineStatusList.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"sorry for exception: \n {ex.Message}");
            }
            return false;
        }

        public void Dispose()
        {

        }
    }
}