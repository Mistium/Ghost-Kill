using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        StartCoroutine(BattleSystem.Instance.Attack(-1));
    }
}
