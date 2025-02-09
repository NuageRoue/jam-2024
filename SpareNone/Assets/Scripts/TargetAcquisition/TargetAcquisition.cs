using UnityEngine;

public abstract class TargetAcquisition : MonoBehaviour
{
    //protected Vector3 targetPos;

    protected Transform target = null;

    /// <summary>
    /// finds the targeted object
    /// </summary>
    /// <returns></returns>
    protected abstract bool GetTarget();
    
    public abstract Vector3 GetTargetPos();

    protected void Update()
    {
        if (target == null)
            GetTarget();
    }

}