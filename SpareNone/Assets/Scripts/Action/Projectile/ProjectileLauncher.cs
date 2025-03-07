using UnityEngine;

[RequireComponent(typeof(TargetSystem))]
public abstract class ProjectileLauncher : Action
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform launchingPoint;
    public override void PerformAction()
    {
        DirectProjectile(GameObject.Instantiate(projectile, launchingPoint.position, launchingPoint.rotation, null).GetComponent<Projectile>());
    }

    public abstract void DirectProjectile(Projectile projectile);
}