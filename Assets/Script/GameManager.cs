using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverCanvas;
    public TextMeshProUGUI timeText;

    public float timeRemining = 30 * 60;
    public bool timeIsRunning = false;

    public KeypadManager keypadManager;

    public AudioSource BackroundSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeIsRunning = true;

        if(GameOverCanvas != null)
        {
            GameOverCanvas.SetActive(false);
        }

        if(keypadManager != null)
        {
            keypadManager.gameManager = this;  // 이제 KeypadManager가 GameManager를 참조
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeIsRunning)
        {
            if(timeRemining > 0)
            {
                timeRemining -= Time.deltaTime;
                DisplayTime(timeRemining);
                
            }
            else
            {
                timeRemining = 0;
                timeIsRunning=false;

                if(GameOverCanvas != null)
                {
                    GameOverCanvas.SetActive(true);
                }
                if(BackroundSource != null)
                {
                    BackroundSource.Stop();
                }
            }
        }
        
    }

    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00} :{1:00}", minutes, seconds);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
