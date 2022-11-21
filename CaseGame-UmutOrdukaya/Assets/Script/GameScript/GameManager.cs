using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int currentCubeCount;
    public int AIcurrentCubeCount;
    public Text
        sayac,
        aiText;
    
    [Header("Timer")]
    public bool timerOn = false;
    public float TimeLeft;
    float oldTime;
    public Text TimerText;
    [Header("Levels")]
    public GameObject finishPanel;
    public int levelIndex;
    int oldLevelIndex;
    public List<GameObject> levelList;


    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        timerOn = true;
        oldTime = TimeLeft; 
    }
    void Update()
    {
        sayac.text = currentCubeCount.ToString();
        aiText.text = AIcurrentCubeCount.ToString();
        
        Timer();
    }


    public void NextLevel()
    {
        levelList[oldLevelIndex].SetActive(false);
        if (levelIndex < levelList.Count - 1)
        {
            levelIndex++;
        }

    }
    public void LevelCompleted()
    {
        TimeLeft = oldTime;
        timerOn = true;
        oldLevelIndex = levelIndex;
        NextLevel();
        currentCubeCount = 0;
        sayac.text = currentCubeCount.ToString();
        AIcurrentCubeCount = 0;
        aiText.text = currentCubeCount.ToString();
        levelList[levelIndex].SetActive(true);
        aiText.transform.gameObject.SetActive(true);
    }

    public void Timer()
    {
        if (timerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                TimeLeft = 0;
                timerOn = false;
                finishPanel.SetActive(true);
            }

        }
    }
    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        TimerText.text = string.Format("{0:00} : {1:00} ", minutes, seconds);
    }
}
