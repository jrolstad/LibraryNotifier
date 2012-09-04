namespace LibraryNotifier.Core.Factories
{
    public interface IFactory<in TIn, out TOut>
    {
        TOut Create(TIn request);
    }
}