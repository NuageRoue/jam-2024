using UnityEditor;
using UnityEngine;

public class DamageProjectile : Projectile, IDamageDealer
{
    [SerializeField] int strength;
    [SerializeField] int damage;
    [SerializeField] Transform hitPoint;
    [SerializeField] LayerMask mask;


    public void InflictDamage(CreatureBehaviour Ennemy)
    {
        Debug.Log("hurting " + Ennemy.name);
        Ennemy.Hurt(damage);

    }

    public void Push(CreatureBehaviour Ennemy)
    {
        Ennemy.Push(strength, Vector3.Normalize(Ennemy.transform.position - transform.position));
    }

    protected override void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    protected override void OnContact(CreatureBehaviour obstacle)
    {
        InflictDamage(obstacle);
        Push(obstacle);
    }
}