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

        public void AddEvent(Event ev)
        {
            Events.Add(ev);
        }

        public List<Event> FilterData(DateTime date)
        {
            return (List<Event>)Events.Where(x => x.Date == date);
        }

        public static string ListEvent(List<Event> list)
        {
            string stringList = "";
            foreach (Event ev in list)
            {
                stringList += ev.ToString();
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
            string stringList = Title + "\n";
            foreach (Event ev in Events)
            {
                stringList += ev.ToString();
            }
            return stringList;
        }

    }
}
