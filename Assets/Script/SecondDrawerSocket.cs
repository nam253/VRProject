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
                Debug.Log(targetObjectName + "��(��) ���Ͽ� ���ԵǾ����ϴ�!");
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
