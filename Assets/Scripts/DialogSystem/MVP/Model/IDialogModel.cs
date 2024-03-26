namespace DialogSystem
{
    public interface IDialogModel
    {
        public ReactiveProperty<IDialog> Dialog { get; }
    }
}