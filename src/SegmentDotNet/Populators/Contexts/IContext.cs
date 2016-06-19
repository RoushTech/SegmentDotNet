namespace SegmentDotNet.Populators.Contexts
{
    using System.Collections.Generic;

    public interface IContext
    {
        void UpdateContext(Dictionary<string, object> context);
    }
}
