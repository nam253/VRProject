using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class statueHint : MonoBehaviour
{
    private XRSimpleInteractable interactable;
    public GameObject secondHint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();

        if (secondHint != null)
        {
            secondHint.SetActive(false);
        }
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnSelectEntereds);
        }

    }


    public void OnSelectEntereds(SelectEnterEventArgs args)
    {
        if (secondHint != null)
        {
            secondHint.SetActive(true);
        }

    }

    public void CloseSecondHint()
    {
        secondHint.SetActive(false);
    }
}
