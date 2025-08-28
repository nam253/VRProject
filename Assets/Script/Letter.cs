using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Letter : MonoBehaviour
{
    private XRSimpleInteractable interactable;
    public GameObject LetterCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();

        if (LetterCanvas != null)
        {
            LetterCanvas.SetActive(false);
        }

        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnSelectEntereds);
        }

    }


    public void OnSelectEntereds(SelectEnterEventArgs args)
    {
        if(LetterCanvas != null)
        {
            LetterCanvas.SetActive(true);
        }

        if (interactable != null)
        {
            interactable.enabled = false;
        }
    }

}
