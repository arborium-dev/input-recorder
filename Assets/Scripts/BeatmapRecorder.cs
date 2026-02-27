using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Data structures for the beatmap
[Serializable]
public class SongMetadata
{
    public string songName;
    public string artist;
    public float bpm;
    public float songLength;
    // Add more metadata fields as needed
}

[Serializable]
public class Beatmap
{
    public SongMetadata metadata;
    public List<float> buttonOne = new List<float>();
    public List<float> buttonTwo = new List<float>();
    public List<float> buttonThree = new List<float>();
    public List<float> buttonFour = new List<float>();
    public List<float> buttonFive = new List<float>();
}

public class BeatmapRecorder : MonoBehaviour
{
    private Beatmap currentBeatmap;
    private float recordingStartTime;
    private bool isRecording = false;

    void Start()
    {
        // Initialize a new beatmap
        currentBeatmap = new Beatmap();
        currentBeatmap.metadata = new SongMetadata
        {
            songName = "My Song",
            artist = "Artist Name",
            bpm = 120f,
            songLength = 180f
        };
    }

    // Call this when you want to start recording
    public void StartRecording()
    {
        isRecording = true;
        recordingStartTime = Time.time;
        Debug.Log("Recording started!");
    }

    // Call this when you want to stop recording
    public void StopRecording()
    {
        isRecording = false;
        Debug.Log("Recording stopped!");
    }

    // Example: Add a note for button one at current timestamp
    public void AddNoteToButtonOne()
    {
        if (!isRecording) return;
        
        float timestamp = Time.time - recordingStartTime;
        currentBeatmap.buttonOne.Add(timestamp);
        Debug.Log($"Button One note added at: {timestamp}");
    }

    // Example: Add a note for button two at current timestamp
    public void AddNoteToButtonTwo()
    {
        if (!isRecording) return;
        
        float timestamp = Time.time - recordingStartTime;
        currentBeatmap.buttonTwo.Add(timestamp);
        Debug.Log($"Button Two note added at: {timestamp}");
    }

    // Add a note for button three at current timestamp
    public void AddNoteToButtonThree()
    {
        if (!isRecording) return;
        
        float timestamp = Time.time - recordingStartTime;
        currentBeatmap.buttonThree.Add(timestamp);
        Debug.Log($"Button Three note added at: {timestamp}");
    }

    // Add a note for button four at current timestamp
    public void AddNoteToButtonFour()
    {
        if (!isRecording) return;
        
        float timestamp = Time.time - recordingStartTime;
        currentBeatmap.buttonFour.Add(timestamp);
        Debug.Log($"Button Four note added at: {timestamp}");
    }

    // Add a note for button five at current timestamp
    public void AddNoteToButtonFive()
    {
        if (!isRecording) return;
        
        float timestamp = Time.time - recordingStartTime;
        currentBeatmap.buttonFive.Add(timestamp);
        Debug.Log($"Button Five note added at: {timestamp}");
    }

    // Save the beatmap to a JSON file
    public void SaveBeatmapToJson(string fileName = "beatmap.json")
    {
        // Convert the beatmap object to JSON string
        string json = JsonUtility.ToJson(currentBeatmap, true); // true = pretty print
        
        // Determine the file path (saves to persistent data path)
        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        
        // Write the JSON string to file
        File.WriteAllText(filePath, json);
        
        Debug.Log($"Beatmap saved to: {filePath}");
        Debug.Log($"JSON Content:\n{json}");
    }

    // Load a beatmap from a JSON file
    public void LoadBeatmapFromJson(string fileName = "beatmap.json")
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        
        if (File.Exists(filePath))
        {
            // Read the JSON string from file
            string json = File.ReadAllText(filePath);
            
            // Convert JSON string back to beatmap object
            currentBeatmap = JsonUtility.FromJson<Beatmap>(json);
            
            Debug.Log($"Beatmap loaded from: {filePath}");
        }
        else
        {
            Debug.LogError($"File not found: {filePath}");
        }
    }

    // Note: Recording is now controlled through main.cs integration
    // Music button starts/stops recording automatically
    // Button presses are recorded automatically through main.cs
    
    // If you want to save the beatmap, call SaveBeatmapToJson() from another script
    // or add a UI button that calls this method
}

