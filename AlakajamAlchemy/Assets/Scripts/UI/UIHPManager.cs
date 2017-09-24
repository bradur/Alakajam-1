// Date   : 24.09.2017 20:04
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIHPManager : MonoBehaviour {

    [SerializeField]
    private Text txtComponent;
    [SerializeField]
    private Color colorVariable;
    [SerializeField]
    private Image imgComponent;

    [SerializeField]
    [Range(10, 50)]
    int hp = 50;

    void Start ()
    {
        txtComponent.text = hp + "";
    }

    public void AddHp (int count)
    {
        hp += count;
        txtComponent.text = "" + hp;
        if (hp < 0)
        {
            UIManager.main.ShowGameOverScreen();
        }
    }

}
