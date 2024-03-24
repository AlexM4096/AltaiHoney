using FSM;
using ItemSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace HoneyExtractor
{
    [CreateAssetMenu(menuName = "FSM/Create SpawnItemAction")]
    public class SpawnItemAction : Action
    {
        [FormerlySerializedAs("itemSettingses")] [SerializeField] private ItemSettings itemSettings;
        
        public override void Execute(StateMachine stateMachine)
        {
            var dictionary = stateMachine.GetComponent<Extacrtor>().Dictionary;

            if (dictionary.TryGetValue(itemSettings, out var transform))
            {
                var item = itemSettings.Get();
                item.transform.position = transform.position;
            }
        }
    }
}