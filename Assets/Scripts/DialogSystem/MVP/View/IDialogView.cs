namespace DialogSystem
{
    public interface IDialogView
    {
        void Initialize(IDialogPresenter presenter);
        void DisplayLine(string line);
        void SetButtonTitle(string title);
        void Open();
        void Close();
    }
}