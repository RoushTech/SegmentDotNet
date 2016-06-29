namespace SegmentDotNet.Populators
{
    using System.Collections.Generic;

    public interface IPopulatorUpdater
    {
        void UpdatePopulator(IDictionary<string, object> properties);
    }
}
