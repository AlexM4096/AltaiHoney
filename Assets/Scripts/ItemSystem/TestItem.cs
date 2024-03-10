using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ItemSystem
{
    public class TestItem : MonoBehaviour
    {
        [SerializeField] private ItemSettings itemSettings;

        private List<Item> _items;

        private void Awake()
        {
            _items = new List<Item>();
            
            for (int i = 0; i < 10; i++)
            {
                var item = itemSettings.Get();
                item.transform.position = new Vector3(
                    Random.Range(-5, 5),
                    Random.Range(-5, 5),
                    Random.Range(-5, 5)
                );
                
                _items.Add(item);
            }
        }

        private void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                var item = _items[Random.Range(0, _items.Count)];

                _items.Remove(item);
                itemSettings.Release(item);
            }
        }
    }
}