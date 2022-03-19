using System.Collections;
using System.Collections.Generic;
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
        Debug.Log("Player Died");
    }
}
