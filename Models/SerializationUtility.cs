using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
namespace WarCardGame.Models
{
    public class SerializationUtility<T>
    {
        private readonly string SubDir = "Data";
        private string WorkingDirectory;
        public SerializationUtility(string SubDirectory){
            this.WorkingDirectory = Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), SubDir, SubDirectory);
        }

        //  <summary>
        //  -Using Newtonsoft, serializes type as json and saves to file in working directory
        //  </summary>
        // <param name="pObj">Instance of givent type to be saved as json</param>
        // <param name="pFileName">String representing file name</param>
        // <returns>None</returns>
        public void Serialize(T pObj, string pFileName){
            string fileName = pFileName.Replace("//","") + ".json";
            string serialized = JsonConvert.SerializeObject(pObj);
            Directory.CreateDirectory(WorkingDirectory);
            File.WriteAllText(Path.Combine(WorkingDirectory, fileName), serialized);
        }

        //  <summary>
        //  -Using Newtonsoft, deserializes object from given json file
        //  </summary>
        // <param name="FileName">String representing file name</param>
        // <returns>Deserialized object of given Type</returns>
        public T Deserialize(string FileName){
            string path = Path.Combine(WorkingDirectory, FileName + ".json");
            if(File.Exists(path)){
                string contents = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<T>(contents);
            }
            return default(T);
        }

        //  <summary>
        //  -Retrieves saved json files in working directory
        //  </summary>
        // <param>None</param>
        // <returns>List of strings representing file names</returns>
        public List<string> GetFiles(){
            if(Directory.Exists(WorkingDirectory)){
                return Directory.GetFiles(WorkingDirectory).Select(file => Path.GetFileNameWithoutExtension(file)).ToList();
            }
            return new List<string>();
        }
    }
}