namespace LibraryNotifier.Core.Commands
{
    public interface ICommand<in TIn, out TOut>
    {
        TOut Execute(TIn request);
    }
}