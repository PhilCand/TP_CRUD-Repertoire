using System;
using System.IO;

namespace TP_Crud_DEP
{
    class DomiUtil
    {
        public static string[] RamenerCommune_cp_dep()
        {
            string path = @"..\..\commune-cp-dep.csv";
            StreamReader sr = new StreamReader(path);

            string[] aLignes = sr.ReadToEnd().Split('\n');

            return aLignes;

        }
    }
}
