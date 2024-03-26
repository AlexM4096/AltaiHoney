using UnityEngine;
using UnityEngine.UIElements;

namespace DialogSystem
{
    public class DialogView : VisualElement
    {
        private const string AssetPath = "Views/DialogViewAsset";

        private const string OkButton = "OkButton";
        private const string WhatButton = "WhatButton";

        private readonly Label _label;
        
        private readonly Button _okButton;
        private readonly Button _whatButton;

        private DialogPresenter _presenter;

        public DialogView()
        {
            var visualTree = Resources.Load<VisualTreeAsset>(AssetPath).CloneTree();
            Add(visualTree);

            _label = visualTree.Q<Label>();
            
            _okButton = visualTree.Q<Button>(OkButton);
            _whatButton = visualTree.Q<Button>(WhatButton);
        }

        public void Initialize(DialogPresenter presenter)
        {
            _presenter = presenter;
            
            _okButton.clicked += _presenter.OnOkButtonClicked;
            _whatButton.clicked += _presenter.OnWhatButtonClicked;
        }

        public void DisplayLine(string line) => _label.text = line;

        public void SetOkButtonTitle(string title) => _okButton.text = title;
        
        public void SetWhatButtonTitle(string title) => _whatButton.text = title;

        #region UXML

        public new class UxmlFactory : UxmlFactory<DialogView, UxmlTraits> {}

        public new class UxmlTraits : VisualElement.UxmlTraits {}

        #endregion
    }
}