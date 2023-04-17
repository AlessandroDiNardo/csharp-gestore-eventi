using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class Event
    {
        private string? title;
        private DateTime date;
        private int capacity;
        private int booked_seats;

        //metodo per il titolo, controlla che il titolo non sia un campo vuoto o null
        public string Title
        {
            get { return title; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Titolo errato, il titolo non può essere un campo VUOTO!");
                }
                title = value;
            }
        }

        //metodo per la data, controlla che la data non sia un campo con un data passata
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (value == DateTime.Now.Date)
                {
                    throw new ArgumentException("Data errata, non può essere un dato passato");
                }
                date = value;
            }
        }

        //metodo per la capeinza massisa solo in lettura
        public int Capacity { get; private set; }

        //metodo per i posti occupati solo in lettura
        public int BookedSeats { get; private set; }

        //metodo per il calcolo dei posti posti liberi, la capienza massima - i posti occupati
        public int NumFreeSeats
        {
            get { return capacity - booked_seats; }
        }

        //dichiarazione costruttore, ha come parametri il titolo, la data, posti a disposizione
        public Event( string title, DateTime date, int capacity)
        {
            Title = title;
            Date = date;
            if (capacity <= 0) //Se la capienza massima è minore o uguale a zero appare messaggio di errore
            {
                throw new ArgumentException("Il valore della capienza massima deve essere un dato positivo");
            }
            Capacity = capacity;
            booked_seats = 0; //inizializzo la variabile dei posti prenotati a 0
        }

        // Metodo per prenotare dei posti, ha come parametro la variabile che contiene il numero di posti inseriti dell'utente
        public void ReserveSeats(int numSeats)
        {
            if ( NumFreeSeats == 0) //controlla se ci sono di posti disponibili 
            {
                throw new ArgumentException("Non ci sono posti disponibili per l'evento, mi spiace!");
            }
            else if( numSeats > NumFreeSeats) //controlla se il numero di posti inseriti sia maggiore dei posti disponibili, se è vero appare messaggio di avviso
            {
                throw new ArgumentException($"Non ci sono tutti questi posti disponibili, posti disponibili: {NumFreeSeats}");
            }
            else if( Date != DateTime.Now.Date) //controlla se la data inserita sia quella di oggi e che non sia passata
            {
                throw new ArgumentException($"Data inserita non corretta, hai inserito una data passata: {Date}");
            }
            booked_seats += numSeats; //aumenta il numero di posti prenotati
        }

        //metodo per la cancellazione di posti prenotati, ha come parametro la variabile che contiene il numero di posti inseriti dell'utente
        public void CancelSeats(int numSeats)
        {
            if( numSeats > booked_seats) //controlla se il numero inserito è maggiore dei posti disponibili appare messaggio di avviso
            {
                throw new ArgumentException("Non ci sono abbastanza posti prenotati da disdire");
            }
            else if (Date != DateTime.Now.Date) //controlla se la data inserita sia quella di oggi e che non sia passata
            {
                throw new ArgumentException($"Data inserita non corretta, hai inserito una data passata: {Date}");
            }
            booked_seats -= numSeats;
        }

        //metodo che restituisce una stringa contenente: data formattata – titolo
        public override string ToString()
        {
            return date.ToString($"dd/MM/yyyy - {title}");
        }

 
    }
}
