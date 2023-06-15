using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExitGameScript : MonoBehaviour
{

    public void GameExit()
    {
    
        EditorApplication.isPlaying = false; 
        
        //Application.Quit(); }endif 
    }

}
