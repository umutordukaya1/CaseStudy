using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager = default;
    void Initiliazed()
    {
        Magnetic.CubeEntered += HandleLevel;
        AiMagnetic.aiCubeEntered += AiHandLevel;

    }
  
    void Awake()
    {
        Initiliazed();
    }
    public void HandleLevel()
    {
        gameManager.currentCubeCount++;
        //gameManager.LevelCompleted();

    }
    public void AiHandLevel()
    {
        gameManager.AIcurrentCubeCount++;
    }
}
