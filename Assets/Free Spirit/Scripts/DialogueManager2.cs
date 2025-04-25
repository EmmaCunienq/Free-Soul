using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager2
{
    public TextMeshProUGUI txtZone;
    public float txtSpeed;

    public Dialogue dialogue;
    private string[] lines;
    private int index;

    private void Start()
    {
        lines = dialogue.lines;
    }

    private void StartDialogue()
    {
        index = 0;
        //StartCoroutine;

    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            txtZone.text += c;
            yield return new WaitForSeconds(txtSpeed);

        }
    }
}
