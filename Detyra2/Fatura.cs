using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detyra
{
    class Fatura
    {
        public string llojiFatures { get; set; }
        public int viti { get; set; }
        public int muaji { get; set; }
        public double vleraEuro { get; set; }
        public Fatura(string llojiFatures, int viti, int muaji, double vleraEuro)
        {
            this.llojiFatures = llojiFatures;
            this.viti = viti;
            this.muaji = muaji;
            this.vleraEuro = vleraEuro;
        }
    }
}
