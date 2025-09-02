using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class chessHint : MonoBehaviour
{
    private XRSimpleInteractable interactable;
    public GameObject firstHint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();

        if(firstHint != null )
        {
            firstHint.SetActive( false );
        }
        if(interactable != null )
        {
            interactable.selectEntered.AddListener(OnSelectEntereds);
        }
        
    }


    public void OnSelectEntereds(SelectEnterEventArgs args)
    {
        if(firstHint != null)
        {
            firstHint.SetActive( true );
        }

    }

    public void CloseFirstHint()
    {
        firstHint.SetActive(false );
    }
}
