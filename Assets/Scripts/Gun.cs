using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public bool _inputFire;
    StarterAssetsInputs _input;
    [SerializeField] Transform _camera;
    [SerializeField] float _fireRange = 200f;
    [SerializeField] int damage = 1;
    [SerializeField] ParticleSystem fireParticle;
    [SerializeField] ParticleSystem hitParticle;
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
            fireParticle.Play();
        }
    }

    void Fire()
    {
        RaycastHit hit;
        Physics.Raycast(_camera.position, _camera.forward, out hit, _fireRange);
        if (hit.collider == null) return;
        Debug.Log($@"{transform.name} fire to {hit.collider.name}");
        HitParticle(hit.collider.gameObject,hit.normal);
        if (hit.collider.tag == "Enemy")
        {
            DamageEnemy(hit.collider.gameObject);
        }
    }

    private void DamageEnemy(GameObject enemy)
    {
        var enemyHealth = enemy.GetComponent<EnemyHealth>();
        enemyHealth.HPDecrease(damage);
    }

    void HitParticle(GameObject enemy,Vector3 hitPosition) {
        Instantiate(hitParticle, enemy.transform.position, Quaternion.LookRotation(hitPosition));
    }
}