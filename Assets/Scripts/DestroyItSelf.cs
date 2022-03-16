using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItSelf : MonoBehaviour
{
    [SerializeField] float timeBeforeDestroy;
    void Awake()
    {
        Destroy(gameObject, timeBeforeDestroy);
    }
}
