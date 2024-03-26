namespace DialogSystem
{
    public interface IDialogPresenter
    {
        void Initialize(IDialogModel model);
        void OnButtonClicked();
    }
}