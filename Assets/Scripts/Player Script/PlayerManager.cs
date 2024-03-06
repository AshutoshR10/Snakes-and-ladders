using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{
    public int playerCurrentIndex = 0;
    public PlayerState playerstate;

    private void OnEnable()
    {
        DiceFaces.DiceValue += DiceFaces_DiceValue;
    }
    private void OnDisable()
    {
        DiceFaces.DiceValue -= DiceFaces_DiceValue;
    }

    private void Start()
    {
        this.transform.position = GameManager.Instance.playerPaths[playerCurrentIndex].transform.position;
    }

    private void DiceFaces_DiceValue(int diceValue)
    {
        Debug.Log(diceValue);
        if (playerstate == PlayerState.Initial)
        {
            if (diceValue == 1 || diceValue == 6)
            {
                playerstate = PlayerState.OnBoard;
                StartCoroutine(PlayerMove(diceValue));
            }          
        }
        else if (playerstate == PlayerState.OnBoard)
        {
            if (diceValue <= 100 - playerCurrentIndex)
            {
                StartCoroutine(PlayerMove(diceValue));
                
            }
        }                
    }
   
    public IEnumerator PlayerMove(int dicevalue)
    {
        //playerCurrentIndex += diceValue; 
       
        while (dicevalue > 0)
        {
            playerCurrentIndex++;
            this.transform.position = GameManager.Instance.playerPaths[playerCurrentIndex].transform.position;
            yield return new WaitForSeconds(0.5f);
            dicevalue--;
        }
        PathType currentPathType = GameManager.Instance.playerPaths[playerCurrentIndex].pathType;

        if (currentPathType == PathType.LadderStart || currentPathType == PathType.SnakeStart)
        {
            this.transform.position = GameManager.Instance.playerPaths[playerCurrentIndex].endTranform.transform.position;
            playerCurrentIndex = GameManager.Instance.playerPaths.FindIndex(x => x == GameManager.Instance.playerPaths[playerCurrentIndex].endTranform);

        }
    }
}
