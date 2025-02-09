using Unity.VisualScripting;
using UnityEngine;

public class ProjectileSpawner : Action
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject projectile;
    protected override void PerformAction()
    {
        Projectile sent = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation).GetComponent<Projectile>();
        sent.InitializeProjectile(transform);
    }
}