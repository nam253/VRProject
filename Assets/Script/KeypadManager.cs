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
        // ���� ���۰� ���ÿ� ī��Ʈ�ٿ��� �����մϴ�.
        // countdownTime �Ŀ� 'GameOver' �޼��带 ȣ���մϴ�.
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
        Debug.Log("���� ����! �ð� �ʰ�!");

        // ���� ���� ������ ��ȯ
        SceneManager.LoadScene(gameOverSceneName);
    }

}
