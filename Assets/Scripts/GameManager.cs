using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public GameObject[] moles;
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI timeText;
    public Button restartBtn;
    public Button mainMenuBtn;

    float showDelay = 0.50f;
    float gameTime = 30f;
    float maxGameTime = 30f;

    int gameScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < moles.Length; i++) { moles[i].SetActive(false); }
        restartBtn.gameObject.SetActive(false);
        mainMenuBtn.gameObject.SetActive(false);
        StartCoroutine(HideAndShow());
    }

    IEnumerator HideAndShow() 
    {
        yield return new WaitForSeconds(showDelay);

        int rndShowCnt = UnityEngine.Random.Range(0, moles.Length);
        for (int i = 0; i < moles.Length; i++) 
        {
            if (rndShowCnt == i) 
            {
                moles[i].SetActive(true);
            }
            
        }

        yield return new WaitForSeconds(showDelay + 0.15f);

        int rndShowCnt2 = UnityEngine.Random.Range(0, moles.Length);
        for (int i = 0; i < moles.Length; i++)
        {
            if (rndShowCnt2 == i)
            {
                moles[i].SetActive(true);
            }

        }

        yield return new WaitForSeconds(showDelay + 0.25f);

        for (int i = 0; i < moles.Length; i++) 
        {             
            moles[i].GetComponent<MoleScript>().resetMole();
            moles[i].SetActive(false);
        }
        showDelay = UnityEngine.Random.Range(0.30f, 1.0f);
        StartCoroutine(HideAndShow());
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTime <= 0)
        {
            StopAllCoroutines();
            timeText.text = "Time: 0";
            restartBtn.gameObject.SetActive(true);
            mainMenuBtn.gameObject.SetActive(true);
            for (int i = 0; i < moles.Length; i++) { moles[i].SetActive(false); }
        }
        else
        {
            gameTime -= Time.deltaTime;
            int seconds = Convert.ToInt32(gameTime % 60);
            string timeStr = seconds.ToString();
            timeText.text = "Time: " + timeStr;
        }
        
    }
    /// <summary>
    /// Button Presses! 
    /// </summary>
    public void _OnClickedMole() 
    {
        gameScore++;
        scoreText.text = "Score: " + gameScore;
    }
    public void _OnClickedResetGame()
    {
        SceneManager.LoadScene(1);
    }
    public void _OnClickedMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}///LAST BRACKET DON'T GO PAST THIS!
