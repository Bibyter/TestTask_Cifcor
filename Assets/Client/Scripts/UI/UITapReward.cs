using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Client.Scripts.UI
{
    public class UITapReward : MonoBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI _label;

        IntVariable _intVariable;

        private void Awake()
        {
            _intVariable = IntVariable.GetVariable("Tap Reward");
        }

        private void OnEnable()
        {
            _intVariable.onChange += onChange;
        }

        private void OnDisable()
        {
            _intVariable.onChange -= onChange;
        }

        private void onChange()
        {
            _label.text = string.Format("+{0}", _intVariable.value);
        }
    }
}