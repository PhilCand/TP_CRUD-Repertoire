using System;
using System.Linq;
using System.IO;
using fr.afpa.cdi;

namespace TP_CRUD_Repertoire
{
    class DAL
    {

        internal static string[] repertoireActuel = CreationBase();
        
        internal static string[] CreationBase()
        {

            if (File.Exists("repertoire.txt"))
            {
                string[] repertoire = File.ReadAllLines("repertoire.txt");
                return repertoire;
            }

            else
            {
                string[] repertoire = new string[0];
                return repertoire;
            }
        }

        internal static void CreerFiche()
        {
            Console.WriteLine("\t Création d'une fiche");
            Console.WriteLine("\t --------------------");

            Array.Resize(ref DAL.repertoireActuel, DAL.repertoireActuel.Length + 1);
            string newFiche = "";

            RemplirFicheText(ref newFiche, "Nom : ", ";");
            RemplirFicheText(ref newFiche, "Prenom : ", ";");
            RemplirFicheNum(ref newFiche, "Téléphone : ", ";");
            RemplirFicheNum(ref newFiche, "Code Postal : ", "");

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

            int[] result = repertoireActuel.Select((x, i) => x.ToLower().Contains(recherche.ToLower()) ? i : -1)
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

            RemplirFicheText(ref majFiche, "Nom : ", ";");
            RemplirFicheText(ref majFiche, "Prenom : ", ";");
            RemplirFicheNum(ref majFiche, "Téléphone : ", ";");
            RemplirFicheNum(ref majFiche, "Code postal : ", ";");

            DAL.repertoireActuel[numero - 1] = majFiche;
            Console.WriteLine();
            Console.WriteLine($"\t**** Fiche numero {numero} mise à jour ****");

        }

        internal static void RemplirFicheNum(ref string newFiche, string message, string separateur)
        {

            Console.Write(message);
            string result = Console.ReadLine();
            long pasUtile;

            while ((!long.TryParse(result, out pasUtile)) || (result.Length > 15))
            {
                Affichage.MessageErreur("Uniquement des numéros, 15 chiffres maximum.");
                Console.Write(message);
                result = Console.ReadLine();
            }

            newFiche += result + separateur;
        }

        internal static void RemplirFicheText(ref string newFiche, string message, string separateur)
        {
            string saisie="";
            bool onlychar=false;

            do
            {
                Console.Write(message);
                saisie = Console.ReadLine();
                onlychar = true;
                for (int i = 0; i < saisie.Length; i++)
                    if (!char.IsLetter(saisie[i])) onlychar = false;

                if ((onlychar == false) || (saisie.Length > 15) || (saisie == "")) Affichage.MessageErreur("Uniquement des lettres, 15 caractères maximum.");

            } while ((!onlychar) || (saisie.Length > 15) || (saisie == ""));

            newFiche += saisie + separateur;

        }

        internal static string RechercheDept(string ficheDept)
        {

            string departement;
            bool deptOK = Utils.getDepartmentFromPostcode(int.Parse(ficheDept), out departement);
            if (deptOK) return departement;
            else return "Inconnu";
        }
    }
}




