using System.Collections.Generic;
using System.Linq;
using OrderSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace DialogSystem
{
    [RequireComponent(typeof(UIDocument))]
    public class DialogPresenter : MonoBehaviour, IDialogPresenter
    {
        private IDialogModel _model;
        private IDialogView _view;

        private IEnumerator<string> _dialogLines;
        private IEnumerator<string> _orderLines;

        private bool _dialogEnded;
        
        private void Awake()
        {
            _view = GetComponent<UIDocument>().rootVisualElement.Q<DialogView>();
            _view.Initialize(this);

            var model = new DialogModel();
            model.Dialog.Value = Resources.Load<DialogAsset>("Dialogs/Test_Dialog");
            
            Initialize(model);
        }
        
        public void Initialize(IDialogModel model)
        {
            _model = model;
            
            OnDialogChange(_model.Dialog.Value);
        }

        private void OnEnable()
        {
            _model.Dialog.OnChanged += OnDialogChange;
        }

        private void OnDisable()
        {
            _model.Dialog.OnChanged -= OnDialogChange;
        }

        private void OnDialogChange(IDialog dialog)
        {
            _dialogLines = dialog.Lines.GetEnumerator();
            
            _orderLines = dialog.OrderDialog.Order.Items.Select(x => x.ToString()).GetEnumerator();

            _dialogEnded = false;
        }

        public void OnButtonClicked()
        {
            if (_dialogLines.MoveNext())
            {
                _view.DisplayLine(_dialogLines.Current);
                _view.SetButtonTitle("Далее");
            }
            else if (_orderLines.MoveNext())
            {
                _view.DisplayLine(_orderLines.Current);
                _view.SetButtonTitle("Что-то ещё?");
            }
            else if (!_dialogEnded)
            {
                _view.DisplayLine("Нет пожалуй");
                _view.SetButtonTitle("Хорошо");
                
                _dialogEnded = true;
            }
            else
            {
                _view.Close();
            }
        }
    }
}