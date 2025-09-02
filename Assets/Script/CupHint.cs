using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class CupHint : MonoBehaviour
{
    private XRSimpleInteractable interactable;
    public GameObject LastHint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();

        if (LastHint != null)
        {
            LastHint.SetActive(false);
        }
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnSelectEntereds);
        }

    }


    public void OnSelectEntereds(SelectEnterEventArgs args)
    {
        if (LastHint != null)
        {
            LastHint.SetActive(true);
        }

    }

    public void CloseLast()
    {
        LastHint.SetActive(false);
    }
}
