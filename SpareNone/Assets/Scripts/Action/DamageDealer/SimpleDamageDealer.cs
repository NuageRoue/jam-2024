using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Knockback))]
public class SimpleDamageDealer : Action, IDamageDealer
{
    [SerializeField] Knockback knockback;

    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask layerMask;

    [SerializeField] float attackForce;

    private void Awake()
    {
        knockback = GetComponent<Knockback>();
    }
    public bool DealDamage(Life ennemy)
    {
        throw new System.NotImplementedException();
    }

    public override void PerformAction()
    {
        float distance = Vector3.Distance(transform.position, attackPoint.position);

        Vector3 direction = new(attackPoint.position.x - transform.position.x, attackPoint.position.y - transform.position.y);

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, distance, layerMask);

        foreach (RaycastHit2D hit in hits)
        {
            Debug.Log(name + ": attacking " + hit.collider.name);
            if (knockback != null)
            {
                knockback.Push(hit, direction, 3f);
            }
            else
                Debug.Log(name + ": has no knockback?");
        }
    }
}