// Date   : 24.09.2017 21:55
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIToggle : MonoBehaviour {

    [SerializeField]
    private Text txtComponent;
    [SerializeField]
    private Color colorVariable;
    [SerializeField]
    private Image imgComponent;

    void Start()
    {
        Render();
    }
         
    public void ToggleMusic()
    {
        bool musicOn = SoundManager.main.ToggleMusic();
        Render();
    }

    void Render ()
    {
        string onOff = SoundManager.main.MusicMuted ? "OFF" : "ON";
        txtComponent.text = "Music: " + onOff + " (P to toggle)";
    }


    void Update()
    {
        if (KeyManager.main.GetKeyDown(Action.ToggleMusic))
        {
            ToggleMusic();
        }
    }

}
