using UnityEngine;

public class Close : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject letterCanvas;

    public void CloseButtone()
    {
        if(letterCanvas != null)
        {
            letterCanvas.SetActive(false);
        }
    }
}
