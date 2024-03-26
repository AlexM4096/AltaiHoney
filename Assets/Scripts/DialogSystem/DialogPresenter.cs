using UnityEngine;
using UnityEngine.UIElements;

namespace DialogSystem
{
    [RequireComponent(typeof(UIDocument))]
    public class DialogPresenter : MonoBehaviour
    {
        [SerializeField] private DialogData dialogData;

        private DialogModel _dialogModel;
        private DialogView _dialogView;

        private void Awake()
        {
            _dialogView = GetComponent<UIDocument>().rootVisualElement.Q<DialogView>();
            _dialogView.Initialize(this);
        }

        public void OnOkButtonClicked()
        {
            
        }
        
        public void OnWhatButtonClicked()
        {
            
        }
    }
}