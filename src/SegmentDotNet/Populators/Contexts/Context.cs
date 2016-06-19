namespace SegmentDotNet.Populators.Contexts
{
    using System;
    using System.Collections.Generic;

    public class Context : Populator
    {
        public Context(IEnumerable<IContext> contexts)
        {
            this.Contexts = new List<IContext>(contexts);
        }

        protected List<IContext> Contexts { get; set; }

        public override void Prepare()
        {
            this.Contexts.ForEach(c => c.UpdateContext(this.Properties));
        }
    }
}
