using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] internal Rigidbody diceRigidbody;

    [SerializeField] float minThrowForceValue;
    [SerializeField] float maxThrowForceValue;
    [SerializeField] float minRollForceValue;
    [SerializeField] float maxRollForceValue;
    [SerializeField] internal bool isRolling;
    [SerializeField] Vector3 appliedForce;

    public void RollDice()
    {
        if (isRolling) return;

        
        //diceRigidbody.isKinematic = true;
        //transform.position = spawnPos;

        //CustomActions.OnDiceRollStarted?.Invoke();
        isRolling = true;
        //diceRigidbody.isKinematic = false;

        appliedForce.x = Random.Range(minRollForceValue, maxRollForceValue);
        appliedForce.y = Random.Range(minRollForceValue, maxRollForceValue);
        appliedForce.z = Random.Range(minRollForceValue, maxRollForceValue);

        diceRigidbody.AddForce(Vector3.up * Random.Range(minThrowForceValue, maxThrowForceValue));
        diceRigidbody.AddTorque(appliedForce);
    }


}
