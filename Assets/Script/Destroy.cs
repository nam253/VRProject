using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject letterCanvas;

    public void DestroyButtone()
    {
        if(letterCanvas != null)
        {
            Destroy(letterCanvas );
        }
    }
}
