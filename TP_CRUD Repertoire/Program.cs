using System;

namespace TPCRUD
{
    class Program
    {
        public static string[] repertoireActuel = CreationBase();

        static void Main()
        {
            Console.WriteLine("\t REPERTOIRE");
            Console.WriteLine("\t ----------");

            bool continuer = true;

            do
            {
                string choixMenu = AfficherMenu();
                continuer = SwitchMenu(choixMenu);
            }
            while (continuer);
            Console.WriteLine("Au revoir");

        }

        public static string AfficherMenu()
        {
            Console.WriteLine("(1) - Créer une fiche");
            Console.WriteLine("(2) - Rechercher une fiche");
            Console.WriteLine("(3) - Mettre a jour une fiche");
            Console.WriteLine("(4) - Supprimer une fiche");
            Console.WriteLine("(5) - Afficher toutes les fiches");
            Console.WriteLine("(6) - Quitter");
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

        }//OK

        public static bool SwitchMenu(string choixMenu)
        {
            bool continuer = true;
            switch (choixMenu)
            {
                case "1":
                    CreerFiche();
                    PressKey();
                    break;
                case "2":
                    RechercheFiche();
                    PressKey();
                    break;
                case "3":
                    MAJFiche();
                    PressKey();
                    break;
                case "4":
                    SupprimerFiche();
                    PressKey();
                    break;
                case "5":
                    AfficherFiches();
                    PressKey();
                    break;
                case "6":
                    continuer = false;
                    PressKey();
                    break;
                default:
                    Console.WriteLine("erreur");
                    break;
            }
            return continuer;
        } //OK

        public static void CreerFiche()
        {
            Console.WriteLine("\t Création d'une fiche");
            Console.WriteLine("\t ---------------------");

            Array.Resize(ref repertoireActuel, repertoireActuel.Length + 1);
            string newFiche = "";

            RemplirFiche(ref newFiche, "Nom : ", ";");
            RemplirFiche(ref newFiche, "Prenom : ", ";");
            RemplirFiche(ref newFiche, "Téléphone : ", ";");
            RemplirFiche(ref newFiche, "Code Postal : ", "");

            repertoireActuel[repertoireActuel.Length - 1] = newFiche;
            Console.WriteLine();
            Console.WriteLine("\t**** Fiche créée ****");

        } //OK

        private static void RemplirFiche(ref string newFiche, string message, string separateur)
        {
            Console.Write(message);
            newFiche += Console.ReadLine() + separateur;
        } //OK

        public static void RechercheFiche()
        {
            Console.WriteLine("\t Rechercher une fiche");
            Console.WriteLine("\t ********************");



        }

        public static void MAJFiche()
        {
            Console.WriteLine("\t  Mettre a jour une fiche");
            Console.WriteLine("\t  -----------------------");
            AfficherFiches();
            Console.WriteLine();
            Console.Write("Numero de la fiche : ");

            string numeroStr = Console.ReadLine();
            int numero = 0;
            bool succes = Int32.TryParse(numeroStr, out numero);
            if ((numero > repertoireActuel.Length) || (numero <= 0))
            {
                Console.WriteLine("\t**** Numero incorrect ****");
                return;
            }

            string fiche = repertoireActuel[numero - 1];
            string majFiche = "";
            Console.WriteLine("\t Nouvelles données : ");

            RemplirFiche(ref majFiche, "Nom : ", ";");
            RemplirFiche(ref majFiche, "Prenom : ", ";");
            RemplirFiche(ref majFiche, "Téléphone : ", ";");
            RemplirFiche(ref majFiche, "Code postal : ", ";");

            repertoireActuel[numero - 1] = majFiche;
            Console.WriteLine();
            Console.WriteLine($"\t**** Fiche numero {numero} mise à jour ****");

        } //OK

        public static void SupprimerFiche()
        {
            Console.WriteLine("\t    Supprimer une fiche");
            Console.WriteLine("\t    --------------------");
            AfficherFiches();
            Console.WriteLine();
            Console.Write("Numero de la fiche à supprimer : ");
            string numeroStr = Console.ReadLine();
            int numero = 0;
            bool succes = Int32.TryParse(numeroStr, out numero);

            if ((numero - 1 >= repertoireActuel.Length) || (numero - 1 < 0))
            {
                Console.WriteLine();
                Console.WriteLine("\t**** Numero incorrect ****");
                Console.WriteLine();
                return;
            }

            for (int i = numero - 1; i < repertoireActuel.Length - 1; i++)
                repertoireActuel[i] = repertoireActuel[i + 1];

            Array.Resize(ref repertoireActuel, repertoireActuel.Length - 1);

            Console.WriteLine();
            Console.WriteLine($"\t**** Fiche numero {numero} supprimée ****");


        } //OK

        public static void AfficherFiches()
        {
            Console.WriteLine("\t \tListe de toutes les fiches");
            Console.WriteLine("\t \t--------------------------");
            Console.WriteLine($"{"N°",5}|{"Nom",-15}|{"Prenom",-15}|{"Téléphone",15}|{"CP",10}");
            Console.WriteLine("-----------------------------------------------------------------");
            for (int i = 0; i < repertoireActuel.Length; i++)
            {
                string fiche = repertoireActuel[i];
                int index = i + 1;
                Console.WriteLine($"{index,5}|{fiche.Split(';')[0],-15}|{fiche.Split(';')[1],-15}|{fiche.Split(';')[2],15}|{fiche.Split(';')[3],10}");
                //Console.WriteLine(index + " - " + fiche.Split(';')[0] + " - " + fiche.Split(';')[1] + " - " + fiche.Split(';')[2] + " - " + fiche.Split(';')[3]);
            }


        } //OK

        public static string[] CreationBase()
        {
            string[] repertoire = {
            "Ramon;Robert;0112356497;93160",
            "Melou;Jeanne;0618976543;77420",
            "Viale;Christian;0243058976;53250" };

            return repertoire;
        } //OK

        public static void PressKey()
        {
            Console.WriteLine();
            Console.WriteLine("Appuyez sur une touche");
            Console.ReadKey();
            Console.Clear();
        }

    }
}

