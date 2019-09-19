using System;

namespace TP_CRUD_Repertoire
{
    class Affichage
    {
        internal static string AfficherMenu()
        {
            Console.WriteLine("\t REPERTOIRE");
            Console.WriteLine("\t ----------");
            Console.WriteLine("(1) - Créer une fiche");
            Console.WriteLine("(2) - Rechercher une fiche");
            Console.WriteLine("(3) - Mettre a jour une fiche");
            Console.WriteLine("(4) - Supprimer une fiche");
            Console.WriteLine("(5) - Afficher toutes les fiches");
            Console.WriteLine("(6) - Quitter");
            Console.WriteLine();
            Console.Write("Choix : ");

            string choixMenu;

            while (true)
            {
                choixMenu = Console.ReadLine();
                if ((choixMenu == "1") || (choixMenu == "2") || (choixMenu == "3") || (choixMenu == "4") || (choixMenu == "5") || (choixMenu == "6")) break;
                else
                {
                    Console.WriteLine("**** Mauvaise saisie ****");
                    Console.Write("Choix : ");
                }
            }
            Console.Clear();
            return choixMenu;

        }

        internal static bool SwitchMenu(string choixMenu)
        {
            bool continuer = true;
            switch (choixMenu)
            {
                case "1":
                    DAL.CreerFiche();
                    PressKey();
                    break;
                case "2":
                    DAL.RechercheFiche();
                    PressKey();
                    break;
                case "3":
                    DAL.MAJFiche();
                    PressKey();
                    break;
                case "4":
                    DAL.SupprimerFiche();
                    PressKey();
                    break;
                case "5":
                    Affichage.AfficherFiches();
                    PressKey();
                    break;
                case "6":
                    continuer = false;
                    break;
                default:
                    Console.WriteLine("erreur");
                    break;
            }
            return continuer;
        }

        internal static void AfficherFiches()
        {
            Console.WriteLine("\t\t\t Liste de toutes les fiches");
            Console.WriteLine("\t\t\t --------------------------");
            Console.WriteLine($"{"N°",5}|{"Nom",-15}|{"Prenom",-15}|{"Téléphone",15}|{"CP",10}|{"Departement",19}");
            Console.WriteLine("------------------------------------------------------------------------------------");
            for (int i = 0; i < DAL.repertoireActuel.Length; i++)
            {
                string fiche = DAL.repertoireActuel[i];
                string dept = DAL.RechercheDept(fiche.Split(';')[3]);                         
                int index = i + 1;
                Console.WriteLine($"{index,5}|{fiche.Split(';')[0],-15}|{fiche.Split(';')[1],-15}|{fiche.Split(';')[2],15}|{fiche.Split(';')[3],10}|{dept,20}");
            }
        }

        internal static void AfficherFiches(int [] positions)
        {

            Console.WriteLine($"{"N°",5}|{"Nom",-15}|{"Prenom",-15}|{"Téléphone",15}|{"CP",10}");
            Console.WriteLine("-----------------------------------------------------------------");

            foreach (int index in positions)
            {
                string fiche = DAL.repertoireActuel[index];
                int pos = index + 1;
                Console.WriteLine($"{pos,5}|{fiche.Split(';')[0],-15}|{fiche.Split(';')[1],-15}|{fiche.Split(';')[2],15}|{fiche.Split(';')[3],10}");

            }

        }

        internal static void PressKey()
        {
            Console.WriteLine();
            Console.WriteLine("Appuyez sur une touche");
            Console.ReadKey();
            Console.Clear();
        }
               
        internal static void MessageErreur(string erreur)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(erreur);
            Console.ResetColor();
        }

    }

}

