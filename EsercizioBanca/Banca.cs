using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserciziII_1
{
    public class Cliente
    {
        public string sNome { get; set; }
        public string sCognome { get; set; }
        public string sCodiceFiscale { get; set; }
        public double dStipendio { get; set; }
    }
    public class Prestito
    {
        public Cliente cIntestatario { get; set; }
        public string sCF { get; set; }
        public double dTotalePrestito { get; set; }
        public double dRataPrestito { get; set; }
        public DateTime dInizioPrestito { get; set; }
        public DateTime dFinePrestito { get; set; }


        //funzione per il calcolare i giorni mancanti alla scadenza del prestito
        public int GiorniAllaScadenza()
        {
            TimeSpan tsAppo = dFinePrestito - DateTime.Now;

            //ritorniamo il risultato in giorni totali
            // (int) sta a significare di convertire in int il valore
            return (int)tsAppo.TotalDays;
        }
    }
    public class Banca
    {
        private string sNomeBanca { get; set; }
        private List<Cliente> lClienteList { get; set; }
        private List<Prestito> lPrestitoList { get; set; }

        public Banca(string sNomeBanca)
        {
            this.sNomeBanca = sNomeBanca;
            lClienteList = new List<Cliente>();
            lPrestitoList = new List<Prestito>();
        }
        public bool AddPrestito(string sCF , double dTotalePrestito, double dRataPrestito, DateTime dInizioPrestito, DateTime dFinePrestito)
        {   
            //dichiaro il nuovo prestito
            Prestito prestito = new Prestito() {sCF = sCF, dTotalePrestito = dTotalePrestito, dRataPrestito = dRataPrestito, dInizioPrestito = dInizioPrestito, dFinePrestito = dFinePrestito };
            //controllo se il cliente esiste giá
            if(lClienteList.Exists(x => x.sCodiceFiscale == sCF))
            {
                lPrestitoList.Add(prestito);
                return true;
            }
            else
                return false;
            
        }

        //funzione per aggiungere un cliente dentro la lista della banca
        public bool AddCliente(string sNome, string sCognome, string sCodiceFiscale, double dStipendio)
        {
            /*
             * forma estesa dell'aggiunta di un cliente alla lista
            Cliente sCliente = new Cliente();
            sCliente.sNome = sNome;
            sCliente.sCognome = sCognome;
            sCliente.sCodiceFiscale = sCodiceFiscale;
            sCliente.dStipendio = dStipendio;
             */

            //forma compressa dell'aggiuta di un cliente alla lista
            // ATTENZIONE SI PUÓ FARE COSÍ SOLO QUANDO PER DICHIARARE LE VARIABILI USO { get; set; }

            Cliente mioCliente = new Cliente() { sNome = sNome, sCognome = sCognome, sCodiceFiscale = sCodiceFiscale, dStipendio = dStipendio };
            //dico alla funzione di aggiongere il cliente alla lista dei clienti
            // questo passaggio é necessario in tutte e due le forme
            lClienteList.Add(mioCliente);
            //se la funzione é andata a buon fine faccio un retunr di true
            return true;
        }

        //tramite questa funziona posso aggiornare lo stipendio del cliente trovandolo tramite il parametro del codice fiscale
        public bool UpdateCLiente(string sCodiceFiscale, double dStipendio)
        {
            //cerco nellalista lCLientiList un cliente X controllando i codici fiscali per vedere se é quello giusto
            Cliente mioCliente = lClienteList.Find(x => x.sCodiceFiscale == sCodiceFiscale);

            if (mioCliente != null)
            {
                mioCliente.dStipendio = dStipendio;
                return true;
            }
            else
            {
                return false;
            }
        }
    }  
}