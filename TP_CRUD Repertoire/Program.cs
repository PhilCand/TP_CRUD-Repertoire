using System;
using System.IO;

namespace TP_CRUD_Repertoire
{
    class Program
    {
        

        static void Main()
        {
            bool continuer = true;

            do
            {
                string choixMenu = Affichage.AfficherMenu();
                continuer = Affichage.SwitchMenu(choixMenu);
            }
            while (continuer);
            Console.WriteLine();
            Console.WriteLine("Au revoir");
            File.WriteAllLines("repertoire.txt", DAL.repertoireActuel);
            Console.WriteLine("Mise à jour des données ...");
            Console.WriteLine();
        }

        

        

        



        

        

        

        

        

        

    }
}

