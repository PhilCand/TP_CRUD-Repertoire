using System;
using System.Linq;
using System.IO;

namespace TP_CRUD_Repertoire
{
    class DAL
    {

        internal static string[] repertoireActuel = CreationBase();

        internal static string[] CreationBase()
        {
            string[] repertoire = {
            "Ramon;Robert;0112356497;93160",
            "Melou;Jeanne;0618976543;77420",
            "Viale;Christian;0243058976;53250" };

            return repertoire;
        }

        internal static void CreerFiche()
        {
            Console.WriteLine("\t Création d'une fiche");
            Console.WriteLine("\t --------------------");

            Array.Resize(ref DAL.repertoireActuel, DAL.repertoireActuel.Length + 1);
            string newFiche = "";

            Affichage.RemplirFicheText(ref newFiche, "Nom : ", ";");
            Affichage.RemplirFicheText(ref newFiche, "Prenom : ", ";");
            Affichage.RemplirFicheNum(ref newFiche, "Téléphone : ", ";");
            Affichage.RemplirFicheNum(ref newFiche, "Code Postal : ", "");

            DAL.repertoireActuel[DAL.repertoireActuel.Length - 1] = newFiche;
            Console.WriteLine();
            Console.WriteLine("\t**** Fiche créée ****");

        }

        internal static void RechercheFiche()
        {
            Console.WriteLine("\t Rechercher une fiche");
            Console.WriteLine("\t ********************");

            Console.Write("Valeur à rechercher : ");
            String recherche = Console.ReadLine();

            int[] result = repertoireActuel.Select((x, i) => x.Contains(recherche) ? i : -1)
                          .Where(x => x != -1)
                          .ToArray();

            Affichage.AfficherFiches(result);
           
        }

        internal static void SupprimerFiche()
        {
            Console.WriteLine("\t    Supprimer une fiche");
            Console.WriteLine("\t    --------------------");
            Affichage.AfficherFiches();
            Console.WriteLine();
            Console.Write("Numero de la fiche à supprimer : ");
            string numeroStr = Console.ReadLine();
            int numero = 0;
            bool succes = Int32.TryParse(numeroStr, out numero);

            if ((numero - 1 >= DAL.repertoireActuel.Length) || (numero - 1 < 0))
            {
                Console.WriteLine();
                Console.WriteLine("\t**** Numero incorrect ****");
                Console.WriteLine();
                return;
            }

            for (int i = numero - 1; i < DAL.repertoireActuel.Length - 1; i++)
                DAL.repertoireActuel[i] = DAL.repertoireActuel[i + 1];

            Array.Resize(ref DAL.repertoireActuel, DAL.repertoireActuel.Length - 1);

            Console.WriteLine();
            Console.WriteLine($"\t**** Fiche numero {numero} supprimée ****");


        }

        internal static void MAJFiche()
        {
            Console.WriteLine("\t  Mettre a jour une fiche");
            Console.WriteLine("\t  -----------------------");
            Affichage.AfficherFiches();
            Console.WriteLine();
            Console.Write("Numero de la fiche : ");

            string numeroStr = Console.ReadLine();
            int numero = 0;
            bool succes = Int32.TryParse(numeroStr, out numero);
            if ((numero > DAL.repertoireActuel.Length) || (numero <= 0))
            {
                Console.WriteLine("\t**** Numero incorrect ****");
                return;
            }

            string fiche = DAL.repertoireActuel[numero - 1];
            string majFiche = "";
            Console.WriteLine("\t Nouvelles données : ");

            Affichage.RemplirFicheText(ref majFiche, "Nom : ", ";");
            Affichage.RemplirFicheText(ref majFiche, "Prenom : ", ";");
            Affichage.RemplirFicheNum(ref majFiche, "Téléphone : ", ";");
            Affichage.RemplirFicheNum(ref majFiche, "Code postal : ", ";");

            DAL.repertoireActuel[numero - 1] = majFiche;
            Console.WriteLine();
            Console.WriteLine($"\t**** Fiche numero {numero} mise à jour ****");

        }

    }
}




