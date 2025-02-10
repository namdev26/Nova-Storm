using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormHole : NamMonoBehaviour
{
    protected string sceneName = "GalaxyDemo";
    protected virtual void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
    }

    protected virtual void LoadGalaxy(){
        SceneManager.LoadScene(this.sceneName);
    }
}
//Load lại Scene