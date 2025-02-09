using UnityEngine;

public abstract class Action : MonoBehaviour
{
    [SerializeField] float loadTime;
    [SerializeField] public float waitTime;

    [SerializeField] float loadTimer = -1;

    protected void Start()
    {
        loadTimer = loadTime;
    }

    /*public void Act()
    {
        if (waitTimer <= 0) 
        { 
            if (loadTimer <= 0)
            {
                Debug.Log(name + ": acting");
                PerformAction();
                loadTimer = loadTime;
                waitTimer = waitTime;
            }
            else
            {
                loadTimer -= Time.deltaTime;
            }
        }
        else
        {
            waitTimer -= Time.deltaTime;
        }
    }*/

    public bool Act()
    {
        if (loadTimer <= 0)
        {
            Debug.Log(name + " is acting:");
            PerformAction();
            ResetTimer();
            return true;
            //GetComponent<CreatureBehaviour>().Stun(waitTime);
        }
        else
        {
            loadTimer -= Time.deltaTime;
        }
        return false;
    }

    public void ResetTimer()
    {
        loadTimer = loadTime;
    }
    protected abstract void PerformAction();
}