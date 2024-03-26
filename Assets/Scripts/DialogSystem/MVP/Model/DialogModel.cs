namespace DialogSystem
{
    public class DialogModel : IDialogModel
    {
        public ReactiveProperty<IDialog> Dialog { get; } = new();
    }
}