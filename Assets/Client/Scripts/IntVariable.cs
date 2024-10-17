using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Client.Scripts
{
    [DefaultExecutionOrder(-100)]
    public class IntVariable : MonoBehaviour
    {
        [SerializeField] int _initValue = 0;
        [SerializeField] bool _debugPrintChange;

        int _value;
        public int value 
        { 
            set 
            {
                if (_debugPrintChange)
                {
                    Debug.Log(string.Format("Change Variable {0}", name));
                }

                _value  = value;
                onChange?.Invoke();
            }
            get => _value;
        }


        public event System.Action onChange;

        public void Add(int amount)
        {
            value += amount;
        }


        static List<IntVariable> _variables = new List<IntVariable>();

        private void OnEnable()
        {
            _value = _initValue;
            _variables.Add(this);
        }

        private void OnDisable()
        {
            _variables.Remove(this);
        }

        public static IntVariable GetVariable(string name)
        {
            var v =  _variables.Find((x) => x.name == name);

            if (v == null)
            {
                Debug.LogError(string.Format("Variable {0} not found!", name));
            }

            return v;
        }
    }
}