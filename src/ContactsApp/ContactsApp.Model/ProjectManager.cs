using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ContactsApp.Model
{
    /// <summary>
    /// Класс ProjectManager для реализации сохранения/загрузки файлов
    /// </summary>
    internal class ProjectManager
    {
        /// <summary>
        /// Путь к AppData
        /// </summary>
        private static string _appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        /// <summary>
        /// Путь к папке сохранения
        /// </summary>
        private static string _path = $@"{_appData}\Minnebaev\ContactsApp\data.json";
        
        /// <summary>
        /// Сохранение данных
        /// </summary>
        /// <param name="project"></param>
        public void SaveProject(Project project)
        {
            if(!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
            File.WriteAllText(_path, JsonConvert.SerializeObject(project));
        }

        /// <summary>
        /// Загрузка данных
        /// </summary>
        /// <returns></returns>
        public Project LoadProject()
        {
            try
            {
                Project project;

                using (StreamReader reader = new StreamReader(_path))
                {
                    string jsonData = reader.ReadToEnd();

                    project = JsonConvert.DeserializeObject<Project>(jsonData);
                }

                return project;
            }
            catch
            {
                return null;
            }
        }
    }
}
