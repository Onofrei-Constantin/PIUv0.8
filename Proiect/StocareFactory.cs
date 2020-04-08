﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Proiect
{
    public static class StocareFactory
    {
        private const string FORMAT_SALVARE = "FormatSalvare";
        private const string NUME_FISIER = "NumeFisier";

        public static IStocareData GetAdministratorStocare()
        {
            var formatSalvare = ConfigurationManager.AppSettings[FORMAT_SALVARE];
            var numeFisier = ConfigurationManager.AppSettings[NUME_FISIER];
            if(formatSalvare!=null)
            {
                switch(formatSalvare)
                {
                    default:
                    case "bin":
                        return new AdministrareMasini_FisierBinar(numeFisier + "." + formatSalvare);
                    case "txt":
                        return new AdministrareMasini_FisierText(numeFisier + "." + formatSalvare);
                }
            }
            return null;
        }
    }
}
