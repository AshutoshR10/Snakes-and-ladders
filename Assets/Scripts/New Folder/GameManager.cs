using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<PathEntity> playerPaths = new List<PathEntity>();
    
    private void Awake()
    {
        Instance = this;
    }
}
