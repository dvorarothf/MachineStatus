using MachineStatusDAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MachineStatusBL
{
    public static class JsonHelper
    {
        private static string _filePath = "machineStatusData.json";
        public static void WriteListToJsonFile(List<MachineStatus> objectToWrite)
        {
            var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
            using (var writer = new StreamWriter(_filePath))
            {
                writer.Write(contentsToWriteToFile);
            }
        }

        public static void WriteToJsonFile<MachineStatus>(MachineStatus objectToWrite)
        {
            var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
            using (var writer = new StreamWriter(_filePath))
            {
                writer.Write(contentsToWriteToFile);
            }
        }

        public static MachineStatus ReadFromJsonFile()
        {
            using (StreamReader reader = new StreamReader(_filePath))
            {
                string json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<MachineStatus>(json);

            }
        }

        public static List<MachineStatus> ReadListFromJsonFile()
        {
            var objectOut = new List<MachineStatus>();
            try
            {
                string fromJson = File.ReadAllText(_filePath);
                if (fromJson != "")
                {
                    //var array = fromJson.Split('}');
                    //for (int i = 0; i < array.Length; i++)
                    //{
                    //    var item = array[i];
                    //    if (item != "")
                    //    {
                    //        item += "}";
                    //        objectOut.Add(JsonConvert.DeserializeObject<MachineStatus>(item));
                    //    }
                    //}
                    objectOut = JsonConvert.DeserializeObject<List<MachineStatus>>(fromJson);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objectOut;

        }

        //public static void ClearFile()
        //{
        //    var contentsToWriteToFile = JsonConvert.SerializeObject("[null]");
        //    using (var writer = new StreamWriter(_filePath))
        //    {
        //        writer.Write(contentsToWriteToFile);
        //    }
        //}


    }
}