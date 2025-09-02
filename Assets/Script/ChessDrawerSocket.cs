using UnityEngine;

public class ChessDrawerSocket : MonoBehaviour
{
    public Animator ChessDrawerAnimator;
    public string targetObjectName = "Chess";
    public string animatorParameterName = "ChessIsOpen";

    private bool isObjectInSocket = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == targetObjectName || other.CompareTag(targetObjectName))
        {
            if (!isObjectInSocket)
            {
                Debug.Log(targetObjectName + "이(가) 소켓에 삽입되었습니다!");
                isObjectInSocket = true;

                if (ChessDrawerAnimator != null)
                {
                    ChessDrawerAnimator.SetBool(animatorParameterName, true);
                }
            }
        }
    }
}
