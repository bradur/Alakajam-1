// Date   : 23.09.2017 01:59
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;

public class CrossbowBolt : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rigidBody;

    [SerializeField]
    [Range(0.2f, 50f)]
    private float speed;

    [SerializeField]
    private Color inactiveColor;

    [SerializeField]
    private bool isPotion = false;
    public bool IsPotion { get { return isPotion; } set { isPotion = value; } }

    public void Shoot()
    {
        rigidBody.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Mob" || collider.gameObject.tag == "Flower")
        {
            Destroy(gameObject);
        }
        rigidBody.velocity = Vector2.zero;
    }

    private void Update()
    {
        if (rigidBody.velocity.magnitude < 0.2f)
        {
            gameObject.layer = LayerMask.NameToLayer("Item");
            GetComponent<SpriteOutline>().color = inactiveColor;
            Destroy(this);
        }
    }
}
