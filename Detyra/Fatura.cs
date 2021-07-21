using System.Text.Json.Serialization;

namespace Detyra
{
    public class Fatura
    {
        public string llojiFatures{get;set;}
        public int viti{get;set;}
        public int muaji{get;set;}
        public double vleraEuro{get;set;}
        [JsonConstructor]
        public Fatura(string llojiFatures,int viti, int muaji,double vleraEuro){
            this.llojiFatures = llojiFatures;
            this.viti = viti;
            this.muaji = muaji;
            this.vleraEuro = vleraEuro;
        }
    }
}