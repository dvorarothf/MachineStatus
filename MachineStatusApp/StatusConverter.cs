using MachineStatusDAL.Models;
using System;
using System.Windows.Data;

namespace MachineStatusApp
{
    public class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is MachineStatusValuesEnum)
            {
                var status = (MachineStatusValuesEnum)value;
                switch (status)
                {
                    case MachineStatusValuesEnum.Running:
                        return "/Assets/Images/Run.png";
                    case MachineStatusValuesEnum.Idle:
                        return "/Assets/Images/idle.png";
                    case MachineStatusValuesEnum.Offline:
                        return "/Assets/Images/offline.png";
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
