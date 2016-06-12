namespace SegmentDotNet.Abstractions
{
    using System;

    public interface IDateTime
    {
        DateTime UtcNow { get; }
    }
}
