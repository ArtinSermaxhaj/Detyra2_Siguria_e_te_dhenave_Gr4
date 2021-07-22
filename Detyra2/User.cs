using System.Collections.Generic;
using System.Security.Cryptography;
using System;
using System.Text;
using Newtonsoft.Json;

namespace Detyra
{
    public class User
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public List<Fatura> faturat { get; set; }
        
        public User()
        {

        }
        
        public User(string firstName, string lastName, string username, string password, string salt)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.password = password;
            this.salt = salt;
            this.faturat = null;
        }
        public User(string firstName, string lastName, string username, string password, string salt, List<Fatura> faturat)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.password = password;
            this.salt = salt;
            this.faturat = faturat;
        }
        
    }
}