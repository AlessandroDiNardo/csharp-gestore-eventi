namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProgrammaEventi EventGroup = new ProgrammaEventi("Evento Assurdo");

            // Creazione degli eventi
            Event evento1 = new Event("Titolo Evento1 ", new DateTime(2023, 4, 18), 2500);
            Event evento2 = new Event("Titolo Evento2 ", new DateTime(2023, 4, 19), 500);
            Event evento3 = new Event("Titolo Evento3 ", new DateTime(2023, 4, 19), 17900);

            // Aggiunta degli eventi al programma
            EventGroup.AddEvent(evento1);
            EventGroup.AddEvent(evento2);
            EventGroup.AddEvent(evento3);

            
        }
    }
}