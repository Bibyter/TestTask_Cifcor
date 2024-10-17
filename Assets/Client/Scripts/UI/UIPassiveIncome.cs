using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Client.Scripts.UI
{
    public class UIPassiveIncome : MonoBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI _label;

        [SerializeField] IntVariable _passiveIncomeReward;
        [SerializeField] IntVariable _passiveIncomePeriod;

        private void Awake()
        {
            _passiveIncomeReward = IntVariable.GetVariable("Passive Income Reward");
            _passiveIncomePeriod = IntVariable.GetVariable("Passive Income Period");
        }

        private void Start()
        {
            UpdateContent();
            _passiveIncomeReward.onChange += UpdateContent;
        }

        private void OnDestroy()
        {
            _passiveIncomeReward.onChange -= UpdateContent;
        }

        private void UpdateContent()
        {
            _label.text = string.Format("+{0} / {1} SEC", _passiveIncomeReward.value, _passiveIncomePeriod.value);
        }
    }
}