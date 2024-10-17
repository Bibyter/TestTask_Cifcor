using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Client.Scripts.UI
{
    public class UIMoney : MonoBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI _label;

        IntVariable _money;
        int _cacheValue;


        private void Awake()
        {
            _money = IntVariable.GetVariable("Money");
        }

        private void OnEnable()
        {
            SetText(_money.value);
            _cacheValue = _money.value;

            _money.onChange += _money_onChange;
        }

        private void OnDisable()
        {
            _money.onChange -= _money_onChange;
        }

        private void _money_onChange()
        {
            StopAllCoroutines();
            StartCoroutine(CounterCoroutine(_cacheValue, _money.value));
            _cacheValue = _money.value;
        }

        IEnumerator CounterCoroutine(float from, float to, float duration = 0.7f)
        {
            float t = 0;
            while (t < 1f)
            {
                t += Time.unscaledDeltaTime / duration;
                _cacheValue = Mathf.RoundToInt(Mathf.Lerp(from, to, t));
                SetText(_cacheValue);
                yield return null;
            }
        }

        private void SetText(int value)
        {
            var nfi = new System.Globalization.NumberFormatInfo { NumberGroupSeparator = " ", NumberDecimalDigits = 0 };
            _label.text = value.ToString("n", nfi);
        }
    }
}