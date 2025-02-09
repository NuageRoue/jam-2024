using UnityEngine;

public abstract class Projectile : Movement
{
    [SerializeField] int lifespan;
    float life;
    [SerializeField] TargetAcquisition targetAcquisition;
    Transform parent;

    public void InitializeProjectile(Transform _parent)
    {
        parent = _parent;
        targetAcquisition = GetComponent<TargetAcquisition>();
        life = 0;
    }
    private void Start()
    {
    }

    private void Update()
    {
        if (life < lifespan)
        {
            life += Time.deltaTime;
            MoveTowards(targetAcquisition.GetTargetPos(), 0);
        }
        else
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CreatureBehaviour>() != null && !collision.transform.Equals(parent))
        {
            OnContact(collision.gameObject.GetComponent<CreatureBehaviour>());
            DestroyProjectile();
        }
    }
    protected abstract void OnContact(CreatureBehaviour obstacle);

    protected abstract void DestroyProjectile();
}