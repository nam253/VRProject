using UnityEngine;

public class SecondDrawerSocket : MonoBehaviour
{
    public Animator drawerAnimator;
    public string targetObjectName = "statue";
    public string animatorParameterName = "StatueIsOpen";

    private bool isObjectInSocket = false;

    public AudioSource AudioSource;


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == targetObjectName || other.CompareTag(targetObjectName))
        {
            if (!isObjectInSocket)
            {
                Debug.Log(targetObjectName + "이(가) 소켓에 삽입되었습니다!");
                isObjectInSocket = true;

                if (drawerAnimator != null)
                {
                    drawerAnimator.SetBool(animatorParameterName, true);
                }
                if(AudioSource != null)
                {
                    AudioSource.Play();
                }
            }
        }
    }
}
