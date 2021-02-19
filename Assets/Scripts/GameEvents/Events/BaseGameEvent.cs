using System.Collections.Generic;
using UnityEngine;

namespace GameEvents
{
    public abstract class BaseGameEvent<T> : ScriptableObject
    {
        private readonly List<IGameEventListener<T>> _Listeners = new List<IGameEventListener<T>>();

        public void Raise(T item)
        {
            for (int i = _Listeners.Count - 1; i >= 0; i--)
            {
                _Listeners[i].OnEventRaised(item);
            }
        }

        public void RegisterListener(IGameEventListener<T> listener)
        {
            if (!_Listeners.Contains(listener))
                _Listeners.Add(listener);
        }
    
        public void UnregisterListener(IGameEventListener<T> listener)
        {
            if (_Listeners.Contains(listener))
                _Listeners.Remove(listener);
        }
    }
}