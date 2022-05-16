using System;

namespace EserciziII_1 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // creiamo una istanza della classe UNIVERSITÁ
            universita lMiaUniversita = new universita();

            //carichiamo i dati dal dal file 
            // e li mettiamo nella nostra istanza di universitá

            Console.WriteLine("Lista operazioni");
            Console.WriteLine("1: immetti un nuovo studente");
            Console.WriteLine("2: immetti nuova sede");
            Console.WriteLine("");
            Console.WriteLine("Premi invio per usicre");
            string sOperazione = Console.ReadLine();

            while(sOperazione != "")
            {
                //veritica il codice operazione inserito dall'untente

                if(Convert.ToInt32(sOperazione) == 1)
                {
                    //chiedi
                }
                else if (Convert.ToInt32(sOperazione) == 2)
                {
                    //chiedi la sede
                    string sSede = Console.ReadLine();
                    lMiaUniversita.AggiungiSede(sSede);
                }
                Console.WriteLine("Cosa vuoi fare (PREMI INVIO PER USCIRE):");
            }
            //Salviamo tutti i dati che stanno in lMiaUniversita nel file archivio
            //e usciammo 
        }
    }
}