using UnityEngine;
using UnityEngine.UIElements;

public abstract class Target : MonoBehaviour
{
    public Transform targetToFollow;
    public Vector3 targetPosition;
    public Transform position;


    public bool isFollowing = true; // wether or not we follow a moving target (true by default)
    public bool updateTarget;

    protected void Start()
    {
        if (position == null)
            position = transform;
        AcquireTarget();
    }
    protected void Update()
    {
        if (updateTarget)
            AcquireTarget();
        if (isFollowing)
            GetTargetPosition();
    }
    public Vector3 GetNormalizedDirection()
    {
        if (targetPosition == null)
            GetTargetPosition();

        return Vector3.Normalize(new(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y));
    }

    public float GetDistanceToTarget()
    {
        return Vector3.Distance(position.position, targetPosition);
    }

    public void GetTargetPosition()
    {
        targetPosition = targetToFollow.position;
    }

    protected abstract void AcquireTarget();

    public void SetTarget(Transform target)
    {
        targetToFollow = target;
    }

    public bool IsSelf()
    {
        return (targetToFollow == transform);
    }
}