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

    [SerializeField]
    private UIInventoryManager uiInventoryManager;

    public void AddItem(InventoryItem item)
    {
        if (item.type == ItemType.Bolt)
        {
            UpdateCrossbowCount(item.count);
        } else
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

    /*[SerializeField]
    private HUDToggle hudMusic;*/

    /*[SerializeField]
    private HUDToggle hudSfx;*/

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
