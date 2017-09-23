// Date   : 23.09.2017 14:21
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;

public class PlayerSwing : MonoBehaviour {

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private SpriteRenderer arms;

    void Start()
    {
        arms.enabled = true;
    }

    void Update()
    {
        if (KeyManager.main.GetKeyDown(Action.SwingSword))
        {
            Swing();
        }
    }

    public void Swing()
    {
        animator.SetTrigger("Swing");
        arms.enabled = false;
    }

    public void StopSwing()
    {
        arms.enabled = true;
        animator.SetTrigger("StopSwinging");
    }
}
