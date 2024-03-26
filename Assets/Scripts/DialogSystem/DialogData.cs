using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    [CreateAssetMenu(menuName = "Dialog System/Create dialog")]
    public class DialogData : ScriptableObject
    {
        [SerializeField] private List<string> lines;
        public IReadOnlyList<string> Lines => lines;
    }
}