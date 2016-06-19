namespace SegmentDotNet.Populators.Contexts
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;

    public class Library : IContextUpdater
    {
        public void UpdatePopulator(IDictionary<string, object> properties)
        {
            properties.Add("library.name", "SegmentDotNet");
            properties.Add("library.version", FileVersionInfo.GetVersionInfo(typeof(Library).GetTypeInfo().Assembly.Location).ProductVersion);
        }
    }
}
