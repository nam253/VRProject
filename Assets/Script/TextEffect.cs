using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextEffect : MonoBehaviour
{
    public TextMeshProUGUI Storytext;

    public string fullText;

    public float letterDelay = 1.0f;

    public float sceneTransitionDelay = 1.0f;

    public AudioSource audioSource;

    public AudioClip textClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ShowTextAndTransition());
        
    }

    IEnumerator ShowTextAndTransition()
    {
        Storytext.text = "";

        for (int i = 0; i < fullText.Length; i++)
        {
            Storytext.text += fullText[i];

            audioSource.PlayOneShot(textClip);

            yield return new WaitForSeconds(letterDelay);
        }

        yield return new WaitForSeconds(sceneTransitionDelay);

        SceneManager.LoadScene("Scene_02");

    }
}
