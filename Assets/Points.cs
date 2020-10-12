using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int points = 0;

    private void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 35;
        myStyle.normal.textColor = Color.green;
        GUI.Label(new Rect(30, 30, 100, 20), "Items: " + points + "/5", myStyle);
    }
}
