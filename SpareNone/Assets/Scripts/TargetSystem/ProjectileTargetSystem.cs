using UnityEngine;

public class ProjectileTargetSystem : TargetSystem
{
    Vector3 targetPosition;
    public override Vector3 TargetPos()
    {
        return targetPosition;
    }

    public override void UpdateTarget()
    {
        return;
    }

    public void AcquireTarget(Vector3 _targetPosition)
    {
        targetPosition = _targetPosition;
    }
}