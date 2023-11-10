using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleCarte
{
    public class Joueur
    {
        private string nom;
        private List<Carte> lesCartes;

        public string Nom { get => nom; set => nom = value; }
        public List<Carte> LesCartes { get => lesCartes; set => lesCartes = value; }

        public Joueur(string NomJoueur)
        {
            this.nom = NomJoueur;
            this.lesCartes = new List<Carte>();
        }

        public void AddCarte(Carte carte)
        {
            lesCartes.Add(carte);
        }

        public Carte JouerCarte()
        {
            Carte joueCarte = lesCartes[0];
            lesCartes.RemoveAt(0);
            return joueCarte;
        }

        public bool AvoirCartes()
        {
            return lesCartes.Count > 0;
        }
    }
}
