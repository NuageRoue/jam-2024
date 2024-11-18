using DigitalRuby.Tween;
using UnityEngine;

public class Life: MonoBehaviour
{
    [SerializeField] int maxLife;
    [SerializeField] int life;
    [SerializeField] LifeBar lifeBar;
    [SerializeField] Transform lifeBarAnchor;
    Vector3 anchorPosition;
    ColorTween tween;

    SpriteRenderer spriteRenderer;
    private void Start()
    {
        if (lifeBarAnchor != null)
        {
            anchorPosition = lifeBarAnchor.localPosition;
            lifeBarAnchor.transform.parent = null;
        }
        life = maxLife;
        spriteRenderer = GetComponent<SpriteRenderer>();


    }
    private void Update()
    {
        if (lifeBarAnchor != null)
            lifeBarAnchor.position = anchorPosition + transform.position;
        if (life <= 0)
        {
            Debug.Log(name + " is dead");
            tween.Stop(TweenStopBehavior.Complete);
            Destroy(gameObject);
        }
    }
    public bool InflictDamage(int damage)
    {
        ChangeColor(Color.red);
        life -= damage;
        lifeBar.UpdateLifebar((float)life / (float)maxLife);
        return life <= 0;
    }

    /// <summary>
    /// modifier la couleur du sprite pendant une courte durée (pour signifier une attaque).
    /// </summary>
    /// <param name="color"> la couleur en question </param>
    void ChangeColor(Color color)
    {
        System.Action<ITween<Color>> updateColor = (t) =>
        {
            spriteRenderer.color = t.CurrentValue;
        };

        tween = gameObject.Tween(null, color, Color.white, .6f, TweenScaleFunctions.QuadraticEaseOut, updateColor);
    }



    public void SetLifebar(LifeBar lifebar)
    {
        this.lifeBar = lifebar;
        lifebar.SetAnchor(lifeBarAnchor);
    }

    

}