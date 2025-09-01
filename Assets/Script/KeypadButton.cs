using UnityEngine;

public class KeypadButton : MonoBehaviour
{
    public KeypadManager keypad;
    public string buttonVal;

    public void OnPressButton()
    {
        if(buttonVal == "Enter")
        {
            keypad.VerifyCode();
        }
        else
        {
            keypad.AddDigit(buttonVal);
        }
    }
}
