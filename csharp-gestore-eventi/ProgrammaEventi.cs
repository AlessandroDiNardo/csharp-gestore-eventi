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
        public List<Event> Events { get; set; }

        public ProgrammaEventi(string titolo)
        {
            Title = titolo;
            Events = new List<Event>();
        }

        public void AddEvent(Event e)
        {
            Events.Add(e);
        }

        public List<Event> FilterData(DateTime data)
        {
            List<Event> eventiInData = new List<Event>();
            foreach (Event e in Events)
            {
                if (e.Date == data)
                {
                    eventiInData.Add(e);
                }
            }
            return eventiInData;
        }

        public static string ListEvent(List<Event> list)
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
            return Events.Count;
        }

        public void ClearLista()
        {
            Events.Clear();
        }

        public override string ToString()
        {
            string stringList = $"Nome programma evento: {Title}\n";
            foreach (Event e in Events)
            {
                stringList += e.ToString();
            }
            return stringList;
        }

    }
}
