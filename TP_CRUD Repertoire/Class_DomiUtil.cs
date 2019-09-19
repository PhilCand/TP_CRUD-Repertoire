using System;
using System.IO;

namespace TP_CRUD_Repertoire
{
    class DomiUtil
    {
        internal static string[] RamenerCommune_cp_dep()
        {
            string path = @"..\..\commune-cp-dep.csv";
            StreamReader sr = new StreamReader(path);

            string[] aLignes = sr.ReadToEnd().Split('\n');

            return aLignes;

        }
    }
}
