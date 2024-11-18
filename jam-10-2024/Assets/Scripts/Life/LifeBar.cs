using System;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Transform anchor;
    [SerializeField] bool isMoving;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void UpdateLifebar(float percent)
    {
        image.fillAmount = percent;
    }

    public void SetAnchor(Transform lifeBarAnchor)
    {
        anchor = lifeBarAnchor;
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.position = anchor.position;
            if (image.fillAmount == 0)
                Destroy(gameObject);
        }
    }
}