namespace SegmentDotNet.Tests.Populators.Contexts
{
    using SegmentDotNet.Populators.Contexts;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using Xunit;

    public class LibraryTests
    {
        [Fact]
        public void PopulatesDictionary()
        {
            var library = new Library();
            var dictionary = new Dictionary<string, object>();
            library.UpdatePopulator(dictionary);
            var version = FileVersionInfo.GetVersionInfo(typeof(Library).GetTypeInfo().Assembly.Location).ProductVersion;
            Assert.Equal("SegmentDotNet", dictionary["library.name"]);
            Assert.Equal(version, dictionary["library.version"]);
        }
    }
}
