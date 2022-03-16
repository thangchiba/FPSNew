using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool _inputFire;
    [SerializeField] Transform _player;
    [SerializeField] Transform _camera;
    StarterAssetsInputs _input;
    [SerializeField] float _fireRange = 200f;
    void Start()
    {
        _input = GameObject.FindGameObjectWithTag("Player").GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.fire)
        {
            Fire();
        }
    }

    void Fire()
    {
        RaycastHit hit;
        Physics.Raycast(_camera.position, _camera.forward, out hit, _fireRange);
        if (hit.collider != null)
            Debug.Log($@"{transform.name} fire to {hit.collider.name}");
    }
}