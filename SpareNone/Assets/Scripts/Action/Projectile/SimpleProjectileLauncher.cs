using UnityEngine;

[RequireComponent(typeof(TargetSystem))]
public class SimpleProjectileLauncher : ProjectileLauncher
{
    TargetSystem targetSystem;
    [SerializeField] float projectileSpeed;
    private void Start()
    {
        targetSystem = GetComponent<TargetSystem>();
    }
    public override void DirectProjectile(Projectile projectile)
    {
        projectile.AcquireTarget(Vector3.Normalize(targetSystem.TargetPos() - transform.position), projectileSpeed);
    }
}