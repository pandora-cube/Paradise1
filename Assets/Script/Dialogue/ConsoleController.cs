using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleController : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public AudioSource effect;
    private StartDialogueByCollider start;
    private int count;

    public bool OnDial = false;
    public int DialStack = 0;

    public Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        OnDial = true;
        DialStack += 1;
        nameText.text = dialogue.name;

        sentences.Clear();
        count = 0;

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void StartDialogue(Dialogue dialogue, StartDialogueByCollider dialogueByCollider)
    {
        OnDial = true;
        DialStack += 1;
        nameText.text = dialogue.name;
        start = dialogueByCollider;

        sentences.Clear();
        count = 1;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue(count);
            return;
        }
        effect.Play();
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    public void EndDialogue(int cas)
    {
        OnDial = false;
        Debug.Log("Stack = " + DialStack);
        nameText.text = "";
        dialogueText.text = "";
        if(cas == 1)
        {
            start.FinishDialogue();
        }
    }
}
