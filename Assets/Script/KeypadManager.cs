using SojaExiles;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class KeypadManager : MonoBehaviour
{
    public TMP_Text passwordScreen;
    public string correctCode = "1234";
    public Animator doorAnimator;
    public float doorStayOpenTime = 10.0f;

    private string currentInput = "";
    private bool IsOpen = false;

    public GameManager gameManager;
    public GameObject GameClearCanvas;

    public AudioSource DooraudioSource;
    public AudioSource BackgroundSource;

    void Start()
    {
        if(BackgroundSource != null) BackgroundSource.Play();
       
        if(GameClearCanvas != null)
        {
            GameClearCanvas.SetActive(false);
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
        if(!IsOpen)
        {
            doorAnimator.SetBool("IsOpen", true);
            IsOpen = true;
            Invoke("CloseDoor", doorStayOpenTime);
        }
        if (DooraudioSource != null)
        {
            DooraudioSource.Play();
        }

        if (GameClearCanvas != null)
        {
            GameClearCanvas.SetActive(true);
        }
        if(BackgroundSource != null)
        {
            BackgroundSource.Stop();
        }

        if(gameManager != null)
        {
            gameManager.timeIsRunning = false;
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

}
