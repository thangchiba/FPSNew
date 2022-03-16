using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hp = 100;
    public void HPDecrease(int damage)
    {
        hp -= damage;
        Debug.Log($"Enemy Health {hp}");
        if (hp <= 0) EnemyDie();
    }

    void EnemyDie()
    {
        Destroy(gameObject);
    }

}
