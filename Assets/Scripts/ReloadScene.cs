using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public int SceneID = 0;
    public void Reload(){
        SceneManager.LoadScene(SceneID);
    }
}
