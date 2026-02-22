using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class TextChanger : MonoBehaviour
{
    public TMP_Text textBox;
    
    bool[] _isPressedNow = new bool[5];
    private string _isPressedNowText;
        
    private InputAction _buttonOne;
    private InputAction _buttonTwo;
    private InputAction _buttonThree;
    private InputAction _buttonFour;
    private InputAction _buttonFive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _buttonOne = InputSystem.actions.FindAction("ButtonOne");
        _buttonTwo = InputSystem.actions.FindAction("ButtonTwo");
        _buttonThree = InputSystem.actions.FindAction("ButtonThree");
        _buttonFour = InputSystem.actions.FindAction("ButtonFour");
        _buttonFive = InputSystem.actions.FindAction("ButtonFive");
    }

    // Update is called once per frame
    void Update()
    {
        _isPressedNowText = null;
        
        for (int i = 0; i < 5; i++)
        {
            _isPressedNow[i] = false;
        }
        
        
        
        
        if (_buttonOne.IsPressed())
        {
            _isPressedNow[1] = true;
        }
        if (_buttonTwo.IsPressed())
        {
            _isPressedNow[2] = true;
        }
        if (_buttonThree.IsPressed())
        {
            _isPressedNow[3] = true;
        }
        if (_buttonFour.IsPressed())
        {
            _isPressedNow[4] = true;
        }
        if (_buttonFive.IsPressed())
        {
            _isPressedNow[5] = true;
        }
        
        
        for (int i = 0; i < 5; i++)
        {
            _isPressedNowText += _isPressedNow[i];
        }
        
        textBox.text = _isPressedNowText;
    }
}
