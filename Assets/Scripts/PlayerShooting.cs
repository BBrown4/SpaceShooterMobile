using System;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject laserBullet;
    [SerializeField] private Transform basicShootingPoint;
    [SerializeField] private float shootingInterval;
    private float _intervalReset;

    private void Start()
    {
        _intervalReset = shootingInterval;
    }

    private void Update()
    {
        shootingInterval -= Time.deltaTime;
        if (!(shootingInterval <= 0)) return;
        Shoot();
        shootingInterval = _intervalReset;
    }

    private void Shoot()
    {
        Instantiate(laserBullet, basicShootingPoint.position, Quaternion.identity);
    }
}
