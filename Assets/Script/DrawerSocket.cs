using UnityEngine;

public class DrawerSocket : MonoBehaviour
{
    public Animator drawerAnimator;
    public string targetObjectName = "Wine";
    public string animatorParameterName = "IsOpenDrawer";
    public AudioSource AudioSource;

    private bool isObjectInSocket = false;


    private void OnTriggerEnter(Collider other)
    {
        if(other.name == targetObjectName || other.CompareTag(targetObjectName))
        {
            if(!isObjectInSocket)
            {
                Debug.Log(targetObjectName + "��(��) ���Ͽ� ���ԵǾ����ϴ�!");
                isObjectInSocket = true;

                if(drawerAnimator != null)
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
