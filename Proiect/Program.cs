using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    class Program
    {
        static void Main(string[] args)
        {
            Masina[] masini;
            IStocareData adminMasini = StocareFactory.GetAdministratorStocare();
            int nrMasini;
            masini = adminMasini.GetMasini(out nrMasini);
            Masina.IdUltimaMasina = nrMasini;

            string optiune;
            do
            {
                Console.WriteLine("L. Listare masini");
                Console.WriteLine("A. Adaugare masina");
                Console.WriteLine("M. Modificare date masina");
                Console.WriteLine("X. Inchidere program");
                Console.WriteLine("C. Comparare masini");
                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();
                Console.Clear();
                switch (optiune.ToUpper())
                {
                    case "L":
                        AfisareMasini(masini, nrMasini);
                        break;
                    case "A":
                        Masina s = CitireMasinaTastatura();
                        masini[nrMasini] = s;
                        nrMasini++;
                        adminMasini.AddMasina(s);
                        break;
                    case "M":
                        Masina[] masinaModificare;
                        masinaModificare = adminMasini.GetMasini(out nrMasini);
                        Console.WriteLine("Ce masina ati dori sa modificati ?");
                        for (int i = 0; i < nrMasini; i++)
                        {
                            Console.WriteLine("[{0}]: {1}",i, masinaModificare[i].ConversieLaSir());
                        }

                        int opt = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ce doriti sa modificati la acesta masina ?");
                        Console.WriteLine("[0]Nume Vanzator:{0}\n [1]Nume Cumparator:{1}\n [2]Tip:{2} \n [3]An Fabricare:{3} \n [4]Data Tranzactie:{4} \n [5]Pret:{5} \n [6]Optiune:{6} \n [7]Culoare:{7} \n", masinaModificare[opt].NumeVanzator, masinaModificare[opt].NumeCumparator, masinaModificare[opt].Tip, masinaModificare[opt].AnFabricare, masinaModificare[opt].DataTranzactie, masinaModificare[opt].Pret, masinaModificare[opt].ProgramOptiuni, masinaModificare[opt].ProgramCulori);
                        int Optiune = int.Parse(Console.ReadLine());
                        switch (Optiune)
                        {
                            case 0:
                                masinaModificare[opt].NumeVanzator = Console.ReadLine();
                                break;
                            case 1:
                                masinaModificare[opt].NumeCumparator = Console.ReadLine();
                                break;
                            case 2:
                                masinaModificare[opt].Tip = Console.ReadLine();
                                break;
                            case 3:
                                masinaModificare[opt].AnFabricare = Console.ReadLine();
                                break;
                            case 4:
                                masinaModificare[opt].DataTranzactie = Console.ReadLine();
                                break;
                            case 5:
                                masinaModificare[opt].Pret = Console.ReadLine();
                                break;
                            case 6:
                                Console.WriteLine("Dati optiune masina: \n1.Cutie Automata \n2.Aer Conditionat \n3.Navigatie");
                                masinaModificare[opt].ProgramOptiuni = (Optiuni)Int32.Parse(Console.ReadLine());
                                break;
                            case 7:
                                Console.WriteLine("Dati culoare masina: \n1.Alb \n2.Negru \n3.Rosu");
                                masinaModificare[opt].ProgramCulori = (Culori)Int32.Parse(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Nu exista optiunea!");
                                break;
                        }
                        adminMasini.Stergere();
                        for (int i = 0; i < nrMasini; i++)
                        {
                            adminMasini.AddMasina(masinaModificare[i]);
                        }
                        AfisareMasini(masinaModificare, nrMasini);
                        masini = masinaModificare;
                        break;
                    case "C":
                        Masina[] masinaComparare = new Masina[2];
                        Console.WriteLine("Care vor fi masinile comparate?");
                        Console.WriteLine("--MASINA 1--");
                        Console.WriteLine("Dati nume vazator:");
                        string numeC1 = Console.ReadLine();
                        Console.WriteLine("Dati firma + model:");
                        string numeV1 = Console.ReadLine();
                        s = CautMasina(numeC1, numeV1, nrMasini, masini);
                        masinaComparare[0] = s;
                        Console.WriteLine("--MASINA 2--");
                        Console.WriteLine("Dati nume vazator:");
                        string numeC2 = Console.ReadLine();
                        Console.WriteLine("Dati firma + model:");
                        string numeV2 = Console.ReadLine();
                        s = CautMasina(numeC2, numeV2, nrMasini, masini);
                        masinaComparare[1] = s;
                        var finala = Masina.ComparaDouaMasini(masinaComparare[0], masinaComparare[1]);
                        Console.WriteLine("{0}",finala);
                        break;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }
        public static Masina CautMasina(string numeVanzator,string tip,int nrMasini,Masina[] sir_masini)
        {
            for(int i=0;i<nrMasini;i++)
            {
                if (string.Equals(numeVanzator, sir_masini[i].NumeVanzator) && string.Equals(tip, sir_masini[i].Tip))
                return sir_masini[i];
            }
            return null;
        }
        public static void AfisareMasini(Masina[] masini,int nrMasini)
        {
            Console.WriteLine("Masinile sunt:");
            for(int i=0;i<nrMasini;i++)
            {
                Console.WriteLine(masini[i].ConversieLaSir());
            }
        }
        public static Masina CitireMasinaTastatura()
        {
            Console.WriteLine("Introduceti numele vazatorului");
            string numeVanzator = Console.ReadLine();
            Console.WriteLine("Introduceti numele cumparatorului");
            string numeCumparator = Console.ReadLine();
            Console.WriteLine("Introduceti firma + model");
            string tip = Console.ReadLine();
            Console.WriteLine("Introduceti an fabricare");
            string anFabricare = Console.ReadLine();
            Console.WriteLine("Introduceti data tranzactie");
            string dataTranzactie = Console.ReadLine();
            Console.WriteLine("Introduceti pret");
            string pret = Console.ReadLine();

            Masina s = new Masina(numeVanzator, numeCumparator, tip, anFabricare, dataTranzactie, pret);
            Console.WriteLine("Dati optiune masina: \n1.Cutie Automata \n2.Aer Conditionat \n3.Navigatie");
            s.ProgramOptiuni = (Optiuni)Int32.Parse(Console.ReadLine());
            Console.WriteLine("Dati culoare masina: \n1.Alb \n2.Negru \n3.Rosu");
            s.ProgramCulori = (Culori)Int32.Parse(Console.ReadLine());
            Console.Clear();
            return s;
        }
    }
}
