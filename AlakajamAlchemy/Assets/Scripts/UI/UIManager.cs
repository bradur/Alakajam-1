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
        uiInventoryManager.AddItem(item);
    }

    public void RemoveItem(InventoryItem item)
    {
        uiInventoryManager.RemoveItem(item);
    }

    public void UpdateItemCount(InventoryItem item, int count)
    {
        uiInventoryManager.UpdateItemCount(item, count);
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
        }
        return false;
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
