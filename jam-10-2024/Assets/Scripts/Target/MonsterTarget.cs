using UnityEngine;

public class MonsterTarget : Target
{
    public string targetTag;
    protected override void AcquireTarget()
    {
        SetTarget(GameObject.FindGameObjectWithTag(targetTag).GetComponent<Transform>());
    }
}