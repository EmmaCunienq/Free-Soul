using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI txtZone;
    public float txtSpeed;

    public bool inDialogue;
    public Dialogue dialogue;
    private string[] lines;
    private int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lines = dialogue.lines;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (inDialogue && Input.GetKeyDown(KeyCode.Space))
        {
            NextLine();
        }
    }

    private void StartDialogue()
    {
        inDialogue = true;
        index = 0;

        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        txtZone.text = string.Empty;

        foreach (char c in lines[index].ToCharArray())
        {
            txtZone.text += c;
            yield return new WaitForSeconds(txtSpeed);
        }
        index++;
        inDialogue = index < lines.Length;
    }

    void NextLine ()
    {
        if (index < lines.Length)
        {
            if (txtZone.text == lines[index - 1])
            {
                StartCoroutine(TypeLine());
            }
        }
    }
}
