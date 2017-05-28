using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour {

	// Use this for initialization
	public void chooseGameModeSolo () {
        PlayerPrefs.SetInt("GameMode", 1);
        changeLevel();
    }

    public void chooseGameModeMulti()
    {
        PlayerPrefs.SetInt("GameMode", 2);
        changeLevel();
    }

    void changeLevel()
    {
        SceneManager.LoadScene("sGame");
    }


}
