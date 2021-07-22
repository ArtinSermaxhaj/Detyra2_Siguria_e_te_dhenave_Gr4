using System.Collections.Generic;
using System.Security.Cryptography;
using System;
using System.Text;
using Newtonsoft.Json;

namespace Serveri
{
    public class User
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string mosha {get;set;}
        public string password { get; set; }
        public string salt { get; set; }
        public List<Fatura> faturat { get; set; }
        
        public User()
        {

        }
        
        public User(string firstName, string lastName, string username, string mosha, string password, string salt)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.password = password;
            this.salt = salt;
            this.faturat = null;
            this.mosha = mosha;
        }
        public User(string firstName, string lastName, string username,string mohsa, string password, string salt, List<Fatura> faturat)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.password = password;
            this.salt = salt;
            this.faturat = faturat;
            this.mosha = mosha;
        }
        
    }
}