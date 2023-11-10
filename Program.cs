using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace BatailleCarte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List < Carte > cartes = GenererCartes(); // Créer un jeu de cartes
            
            MelangerCartes(cartes); // Mélanger cartes

            Joueur joueur1 = new Joueur("Joueur 1"); // Créer joueurs
            Joueur joueur2 = new Joueur("Joueur 2");

            DistribuerCartes(cartes, joueur1, joueur2); // Distribuer les cartes aux joueurs

            while (joueur1.AvoirCartes() && joueur2.AvoirCartes())
            {
                JouerBataille(joueur1, joueur2);
            }

            
            if (!joueur1.AvoirCartes() && !joueur2.AvoirCartes()) // Vérifie le gagnant de la partie
                Console.WriteLine("Match nul.");
            else if (!joueur1.AvoirCartes())
                Console.WriteLine($"{joueur2.Nom} a gagné la partie.");
            else
                Console.WriteLine($"{joueur1.Nom} a gagné la partie.");

            Console.ReadLine();
        }
        static List<Carte> GenererCartes()
        {
            List<Carte> cartes = new List<Carte>();
            string[] couleurs = { "Trèfle", "Carreau", "Coeur", "Pique" };
            string[] forces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Valet", "Dame", "Roi", "As" };

            foreach (string couleur in couleurs)
            {
                foreach (string force in forces)
                {
                    cartes.Add(new Carte(force, couleur));
                }
            }

            return cartes;
        }
        static void MelangerCartes(List<Carte> cartes)
        {
            Random random = new Random();
            int n = cartes.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Carte valeur = cartes[k];
                cartes[k] = cartes[n];
                cartes[n] = valeur;
            }
        }
        static void DistribuerCartes(List<Carte> cartes, Joueur joueur1, Joueur joueur2)
        {
            for (int i = 0; i < cartes.Count; i++)
            {
                if (i % 2 == 0)
                    joueur1.AddCarte(cartes[i]);
                else
                    joueur2.AddCarte(cartes[i]);
            }
        }


        static void JouerBataille(Joueur joueur1, Joueur joueur2)
        {
            while (joueur1.AvoirCartes() && joueur2.AvoirCartes())
            {
                Carte carte1 = joueur1.JouerCarte();
                Carte carte2 = joueur2.JouerCarte();

                Console.WriteLine($"{joueur1.Nom} joue: {carte1}");
                Console.WriteLine($"{joueur2.Nom} joue: {carte2}");

                int result = CompareCartes(carte1, carte2);

                if (result > 0)
                {
                    Console.WriteLine($"{joueur1.Nom} gagne la manche.\n");
                    joueur1.AddCarte(carte1);
                    joueur1.AddCarte(carte2);
                }
                else if (result < 0)
                {
                    Console.WriteLine($"{joueur2.Nom} gagne la manche.\n");
                    joueur2.AddCarte(carte1);
                    joueur2.AddCarte(carte2);
                }
                else
                {
                    Console.WriteLine("Bataille.\n");
                    Bataille(joueur1, joueur2);
                }

                Console.ReadLine();
            }

            if (!joueur1.AvoirCartes())
                Console.WriteLine($"{joueur2.Nom} a gagné.");
            else if (!joueur2.AvoirCartes())
                Console.WriteLine($"{joueur1.Nom} a gagné.");
        }

        static void Bataille(Joueur joueur1, Joueur joueur2)
        {
            List<Carte> batailleCartes = new List<Carte>();

            if (joueur1.AvoirCartes() && joueur2.AvoirCartes())
            {
                Carte carte1 = joueur1.JouerCarte();
                Carte carte2 = joueur2.JouerCarte();

                batailleCartes.Add(carte1);
                batailleCartes.Add(carte2);

                Console.WriteLine($"{joueur1.Nom} joue: {carte1}");
                Console.WriteLine($"{joueur2.Nom} joue: {carte2}");
            }

            if (joueur1.AvoirCartes() && joueur2.AvoirCartes())
            {
                Carte carte1 = joueur1.JouerCarte();
                Carte carte2 = joueur2.JouerCarte();

                batailleCartes.Add(carte1);
                batailleCartes.Add(carte2);

                Console.WriteLine($"{joueur1.Nom} joue: {carte1}");
                Console.WriteLine($"{joueur2.Nom} joue: {carte2}");
            }

            int result = CompareCartes(batailleCartes[batailleCartes.Count - 2], batailleCartes[batailleCartes.Count - 1]);

            if (result > 0)
            {
                Console.WriteLine($"{joueur1.Nom} gagne la bataille.\n");
                joueur1.LesCartes.AddRange(batailleCartes); // Ajoute les cartes au joueur gagnant
            }
            else if (result < 0)
            {
                Console.WriteLine($"{joueur2.Nom} gagne la bataille.\n");
                joueur2.LesCartes.AddRange(batailleCartes); // Ajoute les cartes au joueur gagnant
            }
            else
            {
                Console.WriteLine("La bataille continue.\n");
                Bataille(joueur1, joueur2);
            }
        }

        static int CompareCartes(Carte carte1, Carte carte2)
        {
            string[] forces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Valet", "Dame", "Roi", "As" };

            int force1 = Array.IndexOf(forces, carte1.Force);
            int force2 = Array.IndexOf(forces, carte2.Force);

            return force1 - force2;
        }

    }
}