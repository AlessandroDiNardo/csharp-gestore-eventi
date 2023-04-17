using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class ProgrammaEventi
    {
        public string Title { get; set; }
        public List<Event> events { get; set; }

        public ProgrammaEventi(string titolo)
        {
            Title = titolo;
            events = new List<Event>();
        }

        public void AddEvent(Event e)
        {
            events.Add(e);
        }

        public List<Event> FilterData(DateTime data)
        {
            List<Event> eventiInData = new List<Event>();
            foreach (Event e in events)
            {
                if (e.Date == data)
                {
                    eventiInData.Add(e);
                }
            }
            return eventiInData;
        }

        public static string StampaEvent(List<Event> list)
        {
            string stringList = "";
            foreach (Event e in list)
            {
                stringList += e.ToString();
            }
            return stringList;
        }

        public int NumEvent()
        {
            return events.Count;
        }

        public void ClearLista()
        {
            events.Clear();
        }

        public override string ToString()
        {
            string result = $"Il tuo programma: {Title}\n";
            foreach (Event e in events)
            {
                result += $"\t{e}\n";
            }
            return result;
        }

        public Event GetEvent(int index)
        {
            return events[index];
        }

    }
}
