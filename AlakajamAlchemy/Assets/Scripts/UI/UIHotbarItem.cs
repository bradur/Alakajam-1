// Date   : 23.09.2017 23:28
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum HotbarItem
{
    None,
    Left,
    Right
}

public class UIHotbarItem : MonoBehaviour {

    [SerializeField]
    private Text txtComponent;
    [SerializeField]
    private Color colorVariable;
    [SerializeField]
    private Image imgComponent;

    [SerializeField]
    [Range(0.1f, 10f)]
    private float cooldownTime;
    private float cooldownTimer;

    private bool inUse = false;

    void Start()
    {
        Use();
    }

    public bool Use ()
    {
        if (!inUse)
        {
            cooldownTimer = 0f;
            imgComponent.enabled = true;
            inUse = true;
            return true;
        }
        return false;
    }

    void Update ()
    {
        if (inUse)
        {
            cooldownTimer += Time.deltaTime;
            imgComponent.fillAmount = Mathf.Lerp(1.0f, 0f, cooldownTimer / cooldownTime);
            if (cooldownTimer >= cooldownTime)
            {
                inUse = false;
                cooldownTimer = 0f;
                imgComponent.enabled = false;
                imgComponent.fillAmount = 1f;
            }
        }
    }
}