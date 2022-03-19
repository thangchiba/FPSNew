using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //Application.targetFrameRate = 60;
    [SerializeField] int hp = 10;
    public void HPDecrease(int damage)
    {
        hp -= damage;
        Debug.Log($"Player Health {hp}");
        if (hp <= 0) PlayerDie();
    }

    void PlayerDie()
    {
        FindObjectOfType<GameMenu>().ShowMenuDefeat();
        Time.timeScale = 0;
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
        GetComponent<StarterAssetsInputs>().cursorLocked = false;
        GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
        Cursor.visible = true;
    }
}
