using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Letter : MonoBehaviour
{
    private XRGrabInteractable interactable;
    public GameObject LatterCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();

        if(LatterCanvas != null)
        {
            LatterCanvas.SetActive(false);
        }

    }

    public void SelectEvent()
    {
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnSelectEntereds);
        }
    }

    public void OnSelectEntereds(SelectEnterEventArgs args)
    {
        if(LatterCanvas != null)
        {
            LatterCanvas.SetActive(true);
        }
    }

}
