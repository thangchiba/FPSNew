using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] GameObject menuDefeat;
    public void ShowMenuDefeat()
    {
        if (menuDefeat.activeSelf == false)
            ChangeState(menuDefeat);
    }

    public void NewGame()
    {
        Debug.Log("Click new game");
        var nowScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(nowScene.buildIndex);
        ChangeState(menuDefeat);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void ChangeState(GameObject menu)
    {
        menu.SetActive(!menu.activeSelf);
    }
}
