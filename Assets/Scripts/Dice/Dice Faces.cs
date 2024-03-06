using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DiceFaces : MonoBehaviour
{
    [SerializeField] Dice diceScript;
    [SerializeField] int faceValue;
    [SerializeField] bool valSent;

    public static event Action<int> DiceValue= delegate { };

   /* private void OnEnable()
    {
        CustomActions.OnDiceRollStarted += DiceRollStarted;
    }
    private void OnDisable()
    {
        CustomActions.OnDiceRollStarted -= DiceRollStarted;
    }*/
   
    private void OnTriggerStay(Collider other)
    {
        if (valSent || !diceScript.isRolling) return;

        if (diceScript.diceRigidbody.velocity == Vector3.zero)
        {
            DiceValue(7 - faceValue);
            diceScript.isRolling = false;
        }
        
    }

    //Attributes
    public int testValue;      
    [ContextMenu ("Custom Value")]
    public void CustomValue()
    {
        DiceValue(testValue);
    } 
}

