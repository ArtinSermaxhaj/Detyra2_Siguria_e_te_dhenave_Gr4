using System.Collections.Generic;
using System.Globalization;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Serveri
{
    public class DatabaseManipulation
    {
        private static string fileName = "db.json";
        public static void addUser(User user)
        {
            var jsonObj = readAndParseDatabase();
            JArray usersArray = (JArray)jsonObj["users"];
            JObject userObject = (JObject)JToken.FromObject(user);
            usersArray.Add(userObject);
            jsonObj["users"] = usersArray;
            addToDatabase(jsonObj);
        }
        public static void addFatura(Fatura fatura)
        {
            var jsonObj = readAndParseDatabase();
            JArray usersArray = (JArray)jsonObj["users"];
            JArray billsArray = new JArray();
            JObject billObject = (JObject)JToken.FromObject(fatura);
            if (checkIfUserHasBills(usersArray))
            {
                billsArray = getBills(usersArray);
                billsArray.Add(billObject);
            }
            else
            {
                billsArray.Add(billObject);
                foreach (var user in usersArray)
                {
                    string tempUsername = user["username"].ToString();
                    if (tempUsername.Equals(SessionManager.user.username))
                    {
                        user["faturat"] = billsArray;
                    }
                }
            }

            jsonObj["users"] = usersArray;
            addToDatabase(jsonObj);
        }
        public static bool checkIfUserAlreadyExists(String username)
        {
            var jsonObj = readAndParseDatabase();
            JArray usersArray = (JArray)jsonObj["users"];
            foreach (var user in usersArray)
            {
                string tempUsername = user["username"].ToString();
                if (tempUsername.Equals(username))
                    return true;
            }
            return false;
        }
        public static void addToDatabase(JObject jsonObj)
        {
            string jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(fileName, jsonResult);
        }
        public static JObject readAndParseDatabase()
        {
            var json = File.ReadAllText(fileName);
            JObject jsonObj = JObject.Parse(json);
            return jsonObj;
        }
        public static bool checkIfUserHasBills(JArray users)
        {
            foreach (var user in users)
            {
                string tempUsername = user["username"].ToString();
                if (tempUsername.Equals(SessionManager.user.username))
                    if (user["faturat"].HasValues)
                        return true;
            }
            return false;
        }
        public  static JArray getBills(JArray users)
        {
            JArray bills = null;
            foreach (var user in users)
            {
                string tempUsername = user["username"].ToString();
                if (tempUsername.Equals(SessionManager.user.username))
                    bills = (JArray)user["faturat"];
            }
            return bills;
        }
        public static User getUserBills(String username)
        {
            var jsonObj = readAndParseDatabase();
            JArray usersArray = (JArray)jsonObj["users"];
            try
            {
                foreach (var user in usersArray)
                {
                    string tempUsername = user["username"].ToString();
                    if (tempUsername.Equals(username))
                    {
                        var userObj = user.ToObject<User>();
                        return userObj;
                    }
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}