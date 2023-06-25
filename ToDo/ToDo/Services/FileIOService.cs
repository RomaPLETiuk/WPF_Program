using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Services
{
    
    public class FileIOService
    {
        private readonly string PATH;

        public FileIOService(string path)
        {
            PATH = path;
        }


        public BindingList<ToDoModel> LoadData() 
        {
            var fileExist = File.Exists(PATH);
            if (!fileExist) 
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<ToDoModel>();
            }
            using(var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();  
                return JsonConvert.DeserializeObject<BindingList<ToDoModel>>(fileText);

            }
            
        }

        public BindingList<ToDoModel> SaveData(object toDoDateList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(toDoDateList);
                writer.WriteLine(output);


            }

            return new BindingList<ToDoModel>();

        }
    }
}
