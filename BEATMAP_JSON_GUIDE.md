# Beatmap Recording - JSON Guide

## Overview
This guide explains how to work with JSON files for your beatmap recorder/creator.

## Key Concepts

### 1. **Data Structures**
You need C# classes that mirror the JSON structure you want. Unity's `JsonUtility` requires the `[Serializable]` attribute:

```csharp
[Serializable]
public class Beatmap
{
    public SongMetadata metadata;
    public List<float> buttonOne = new List<float>();
    public List<float> buttonTwo = new List<float>();
    // etc...
}
```

### 2. **Recording Timestamps**
To record when buttons are pressed:
- Start recording: `recordingStartTime = Time.time;`
- When button pressed: `timestamp = Time.time - recordingStartTime;`
- Add to list: `currentBeatmap.buttonOne.Add(timestamp);`

### 3. **Saving to JSON**
```csharp
// Convert object to JSON string
string json = JsonUtility.ToJson(beatmapObject, true);

// Write to file
string path = Path.Combine(Application.persistentDataPath, "beatmap.json");
File.WriteAllText(path, json);
```

### 4. **Loading from JSON**
```csharp
// Read from file
string json = File.ReadAllText(path);

// Convert JSON string to object
Beatmap loadedBeatmap = JsonUtility.FromJson<Beatmap>(json);
```

## File Locations
- **Application.persistentDataPath**: Best for user data (saved beatmaps)
  - Windows: `C:\Users\[username]\AppData\LocalLow\[company]\[project]`
- **Application.dataPath**: Inside Unity project's Assets folder
- **Application.streamingAssetsPath**: For read-only bundled data

## Integration with Your Current Code

### Option 1: Track button presses in Update()
In your `TextChanger` class, detect when buttons are **first pressed** (not held):
```csharp
if (_buttonOne.WasPressedThisFrame())
{
    beatmapRecorder.AddNoteToButtonOne();
}
```

### Option 2: Use Input System events
Subscribe to button performed events for cleaner code.

## Example Workflow

1. **Start recording** when music starts
2. **Capture timestamps** as player presses buttons
3. **Stop recording** when music ends
4. **Save to JSON** file with song metadata
5. Later: **Load JSON** to play back the beatmap

## Next Steps

1. Integrate `BeatmapRecorder.cs` with your `main.cs` 
2. Add UI buttons or hotkeys to start/stop recording and save
3. Add more metadata fields (difficulty, creator name, etc.)
4. Optionally: Use Newtonsoft.Json for more complex JSON features

## Using the Example Script

The `BeatmapRecorder.cs` includes test controls:
- **S key**: Start recording
- **E key**: End/stop recording  
- **Space**: Save beatmap to JSON
- **1-5 keys**: Add notes while recording (example)

The saved file will be at: `Application.persistentDataPath/beatmap.json`

Check the Unity Console for the exact path when you save!

