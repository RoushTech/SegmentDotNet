namespace SegmentDotNet.Populators.Contexts
{
    using System;
    using System.Collections.Generic;

    public class Context : Populator
    {
        public Context(IEnumerable<IContextUpdater> contexts)
        {
            this.Contexts = new List<IContextUpdater>(contexts);
        }

        protected List<IContextUpdater> Contexts { get; set; }

        public override void Prepare()
        {
            this.Contexts.ForEach(c => c.UpdatePopulator(this.Properties));
        }
    }
}
