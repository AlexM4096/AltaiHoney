using System;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] private State currentState;
        
        private readonly Dictionary<Type, Component> _cachedComponents = new();
        
        public void SwitchState(State newState)
        {
            currentState.Exit(this);
            currentState = newState;
            currentState.Enter(this);
        }

        private void Update()
        {
            currentState.LogicUpdate(this);
        }
        
        public new T GetComponent<T>() where T : Component
        {
            if(_cachedComponents.ContainsKey(typeof(T)))
                return _cachedComponents[typeof(T)] as T;
            
            var component = base.GetComponent<T>();
            if(component != null)
                _cachedComponents.Add(typeof(T), component);

            return component;
        }
    }
}