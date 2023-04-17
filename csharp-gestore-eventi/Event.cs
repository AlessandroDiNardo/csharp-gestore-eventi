using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class Event
    {
        private string? _title;
        private DateTime _date;
        private int _capacity;
        private int _booked_seats;

        //metodo per il titolo, controlla che il titolo non sia un campo vuoto o null
        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Titolo errato, il titolo non può essere un campo VUOTO!");
                }
                _title = value;
            }
        }

        //metodo per la data, controlla che la data non sia un campo con un data passata
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (value == DateTime.Now.Date)
                {
                    throw new ArgumentException("Data errata, non può essere un dato passato");
                }
                _date = value;
            }
        }

        //metodo per i posti occupati solo in lettura
        public int BookedSeats 
        {
            get
            {
                return _booked_seats;
            }
        }

        //metodo per il calcolo dei posti posti liberi, la capienza massima - i posti occupati
        public int NumFreeSeats
        {
            get { return _capacity - _booked_seats; }
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

            if (Date < DateTime.Now.Date) //controlla se la data inserita sia quella di oggi e che non sia passata
            {
                throw new ArgumentException($"Data inserita non corretta, hai inserito una data passata: {Date}");
            }
            _capacity = capacity;
            _booked_seats = 0; //inizializzo la variabile dei posti prenotati a 0
        }

        // Metodo per prenotare dei posti, ha come parametro la variabile che contiene il numero di posti inseriti dell'utente
        public void ReserveSeats(int num)
        {
            if ( NumFreeSeats == 0) //controlla se ci sono di posti disponibili 
            {
                throw new ArgumentException("Non ci sono posti disponibili per l'evento, mi spiace!");
            }
            else if( num > NumFreeSeats) //controlla se il numero di posti inseriti sia maggiore dei posti disponibili, se è vero appare messaggio di avviso
            {
                throw new ArgumentException($"Non ci sono tutti questi posti disponibili, posti disponibili: {NumFreeSeats}");
            }
          
            _booked_seats += num; //aumenta il numero di posti prenotati
        }

        //metodo per la cancellazione di posti prenotati, ha come parametro la variabile che contiene il numero di posti inseriti dell'utente
        public void CancelSeats(int num)
        {
            if( num > _booked_seats) //controlla se il numero inserito è maggiore dei posti disponibili appare messaggio di avviso
            {
                throw new ArgumentException("Non ci sono abbastanza posti prenotati da disdire");
            }
            else if (Date != DateTime.Now.Date) //controlla se la data inserita sia quella di oggi e che non sia passata
            {
                throw new ArgumentException($"Data inserita non corretta, hai inserito una data passata: {Date}");
            }
            _booked_seats -= num;
        }

        //metodo che restituisce una stringa contenente: data formattata – titolo
        public override string ToString()
        {
            return _date.ToString($"dd/MM/yyyy - {_title}");
        }
    }
}
