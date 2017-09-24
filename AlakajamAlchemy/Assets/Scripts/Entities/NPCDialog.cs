// Date   : 24.09.2017 14:19
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum DialogType
{
    None,
    Greeting,
    FetchViolets,
    FetchRoses,
    FetchOrchids,
    FetchLoti,
    KillRabbits,
    KillFrogs,
    KillBandits,
    End
}

[System.Serializable]
public class Dialog : System.Object
{
    [TextArea]
    public List<string> messages;
    [TextArea]
    public List<string> idleMessages;
    public DialogType type;
    [TextArea]
    public string finishMessage;
    public QuestRequirement requirementToAdvance;
}

[System.Serializable]
public class QuestRequirement : System.Object
{
    public List<InventoryItem> items;
}

public class NPCDialog : MonoBehaviour
{

    [SerializeField]
    private List<Dialog> dialogs;

    private int currentDialog = 0;
    private int currentMessage = 0;
    private int currentIdleMessage = 0;
    private bool dialogDone = false;
    private bool idleMessagesDone = false;

    [SerializeField]
    [Range(0.5f, 10f)]
    private float dialogMinDistance = 2f;

    /*
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ShowMessage(collision.gameObject);
        }
    }*/
    private bool activeDialog = false;

    private GameObject playerObject;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    private bool PlayerIsWithinTalkingDistance()
    {
        if (Vector2.Distance(transform.position, playerObject.transform.position) < dialogMinDistance)
        {
            UIManager.main.AllowTalking();
            return true;
        }
        else
        {
            if (activeDialog)
            {
                UIManager.main.CloseDialog();
                activeDialog = false;
            }
            UIManager.main.UnallowTalking();
            return false;
        }
    }

    private void Update()
    {
        if (KeyManager.main.GetKeyUp(Action.Talk))
        {
            if (PlayerIsWithinTalkingDistance())
            {
                ShowMessage();
            }
        }
        else
        {
            PlayerIsWithinTalkingDistance();
        }
    }

    void ResetDialog()
    {
        currentDialog += 1;
        currentMessage = 0;
        currentIdleMessage = 0;
        idleMessagesDone = false;
        dialogDone = false;
    }

    public void ShowMessage()
    {
        if (dialogs.Count > currentDialog)
        {
            Dialog dialog = dialogs[currentDialog];
            PlayerInventoryManager pim = playerObject.GetComponent<PlayerInventoryManager>();
            if (dialogs.Count > (currentDialog + 1) && ProcessRequirement(dialog.requirementToAdvance, pim))
            {
                pim.Consume(dialog.requirementToAdvance.items);
                UIManager.main.ShowMessage(dialog.finishMessage);
                activeDialog = true;
                ResetDialog();
                dialog = dialogs[currentDialog];
            }
            else
            {
                string message = "";
                if (dialogDone)
                {
                    if (activeDialog)
                    {
                        UIManager.main.CloseDialog();
                        activeDialog = false;
                    }
                    else
                    {
                        if (dialog.idleMessages.Count <= currentIdleMessage)
                        {
                            currentIdleMessage = 0;
                        }
                        message = dialog.idleMessages[currentIdleMessage];
                        currentIdleMessage += 1;
                        UIManager.main.ShowMessage(message);
                        activeDialog = true;
                    }
                }
                else
                {
                    if (dialog.messages.Count <= currentMessage)
                    {
                        if (activeDialog)
                        {
                            UIManager.main.CloseDialog();
                            activeDialog = false;
                        }
                        else
                        {
                            dialogDone = true;
                        }
                    }
                    else
                    {
                        message = dialog.messages[currentMessage];
                        currentMessage += 1;
                        UIManager.main.ShowMessage(message);
                        activeDialog = true;
                    }
                }
            }

        }
    }

    public bool ProcessRequirement(QuestRequirement requirement, PlayerInventoryManager pim)
    {
        return pim.CanConsume(requirement.items);
    }
}
