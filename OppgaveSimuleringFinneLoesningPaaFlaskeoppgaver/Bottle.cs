using System;

namespace OppgaveSimuleringFinneLoesningPaaFlaskeoppgaver
{
    internal class Bottle
    {
        public int Capacity { get; }
        public int Content { get; private set; }

        public Bottle(int capacity)
        {
            Capacity = capacity;
        }

        internal int Empty()
        {
            var contentToEmptyOut = Content;
            Content = 0;
            return contentToEmptyOut;
        }

        internal void Fill(int otherBottleContent)
        {
            Content = (Content + otherBottleContent) > Capacity ? Capacity : (Content + otherBottleContent);
        }

        internal void FillToTop(Bottle otherBottle)
        {
            var emptySpace = Capacity - Content;
            var realFillVolume = Math.Min(emptySpace, otherBottle.Content);
            Content += realFillVolume;
            otherBottle.Content -= realFillVolume;
        }
        internal void FillToTopFromTap()
        {
            Content = Capacity;
        }
    }
}