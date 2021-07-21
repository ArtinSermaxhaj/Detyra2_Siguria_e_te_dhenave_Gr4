using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Security.Cryptography;
using System;
using System.Text;

namespace Detyra
{
    public class User
    {
        public string firstName { get; set; }
        public string lastName {get;set;}
        public string username{get;set;}
        public string password{get;set;}
        public string salt {get;set;}
        public List<Fatura> faturat{get;set;}
        [JsonConstructor]
        public User(string firstName,string lastName,string username, string password, string salt){
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.password = password;
            this.salt = salt;
            this.faturat = null;
        }
        [JsonConstructor]
        public User(string firstName,string lastName,string username, string password, string salt,List<Fatura> faturat){
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.password = password;
            this.salt = salt;
            this.faturat = faturat;
        }
        public string CreateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[16];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        public string GenerateHash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            SHA256Managed SHA256String = new SHA256Managed();
            byte[] hash = SHA256String.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}