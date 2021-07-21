using System.Globalization;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Detyra
{
    public class DatabaseManipulation
    {
        private string fileName = "db.json";
        public void addUser(User user)
        {
            var jsonObj = readAndParseDatabase();
            JArray usersArray = (JArray)jsonObj["users"];
            if(checkIfUserAlreadyExists(usersArray,user.username)){
                Console.WriteLine("User already exists.");
            }
            else{
                JObject userObject = (JObject)JToken.FromObject(user);
                usersArray.Add(userObject);
                jsonObj["users"] = usersArray;
                addToDatabase(jsonObj);
            }
        }
        public void addFatura(Fatura fatura){
            var jsonObj = readAndParseDatabase();
            JArray usersArray = (JArray) jsonObj["users"];
            JArray billsArray = getBills(usersArray,"specialitet");
            JObject billObject = (JObject) JToken.FromObject(fatura);
            billsArray.Add(billObject);
            jsonObj["users"] = usersArray;
            addToDatabase(jsonObj);
        }
        public bool checkIfUserAlreadyExists(JArray users, string username){
            foreach(var user in users){
                string tempUsername = user["username"].ToString();
                if(tempUsername.Equals(username))
                return true;
            }
            return false;
        }
        public void addToDatabase(JObject jsonObj){
            string jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(fileName, jsonResult);
        }
        public JObject readAndParseDatabase(){
            var json = File.ReadAllText(fileName);
            JObject jsonObj = JObject.Parse(json);
            return jsonObj;
        }
        public JArray getBills(JArray users, string username){
            JArray bills = null;
            foreach(var user in users){
                string tempUsername = user["username"].ToString();
                if(tempUsername.Equals(username))
                bills = (JArray) user["faturat"];
            }
            return bills;
        }
    }
}