// Date   : 24.09.2017 14:07
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIDialogueManager : MonoBehaviour {

    [SerializeField]
    private Text txtComponent;
    [SerializeField]
    private Color colorVariable;
    [SerializeField]
    private Image imgComponent;

    Animator animator;

    private bool open = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDialogue()
    {
        open = true;
        animator.SetTrigger("Open");
    }

    public void CloseDialogue()
    {
        open = false;
        animator.SetTrigger("Close");
    }

    public void ShowDialogue(string dialogue)
    {
        if (!open)
        {
            OpenDialogue();
        }
        txtComponent.text = dialogue;
    }
}
