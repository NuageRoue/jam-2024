using System;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] float knockBackForce;

    //public bool Push(RaycastHit2D ennemy, Vector3 direction, float attackForce)
    //{
    //    CreatureBehaviour ennemyBehaviour = ennemy.collider.gameObject.GetComponent<CreatureBehaviour>();
    //
    //    if (ennemyBehaviour != null && ennemyBehaviour.weight < attackForce)
    //    {
    //        Debug.Log(name + ": pushing "+ennemy.collider.name);
    //        ennemyBehaviour.movement.Impulse(knockBackForce * (attackForce - ennemyBehaviour.weight) * Vector3.Normalize(direction));
    //        //ennemy.rigidbody.AddForceAtPosition( knockBackForce *(attackForce - ennemyBehaviour.weight) * Vector3.Normalize(direction), ennemy.point, ForceMode2D.Impulse);
    //        return true;
    //    }
    //    return false;
    //}

    public bool Push(RaycastHit2D ennemy, Vector3 direction, float attackForce)
    {
        CreatureBehaviour ennemyBehaviour = ennemy.collider.gameObject.GetComponent<CreatureBehaviour>();
        if (ennemyBehaviour != null && ennemyBehaviour.weight < attackForce)
        {
            Debug.Log(name + ": pushing " + ennemyBehaviour.name);
            ennemyBehaviour.gameObject.GetComponent<Movement>().Impulse(knockBackForce * (attackForce - ennemyBehaviour.weight) * Vector3.Normalize(direction));       
        }
        return true;
    }
}