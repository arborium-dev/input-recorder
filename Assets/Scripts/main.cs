using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class TextChanger : MonoBehaviour
{
    public TMP_Text textBox;
    public AudioSource audioSource; // Reference to the AudioSource component
    public BeatmapRecorder beatmapRecorder; // Reference to the BeatmapRecorder
    
    bool[] _isPressedNow = new bool[6];
    private string _isPressedNowText;
        
    private InputAction _buttonOne;
    private InputAction _buttonTwo;
    private InputAction _buttonThree;
    private InputAction _buttonFour;
    private InputAction _buttonFive;
    private InputAction _musicButton;
    private InputAction _saveButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _buttonOne = InputSystem.actions.FindAction("ButtonOne");
        _buttonTwo = InputSystem.actions.FindAction("ButtonTwo");
        _buttonThree = InputSystem.actions.FindAction("ButtonThree");
        _buttonFour = InputSystem.actions.FindAction("ButtonFour");
        _buttonFive = InputSystem.actions.FindAction("ButtonFive");
        _musicButton = InputSystem.actions.FindAction("MusicButton");
        _saveButton = InputSystem.actions.FindAction("SaveButton");
    }

    // Update is called once per frame
    void Update()
    {
        _isPressedNowText = null;
        
        for (int i = 0; i < 5; i++)
        {
            _isPressedNow[i] = false;
        }
        
        
        
        // Record button presses to beatmap (only on first press, not while held)
        if (_buttonOne.WasPressedThisFrame() && beatmapRecorder != null)
        {
            beatmapRecorder.AddNoteToButtonOne();
        }
        if (_buttonTwo.WasPressedThisFrame() && beatmapRecorder != null)
        {
            beatmapRecorder.AddNoteToButtonTwo();
        }
        if (_buttonThree.WasPressedThisFrame() && beatmapRecorder != null)
        {
            beatmapRecorder.AddNoteToButtonThree();
        }
        if (_buttonFour.WasPressedThisFrame() && beatmapRecorder != null)
        {
            beatmapRecorder.AddNoteToButtonFour();
        }
        if (_buttonFive.WasPressedThisFrame() && beatmapRecorder != null)
        {
            beatmapRecorder.AddNoteToButtonFive();
        }
        
        // Check if buttons are currently held (for display)
        if (_buttonOne.IsPressed())
        {
            _isPressedNow[0] = true;
        }
        if (_buttonTwo.IsPressed())
        {
            _isPressedNow[1] = true;
        }
        if (_buttonThree.IsPressed())
        {
            _isPressedNow[2] = true;
        }
        if (_buttonFour.IsPressed())
        {
            _isPressedNow[3] = true;
        }
        if (_buttonFive.IsPressed())
        {
            _isPressedNow[4] = true;
        }
        
        // Toggle music when MusicButton is pressed
        if (_musicButton != null && _musicButton.WasPressedThisFrame())
        {
            if (audioSource != null)
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Pause();
                    // Stop recording when music pauses
                    if (beatmapRecorder != null)
                    {
                        beatmapRecorder.StopRecording();
                    }
                }
                else
                {
                    audioSource.Play();
                    // Start recording when music starts
                    if (beatmapRecorder != null)
                    {
                        beatmapRecorder.StartRecording();
                    }
                }
            }
        }
        
        // Save beatmap when SaveButton is pressed
        if (_saveButton != null && _saveButton.WasPressedThisFrame())
        {
            if (beatmapRecorder != null)
            {
                beatmapRecorder.SaveBeatmapToJson();
                Debug.Log("Beatmap saved!");
            }
        }
        
        
        for (int i = 0; i < 5; i++)
        {
            _isPressedNowText += _isPressedNow[i];
        }
        
        textBox.text = _isPressedNowText;
    }
}
