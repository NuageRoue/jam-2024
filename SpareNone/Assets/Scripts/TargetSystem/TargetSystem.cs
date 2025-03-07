using UnityEngine;

public abstract class TargetSystem : MonoBehaviour
{

    [SerializeField] protected Transform target;
    public abstract Vector3 TargetPos();
    public bool HasATarget()
    {
        return target != null;
    }

    public abstract void UpdateTarget();

}