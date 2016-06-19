namespace SegmentDotNet.Populators
{
    using PropertyContainers.Abstract;

    public abstract class Populator : PropertyContainerBase
    {
        public abstract void Prepare();
    }
}
