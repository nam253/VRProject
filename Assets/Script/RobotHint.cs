using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class RobotHint : MonoBehaviour
{
    private XRSimpleInteractable interactable;
    public GameObject thirdHint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();

        if (thirdHint != null)
        {
            thirdHint.SetActive(false);
        }
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnSelectEntereds);
        }

    }


    public void OnSelectEntereds(SelectEnterEventArgs args)
    {
        if (thirdHint != null)
        {
            thirdHint.SetActive(true);
        }

    }

    public void CloseThirdHint()
    {
        thirdHint.SetActive(false);
    }
}
