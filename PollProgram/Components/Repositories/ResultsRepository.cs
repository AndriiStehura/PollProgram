using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace PollProgram.Components.Repositories
{
    public class ResultsRepository : IFileWorkingRepository
    {
        private DirectoryInfo _directory;
        
        public const string DIRECTORY_PATH = "/Results";

        public ResultsRepository()
        {
            _directory = Directory.CreateDirectory(
                Environment.CurrentDirectory + DIRECTORY_PATH);
            if (!_directory.Exists)
                _directory.Create();
        }
        public string FilePath { get; set; }

        public void SaveAsJson(object toSave)
        {
            FileStream file = File.Create($"{_directory.FullName}/{FilePath}");
            file.Close();
            string json = JsonConvert.SerializeObject(toSave, Formatting.Indented);
            File.WriteAllText(file.Name, json);
        }

        public TObject ReadFromJson<TObject>()
        {
            string json = File.ReadAllText($"{_directory.FullName}/{FilePath}");
            return JsonConvert.DeserializeObject<TObject>(json);
        }

        public bool HasPersonResult(string personsName)
        {
            var files = _directory.EnumerateFiles();
            return files.Any(x => x.Name.Contains(personsName));
        }
    }
}
