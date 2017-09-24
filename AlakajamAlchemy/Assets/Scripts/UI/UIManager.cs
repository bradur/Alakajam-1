using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static UIManager main;

    [SerializeField]
    private GameObject secretMobs;
    public GameObject GetSecretMobs { get { return secretMobs; } }

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

    

    [SerializeField]
    private UIInventoryManager uiInventoryManager;

    [SerializeField]
    private UIHPManager uiHPManager;

    public void AddHp(int count)
    {
        uiHPManager.AddHp(count);
    }

    public void AddItem(InventoryItem item)
    {
        if (item.type == ItemType.Bolt)
        {
            UpdateCrossbowCount(item.count);
        }
        else if (item.type == ItemType.LovePotion)
        {
            UpdatePotionCount(item.count);
        }
        else
        {
            uiInventoryManager.AddItem(item);
        }
    }

    public void RemoveItem(InventoryItem item)
    {
        uiInventoryManager.RemoveItem(item);
    }

    public void UpdateItemCount(InventoryItem item, int count)
    {
        if (item.type == ItemType.Bolt)
        {
            UpdateCrossbowCount(count);
        }
        else if (item.type == ItemType.LovePotion)
        {
            UpdatePotionCount(count);
        }
        else
        {
            uiInventoryManager.UpdateItemCount(item, count);
        }
    }

    void UpdateCrossbowCount(int count)
    {
        rightHotbarItem.UpdateCount(count);
    }

    [SerializeField]
    private UIHotbarItem potionHotbarItem;
    void UpdatePotionCount(int count)
    {

        potionHotbarItem.UpdateCount(count);
    }

    [SerializeField]
    private UIHotbarItem leftHotbarItem;
    [SerializeField]
    private UIHotbarItem rightHotbarItem;

    public bool UseHotBarItem(HotbarItem hotbarItemType)
    {
        if (hotbarItemType == HotbarItem.Left)
        {
            return leftHotbarItem.Use();
        } else if (hotbarItemType == HotbarItem.Right){
            return rightHotbarItem.Use();
        } else if (hotbarItemType == HotbarItem.Potion)
        {
            return potionHotbarItem.Use();
        }
        return false;
    }

    public void ShowLovePotionHotbar()
    {
        potionHotbarItem.gameObject.SetActive(true);
    }

    [SerializeField]
    private UIDialogueManager uiDialogueManager;

    public void ShowMessage(string message)
    {
        uiDialogueManager.ShowDialogue(message);
    }

    public void CloseDialog()
    {
        uiDialogueManager.CloseDialogue();
    }

    [SerializeField]
    private UIToggle uiMusic;


    [SerializeField]
    private UIHotbarItem talkHotBarItem;
    private bool allowTalking = false;
    public void AllowTalking ()
    {
        if (!allowTalking)
        {
            allowTalking = true;
            talkHotBarItem.Use();
        }
    }

    public void UnallowTalking ()
    {
        if (allowTalking)
        {
            allowTalking = false;
            talkHotBarItem.DisableInstantly();
        }
    }

    public void ToggleMusic()
    {
        uiMusic.ToggleMusic();
    }

    public void ToggleSfx()
    {
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    bool menuOpen = false;
    void Update ()
    {

        if (gameOver || wonGame || menuOpen)
        {
            if (KeyManager.main.GetKeyDown(Action.Quit))
            {
                Application.Quit();
            }
            if (KeyManager.main.GetKeyDown(Action.Restart))
            {
                Restart();
            }
            if (menuOpen && KeyManager.main.GetKeyDown(Action.CloseMenu)) {
                CloseDialog();
                menuOpen = false;
                Time.timeScale = 1f;
            }
        }
        else
        {
            if (KeyManager.main.GetKeyDown(Action.OpenMenu))
            {
                menuOpen = true;
                ShowMessage("Game paused.\n\nPress Q to quit, R to restart. Esc to close this menu.");
                Time.timeScale = 0f;
            }
        }
    }

    /*[SerializeField]
    private GameObject gameOverScreen;*/

    private bool gameOver = false;
    public void ShowGameOverScreen ()
    {
        gameOver = true;
        ShowMessage("Game Over!\n\nPress Q to quit, R to restart.");
        Time.timeScale = 0f;
    }

    /*[SerializeField]
    private GameObject theEndScreen;*/

    private bool wonGame = false;
    public void ShowTheEndScreen()
    {
        wonGame = true;
        ShowMessage("The end.\n\nThanks for playing!\nPress Q to quit, R to restart.");
        Time.timeScale = 0f;
    }
}
