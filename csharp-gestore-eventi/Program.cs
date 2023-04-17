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
            Console.WriteLine("Il tuo evento è stato creato!");

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
        }
    }
}