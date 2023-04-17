using System.Diagnostics.Metrics;

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inserisci il nome del tuo programma eventi:\t");
            string? nameEvent = Console.ReadLine();
            ProgrammaEventi EventGroup = new ProgrammaEventi(nameEvent);

            Console.Write("Indica il numero di eventi da inserire: ");
            int nEvent = int.Parse(Console.ReadLine());

            for (int i = 0; i < nEvent; i++)
            {
                try
                {
                    Console.Write($"\nInserisci il nome del {i + 1} evento: ");
                    string? titleEvent = Console.ReadLine();

                    Console.Write("Inserisci la data dell'evento (dd/MM/yyyy): ");
                    DateTime dateEvent = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                    Console.Write("Inserisci il numero di posti totale dell'evento:");
                    int nSeats = int.Parse(Console.ReadLine());

                    Event newEvent = new Event(titleEvent, dateEvent, nSeats);
                    EventGroup.AddEvent(newEvent);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Errore: {ex.Message}");
                    i--;
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Errore: Formato non valido.");
                    i--;
                    continue;
                }

                Event currentEvent = EventGroup.GetEvent(i);

                //chiediamo all'utente di inserire il numero di posti da prenotare
                Console.Write("Vuoi prenotare dei posti? (si/no) : ");
                string answer = Console.ReadLine();
                while (answer.ToLower() == "si")
                {
                    Console.Write("Inserisci il numero di posti da prenotare:");
                    int numSeats = int.Parse(Console.ReadLine());
                    try
                    {
                        currentEvent.ReserveSeats(numSeats);
                        Console.WriteLine("Prenotazione effettuata con successo");
                        Console.WriteLine($"Posti prenotati: {currentEvent.BookedSeats}, posti disponibili: {currentEvent.NumFreeSeats}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.Write("Vuoi prenotare altri posti? (si/no)");
                    answer = Console.ReadLine();
                }

                // Chiediamo all'utente se vuole disdire dei posti
                Console.Write("Vuoi disdire dei posti per l'evento? (si/no)");
                answer = Console.ReadLine();

                while (answer.ToLower() == "si")
                {
                    Console.WriteLine("Inserisci il numero di posti da disdire:");
                    int numPosti = int.Parse(Console.ReadLine());

                    try
                    {
                        currentEvent.CancelSeats(numPosti);
                        Console.WriteLine("Disdetta effettuata con successo");
                        Console.WriteLine($"Posti prenotati: {currentEvent.BookedSeats}, posti disponibili: {currentEvent.NumFreeSeats}");
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

                    Console.Write("Vuoi disdire altri posti? (si/no)");
                    answer = Console.ReadLine();
                }
            }



            Console.WriteLine($"Nel tuo programma ci sono: {EventGroup.NumEvent()} eventi");
            Console.WriteLine("Ecco la lista degli eventi inseriti:");
            Console.WriteLine(EventGroup.ToString());

            Console.WriteLine("Inserisci una data per visualizzare gli eventi in quella data (formato: dd/mm/yyyy):");
            DateTime dataRicerca = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            List<Event> eventiInData = EventGroup.FilterData(dataRicerca);

            Console.WriteLine($"Eventi in data {dataRicerca.ToString("dd/MM/yyyy")}:");
            Console.WriteLine(ProgrammaEventi.StampaEvent(eventiInData));
        }
    }
}