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
        // ���� ������ �ƴ� ���� �ð��� ������Ʈ�մϴ�.
        if (!isGameOver)
        {
            countdownTime -= Time.deltaTime;
            // ���� �ð��� ������ ��ȯ�Ͽ� �ؽ�Ʈ�� ǥ���մϴ�.
            countdownText.text = Mathf.Round(countdownTime).ToString();

            // �ð��� 0���� �۾����� GameOver()�� ȣ���մϴ�.
            // Invoke�� ����ϰ� ������ ���� üũ������ �߰��ϸ� �����ϴ�.
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
        Debug.Log("���� ����! �ð� �ʰ�!");

       if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }
    }

}
