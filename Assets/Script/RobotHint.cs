using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class RobotHint : MonoBehaviour
{
    private XRSimpleInteractable interactable;
    public GameObject ThirdHint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();

        if (ThirdHint != null)
        {
            ThirdHint.SetActive(false);
        }
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnSelectEntereds);
        }

    }


    public void OnSelectEntereds(SelectEnterEventArgs args)
    {
        if (ThirdHint != null)
        {
            ThirdHint.SetActive(true);
        }

    }

    public void CloseThirdHint()
    {
        ThirdHint.SetActive(false);
    }
}
