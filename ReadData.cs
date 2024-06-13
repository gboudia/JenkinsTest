using MyFirstProject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1;

namespace TestProject1
{
    public class ReadData
    {
        public string file_name;
        public string jsonStr;
        public List<Client> clients;

        public List<Client> ReadDataFromJson()
        {
            file_name = @"C:\\Users\\PC\\Desktop\\campus\\TestProject1\\Data.json";
            using (StreamReader r = new StreamReader(file_name))
            {
                jsonStr = r.ReadToEnd();
                clients = JsonConvert.DeserializeObject<List<Client>>(jsonStr);
            }
            return clients;
        }
    }
}


