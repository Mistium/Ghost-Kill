using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        if (BattleSystem.Instance.turn == 0)
        {
            StartCoroutine(BattleSystem.Instance.Attack(1));
        }
    }
}
