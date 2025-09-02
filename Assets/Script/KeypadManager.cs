using SojaExiles;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeypadManager : MonoBehaviour
{
    public TMP_Text passwordScreen;
    public string correctCode = "1234";
    public Animator doorAnimator;
   // public float doorStayOpenTime = 10.0f;

    private string currentInput = "";
    private bool IsOpen = false;

    public float countdownTime = 60f;
    public GameObject successCanvas;
    public GameObject gameOverCanvas;

    public TMP_Text countdownText;


    private bool isGameOver = false;

    void Start()
    {
        
        Invoke("GameOver", countdownTime);

        if (successCanvas != null) successCanvas.SetActive(false);
        if (gameOverCanvas != null) gameOverCanvas.SetActive(false);
    }

    void Update()
    {
        // 게임 오버가 아닐 때만 시간을 업데이트합니다.
        if (!isGameOver)
        {
            countdownTime -= Time.deltaTime;
            // 남은 시간을 정수로 변환하여 텍스트에 표시합니다.
            countdownText.text = Mathf.Round(countdownTime).ToString();

            // 시간이 0보다 작아지면 GameOver()를 호출합니다.
            // Invoke를 사용하고 있지만 이중 체크용으로 추가하면 좋습니다.
            if (countdownTime <= 0)
            {
                GameOver();
            }
        }
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
        if(isGameOver)
        {
            return;
        }

        if(!IsOpen)
        {
            CancelInvoke("GameOver");
            doorAnimator.SetBool("IsOpen", true);
            IsOpen = true;

            if(successCanvas != null)
            {
                successCanvas.SetActive(true);
            }
            //Invoke("CloseDoor", doorStayOpenTime);
        }
    }

    /*public void CloseDoor()
    {
        if(IsOpen)
        {
            doorAnimator.SetBool("IsOpen", false);
            IsOpen = false;
        }
    }*/

    private void GameOver()
    {
        isGameOver = true;
        Debug.Log("게임 오버! 시간 초과!");

       if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }
    }

}
