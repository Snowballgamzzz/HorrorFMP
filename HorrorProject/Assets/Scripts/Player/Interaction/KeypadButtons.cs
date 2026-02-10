using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class KeypadButtons : MonoBehaviour
{
    public enum ButtonType
    { 
        ButtonClear,
        ButtonDelete,
        ButtonEnter,
        ButtonOne,
        ButtonTwo,
        ButtonThree,
        ButtonFour,
        ButtonFive,
        ButtonSix,
        ButtonSeven,
        ButtonEight,
        ButtonNine,
        ButtonZero
    }

    public ButtonType type;

    Interaction interact;

    public GameObject playerCam;

    private bool isButtonClear;
    private bool isButtonDelete;
    private bool isButtonEnter;
    private bool isButtonOne;
    private bool isButtonTwo;
    private bool isButtonThree;
    private bool isButtonFour;
    private bool isButtonFive;
    private bool isButtonSix;
    private bool isButtonSeven;
    private bool isButtonEight;
    private bool isButtonNine;
    private bool isButtonZero;

    void Start()
    {
        interact = playerCam.GetComponent<Interaction>();
    }

    private void OnMouseOver()
    {
        if (type == ButtonType.ButtonClear)
        {
            isButtonClear = true;
        }
        else if (type == ButtonType.ButtonDelete)
        {
            isButtonDelete = true;
        }
        else if (type == ButtonType.ButtonEnter)
        {
            isButtonEnter = true;
        }
        else if (type == ButtonType.ButtonOne)
        {
            isButtonOne = true;
        }
        else if (type == ButtonType.ButtonTwo)
        {
            isButtonTwo = true;
        }
        else if (type == ButtonType.ButtonThree)
        {
            isButtonThree = true;
        }
        else if (type == ButtonType.ButtonFour)
        {
            isButtonFour = true;
        }
        else if (type == ButtonType.ButtonFive)
        {
            isButtonFive = true;
        }
        else if (type == ButtonType.ButtonSix)
        {
            isButtonSix = true;
        }
        else if (type == ButtonType.ButtonSeven)
        {
            isButtonSeven = true;
        }
        else if (type == ButtonType.ButtonEight)
        {
            isButtonEight = true;
        }
        else if (type == ButtonType.ButtonNine)
        {
            isButtonNine = true;
        }
        else if (type == ButtonType.ButtonZero)
        {
            isButtonZero = true;
        }
    }

    public void ToggleButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isButtonClear && !interact.correctCode)
            {
                interact.clearEvent();
                interact.textAmount = 0;
                interact.playerInteraction = true;
                isButtonClear = false;
            }
            else if (isButtonDelete && !interact.correctCode)
            {
                interact.deleteEvent();
                interact.textAmount -= 1;
                isButtonDelete = false;
            }
            else if (isButtonEnter && !interact.correctCode)
            {
                interact.enterEvent();
                isButtonEnter = false;
            }
            else if (isButtonOne && !interact.correctCode)
            {
                interact.b1();
                interact.textAmount += 1;
                isButtonOne = false;
            }
            else if (isButtonTwo && !interact.correctCode)
            {
                interact.b2();
                interact.textAmount += 1;
                isButtonTwo = false;
            }
            else if (isButtonThree && !interact.correctCode)
            {
                interact.b3();
                interact.textAmount += 1;
                isButtonThree = false;
            }
            else if (isButtonFour && !interact.correctCode)
            {
                interact.b4();
                interact.textAmount += 1;
                isButtonFour = false;
            }
            else if (isButtonFive && !interact.correctCode)
            {
                interact.b5();
                interact.textAmount += 1;
                isButtonFive = false;
            }
            else if (isButtonSix && !interact.correctCode)
            {
                interact.b6();
                interact.textAmount += 1;
                isButtonSix = false;
            }
            else if (isButtonSeven && !interact.correctCode)
            {
                interact.b7();
                interact.textAmount += 1;
                isButtonSeven = false;
            }
            else if (isButtonEight && !interact.correctCode)
            {
                interact.b8();
                interact.textAmount += 1;
                isButtonEight = false;
            }
            else if (isButtonNine && !interact.correctCode)
            {
                interact.b9();
                interact.textAmount += 1;
                isButtonNine = false;
            }
            else if (isButtonZero && !interact.correctCode)
            {
                interact.b0();
                interact.textAmount += 1;
                isButtonZero = false;
            }
        }

    }
}
