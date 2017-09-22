using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{

    public static UIManager main;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("UIManager").Length == 0)
        {
            main = this;
            gameObject.tag = "UIManager";
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /*[SerializeField]
    private HUDToggle hudMusic;*/

    /*[SerializeField]
    private HUDToggle hudSfx;*/

    public void ToggleMusic()
    {
    }

    public void ToggleSfx()
    {
    }


    /*[SerializeField]
    private GameObject gameOverScreen;*/

    public void ShowGameOverScreen ()
    {
    }

    /*[SerializeField]
    private GameObject theEndScreen;*/

    public void ShowTheEndScreen()
    {
    }
}
