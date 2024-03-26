using UnityEngine;
using UnityEngine.UIElements;

namespace DialogSystem
{
    public class DialogView : VisualElement, IDialogView
    {
        private const string AssetPath = "Views/DialogViewAsset";
        private const string Button = "OkButton";

        private readonly Label _label;
        private readonly Button _button;

        private IDialogPresenter _presenter;

        public DialogView()
        {
            var visualTree = Resources.Load<VisualTreeAsset>(AssetPath).CloneTree();
            Add(visualTree);

            _label = visualTree.Q<Label>();
            _button = visualTree.Q<Button>(Button);
        }

        public void Initialize(IDialogPresenter presenter)
        {
            _presenter = presenter;
            _button.clicked += _presenter.OnButtonClicked;
        }

        public void DisplayLine(string line) => _label.text = line;
        public void SetButtonTitle(string title) => _button.text = title;

        public void Open() => this.Show();
        public void Close() => this.Hide();

        #region UXML

        public new class UxmlFactory : UxmlFactory<DialogView, UxmlTraits> {}

        public new class UxmlTraits : VisualElement.UxmlTraits {}

        #endregion
    }
}