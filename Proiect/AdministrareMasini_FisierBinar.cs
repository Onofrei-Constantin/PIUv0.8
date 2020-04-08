using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    public class AdministrareMasini_FisierBinar : IStocareData
    {
        string NumeFisier { get; set; }
        public AdministrareMasini_FisierBinar(string numeFisier)
        {
            this.NumeFisier = numeFisier;
        }
        public void AddMasina(Masina s)
        {
            throw new Exception("Optiunea AddMasina nu este implementata");
        }
        public void Stergere()
        {
            throw new Exception("Optiunea Stergere nu este implementata");
        }
        public Masina[] GetMasini(out int nrMasini)
        {
            throw new Exception("Optiunea GetMasini nu este implementata");
        }
    }
}
