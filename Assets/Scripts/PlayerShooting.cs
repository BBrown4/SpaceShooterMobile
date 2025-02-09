using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject laserBullet;
    [SerializeField] private float shootingInterval;
    [SerializeField] private AudioSource shootSfx;
    
    [Header("Basic Attack")]
    [SerializeField] private Transform basicShootingPoint;

    [Header("Upgrades")] [SerializeField] private int maxUpgradeLevel = 4;
    [SerializeField] private Transform[] firstUpgradePoints;
    [SerializeField] private Transform[] secondUpgradePoints;
    [SerializeField] private Transform[] rotatedUpgradePoints;

    private int _upgradeLevel;
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

    public void IncreaseUpgrade(int amount)
    {
        _upgradeLevel += amount;
        if (_upgradeLevel > maxUpgradeLevel)
        {
            _upgradeLevel = maxUpgradeLevel;
        }
    }

    public void DecreaseUpgrade()
    {
        _upgradeLevel -= 1;
        if (_upgradeLevel < 0)
        {
            _upgradeLevel = 0;
        }
    }

    private void Shoot()
    {
        shootSfx.Play();
        switch (_upgradeLevel)
        {
            case 0:
                ShootBasic();
                break;
            case 1:
                ShootUpgrade(firstUpgradePoints);
                break;
            case 2:
                ShootBasic();
                ShootUpgrade(firstUpgradePoints);
                break;
            case 3:
                ShootBasic();
                ShootUpgrade(firstUpgradePoints);
                ShootUpgrade(secondUpgradePoints);
                break;
            case 4:
                ShootBasic();
                ShootUpgrade(firstUpgradePoints);
                ShootUpgrade(secondUpgradePoints);
                ShootUpgrade(rotatedUpgradePoints, true);
                break;
        }
    }

    private void ShootBasic()
    {
        Instantiate(laserBullet, basicShootingPoint.position, Quaternion.identity);
    }

    private void ShootUpgrade(Transform[] upgradePoints, bool useTransformRotation = false)
    {
        foreach (var point in upgradePoints)
        {
            var rotation = useTransformRotation ? point.rotation : Quaternion.identity;
            Instantiate(laserBullet, point.position, rotation);
        }
    }
}
