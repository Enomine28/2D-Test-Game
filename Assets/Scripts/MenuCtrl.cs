using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuCtrl : MonoBehaviour {

	public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
