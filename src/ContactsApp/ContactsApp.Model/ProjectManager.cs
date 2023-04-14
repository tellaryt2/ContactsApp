using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ContactsApp.Model
{
    internal class ProjectManager
    {
        private const string FILE_PATH = @"C:\Users\minne\AppData\Roaming\ContactsApp\ContactsApp.notes";
        
        public void SaveProject(Project project)
        {
            string jsonData = JsonConvert.SerializeObject(project);
            using (StreamWriter writer = new StreamWriter(FILE_PATH))
            {
                writer.Write(jsonData);
            }
        }

        public Project LoadProject()
        {
            Project project;

            using (StreamReader reader = new StreamReader(FILE_PATH))
            {
                string jsonData = reader.ReadToEnd();

                project = JsonConvert.DeserializeObject<Project>(jsonData);
            }

            return project;
        }
    }
}
