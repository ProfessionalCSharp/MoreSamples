namespace DynamicTabLib.Framework
{
    public interface IEventAggregator
    {
        T GetEvent<T>()
            where T : EventBase, new();
    }
}
