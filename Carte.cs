using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleCarte
{
    public class Carte
    {
        private string force;
        private string couleur;

        public string Force { get => force; set => force = value; }
        public string Couleur { get => couleur; set => couleur = value; }
        public Carte(string ForceCarte, string CouleurCarte)
        {
            this.force = ForceCarte;
            this.couleur = CouleurCarte;
        }
        public override string ToString()
        {
            return this.force + " " + this.couleur;
        }
    }
}
