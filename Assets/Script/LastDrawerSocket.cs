using UnityEngine;

public class LastDrawerSocket : MonoBehaviour
{
    public Animator drawerAnimator;
    public string targetObjectName = "Robot";
    public string animatorParameterName = "LastIsOpen";

    private bool isObjectInSocket = false;


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
            }
        }
    }
}
