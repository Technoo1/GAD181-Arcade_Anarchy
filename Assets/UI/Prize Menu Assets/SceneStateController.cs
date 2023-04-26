using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SceneState
{
    public Dictionary<string, Color> objectColors = new Dictionary<string, Color>();
}
public class SceneStateController : MonoBehaviour
{
    private SceneState sceneState = new SceneState();
    private string sceneStateKey = "scene_state";

    private void OnEnable()
    {
        //Debug.Log("Dictionary: " + sceneState.objectColors);
       // Debug.Log("Object Name: " + gameObject.name);
        //Debug.Log("OnEnable called for " + gameObject.name);
        string sceneStateJson = PlayerPrefs.GetString(sceneStateKey);
        if (!string.IsNullOrEmpty(sceneStateJson))
        {
            sceneState = JsonUtility.FromJson<SceneState>(sceneStateJson);
        }

        if (sceneState == null)
        {
            sceneState = new SceneState();
        }


        if (sceneState.objectColors.ContainsKey(gameObject.name))
        {
            // Get the color from the dictionary and set it on the game object's image
            GetComponent<Image>().color = sceneState.objectColors[gameObject.name];
        }
    }

    private void OnDisable()
    {
       // Debug.Log("OnDisable called for " + gameObject.name);
        if (sceneState == null)
        {
            sceneState = new SceneState();
        }

        // Save the color of this game object's image
        sceneState.objectColors[gameObject.name] = GetComponent<Image>().color;

        // Convert the SceneState object to JSON and save it in PlayerPrefs
        string sceneStateJson = JsonUtility.ToJson(sceneState);
        PlayerPrefs.SetString(sceneStateKey, sceneStateJson);
        PlayerPrefs.Save();
        //Debug.Log("Color Saved: " + GetComponent<Image>().color);
    }
}
