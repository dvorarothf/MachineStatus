using MachineStatusDAL.Models;
using System;
using System.Collections.Generic;

namespace MachineStatusBL
{
    public class MachineStatusBLFunctions
    {
        public List<MachineStatus> Load()
        {
            return JsonHelper.ReadListFromJsonFile();
        }

        public void InitFile(List<MachineStatus> list)
        {
            JsonHelper.WriteListToJsonFile(list);
        }

        public bool Save(List<MachineStatus> item)
        {
            try
            {
                JsonHelper.WriteListToJsonFile(item);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

    }
}