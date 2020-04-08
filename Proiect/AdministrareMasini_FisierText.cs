using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    public class AdministrareMasini_FisierText : IStocareData
    {
        private const int PAS_ALOCARE = 18;
        string NumeFisier { get; set; }
        public AdministrareMasini_FisierText(string numeFisier)
        {
            this.NumeFisier = numeFisier;
            Stream sFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            sFisierText.Close();
        }
        public void Stergere()
        {
            File.WriteAllText(NumeFisier, String.Empty);
        }
        public void AddMasina(Masina s)
        {
            try
            {
                using (StreamWriter swFisierText=new StreamWriter(NumeFisier,true))
                {
                    swFisierText.WriteLine(s.ConversiaLaSir_PentruFisier());
                }
            }
            catch(IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch(Exception eGen)
            {
                throw new Exception("Eroare generica.Mesaj: " + eGen.Message);
            }
        }
        

        public Masina[] GetMasini(out int nrMasini)
        {
            Masina[] masini = new Masina[PAS_ALOCARE];

            try
            {
                using (StreamReader sr=new StreamReader(NumeFisier))
                {
                    string line;
                    nrMasini=0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        masini[nrMasini++] = new Masina(line);
                        if(nrMasini==PAS_ALOCARE)
                        {
                            Array.Resize(ref masini, nrMasini + PAS_ALOCARE);
                        }
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
            return masini;
        }
    }
}
