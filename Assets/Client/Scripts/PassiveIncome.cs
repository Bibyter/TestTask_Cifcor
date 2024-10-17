using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Client.Scripts
{
    public class PassiveIncome : MonoBehaviour
    {
        [SerializeField] IntVariable _passiveIncomePeriod;
        [SerializeField] IntVariable _passiveIncomeReward;

        IEnumerator Start()
        {
            var money = IntVariable.GetVariable("Money");

            while (true)
            {
                yield return new WaitForSeconds(_passiveIncomePeriod.value);
                money.Add(_passiveIncomeReward.value);
            }
        }
    }
}