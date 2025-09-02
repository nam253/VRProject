using SojaExiles;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeypadManager : MonoBehaviour
{
    public TMP_Text passwordScreen;
    public string correctCode = "1234";
    public Animator doorAnimator;
    public float doorStayOpenTime = 10.0f;

    private string currentInput = "";
    private bool IsOpen = false;

    public float countdownTime = 60f;
    public string successSceneName = "SuccessScene";
    public string gameOverSceneName = "GameOverScene";

    private bool isGameOver = false;

    void Start()
    {
        // 게임 시작과 동시에 카운트다운을 시작합니다.
        // countdownTime 후에 'GameOver' 메서드를 호출합니다.
        Invoke("GameOver", countdownTime);
    }


    public void RefreshScreen()
    {
        passwordScreen.text = currentInput;
    }

    public void ClearInput()
    {
        currentInput = "";
        RefreshScreen();
    }

    public void AddDigit(string digit)
    {
        if (currentInput.Length < correctCode.Length)
        {
            currentInput += digit;
            RefreshScreen();
        }
    }

    public void VerifyCode()
    {
        if(currentInput == correctCode)
        {
            Debug.Log("Access Grantde!");
            OpenDoor();
            ClearInput();
        }
        else
        {
            Debug.Log("Access Denied!");
            ClearInput();
        }
    }

    public void OpenDoor()
    {
        if(!IsOpen)
        {
            CancelInvoke("GameOver");
            doorAnimator.SetBool("IsOpen", true);
            IsOpen = true;
            Invoke("CloseDoor", doorStayOpenTime);
        }
    }

    public void CloseDoor()
    {
        if(IsOpen)
        {
            doorAnimator.SetBool("IsOpen", false);
            IsOpen = false;
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        Debug.Log("게임 오버! 시간 초과!");

        // 게임 오버 씬으로 전환
        SceneManager.LoadScene(gameOverSceneName);
    }

}
