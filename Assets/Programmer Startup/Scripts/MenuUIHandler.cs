using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        MainManager.instance.teamColor = color;
        // add code here to handle when a color is selected
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;

        //here is save color code;
        ColorPicker.SelectColor(MainManager.instance.teamColor);
    }
    public void StartNew(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Exit()
    {  

#if UNITY_EDITOR

        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
        MainManager.instance.SaveColor();
#endif

    }
    public void SaveColorClicked()
    {
        MainManager.instance.SaveColor();
    }

    public void LoadColorClicked()
    {
        MainManager.instance.LoadColor();
        ColorPicker.SelectColor(MainManager.instance.teamColor);
    }
}
