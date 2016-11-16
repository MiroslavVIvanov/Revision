namespace FormattingCode
{
    using System;
    using Wintellect.PowerCollections;

    public class EventHolder
    {
        private MultiDictionary<string, Event> storedByTitle = 
            new MultiDictionary<string, Event>(true);

        private OrderedBag<Event> sortedByDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);

            this.storedByTitle.Add(title.ToLower(), newEvent);
            this.sortedByDate.Add(newEvent);
            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;
            foreach (var eventToRemove in this.storedByTitle[title])
            {
                removed++;
                this.sortedByDate.Remove(eventToRemove);
            }

            this.storedByTitle.Remove(title);
            Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = 
                this.sortedByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);

            foreach (var eventToShow in eventsToShow)
            {
                Messages.PrintEvent(eventToShow);
            }

            if (eventsToShow.Count == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
}
