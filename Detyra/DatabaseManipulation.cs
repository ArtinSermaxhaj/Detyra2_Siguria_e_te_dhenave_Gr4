using System.Collections.Generic;
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
            JArray billsArray = new JArray();
            JObject billObject = (JObject) JToken.FromObject(fatura);
            if(checkIfUserHasBills(usersArray)){
                billsArray = getBills(usersArray);
                billsArray.Add(billObject);
            }
            else{
                billsArray.Add(billObject);
                foreach(var user in usersArray){
                string tempUsername = user["username"].ToString();
                if(tempUsername.Equals("i moqem")){
                    user["faturat"] = billsArray;
                }
                }
            }

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
        public bool checkIfUserHasBills(JArray users){
            foreach(var user in users){
                string tempUsername = user["username"].ToString();
                if(tempUsername.Equals("i moqem"))
                if(user["faturat"].HasValues)
                return true;
            }
            return false;
        }
        public JArray getBills(JArray users){
            JArray bills = null;
            foreach(var user in users){
                string tempUsername = user["username"].ToString();
                if(tempUsername.Equals("i moqem"))
                bills = (JArray) user["faturat"];
            }
            return bills;
        }
        public User getUserBills(){
            var jsonObj = readAndParseDatabase();
            JArray usersArray = (JArray) jsonObj["users"];
            try{
            foreach(var user in usersArray){
                string tempUsername = user["username"].ToString();
                if(tempUsername.Equals("specialitet")){
                    var userObj = user.ToObject<User>();
                    return userObj;
                }
            }
            }
            catch(Exception ex){
            Console.WriteLine("Error");
            }
            return null;
        }
    }
}