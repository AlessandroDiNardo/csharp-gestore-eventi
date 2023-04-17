namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //chiediamo all'utente di inserire i dati per un nuovo evento
            Console.Write("Inserisci titolo dell'evento: ");
            string title = Console.ReadLine();

            //chiediamo all'utente di inserire la data dell'evento
            Console.Write("Inserisci la data dell'evento (in formato: dd/MM/yyyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            //chiediamo all'utente di inserire la capienza massima dell'evento
            Console.Write("Inserisci la capienza massima dell'evento: ");
            int capacity;
            while (!int.TryParse(Console.ReadLine(), out capacity))
                Console.Write("Inserisci un numero");

            Event newEvent = new Event(title, date, capacity);
            Console.WriteLine(newEvent.ToString());

            //chiediamo all'utente di inserire il numero di posti da prenotare
            Console.Write("Vuoi prenotare dei posti? (si/no) : ");
            string answer = Console.ReadLine();

            while (answer.ToLower() == "si")
            {
                Console.Write("Inserisci il numero di posti da prenotare:");
                int numSeats = int.Parse(Console.ReadLine());

                try
                {
                    newEvent.ReserveSeats(numSeats);
                    Console.WriteLine("Prenotazione effettuata con successo");
                    Console.WriteLine($"Posti prenotati: {newEvent.BookedSeats}, posti disponibili: {newEvent.NumFreeSeats}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Vuoi prenotare altri posti? (si/no)");
                answer = Console.ReadLine();
            }

            // Chiediamo all'utente se vuole disdire dei posti
            Console.WriteLine("Vuoi disdire dei posti per l'evento? (si/no)");
            answer = Console.ReadLine();

            while (answer.ToLower() == "si")
            {
                Console.WriteLine("Inserisci il numero di posti da disdire:");
                int numPosti = int.Parse(Console.ReadLine());

                try
                {
                    newEvent.CancelSeats(numPosti);
                    Console.WriteLine("Disdetta effettuata con successo");
                    Console.WriteLine($"Posti prenotati: {newEvent.BookedSeats}, posti disponibili: {newEvent.NumFreeSeats}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue; // chiediamo nuovamente l'input
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Si è verificato un errore durante la disdetta dei posti: " + ex.Message);
                    break; // usciamo dal ciclo while
                }

                Console.WriteLine("Vuoi disdire altri posti? (si/no)");
                answer = Console.ReadLine();
            }

            Console.WriteLine("Riassunto evento:");
            Console.WriteLine($"Titolo: {newEvent.Title}");
            Console.WriteLine($"Data: {newEvent.Date.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Posti prenotati: {newEvent.BookedSeats}");
            Console.WriteLine($"Posti disponibili: {newEvent.NumFreeSeats}");
        }
    }
}