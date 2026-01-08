using UnityEngine;

public class DialogueManager : MonoBehaviour

{

    [Header("Dialogue Sprites")]

    public SpriteRenderer dialogueSpriteRenderer; // Dialogue bubble

    public Sprite[] dialogueSprites;              // All dialogue pages

    [Header("Timing Bar")]

    public SpriteRenderer barBackground;          // The bar sprite

    public SpriteRenderer sliderWhite;            // The slider pointer

    public TimingBar timingBarScript;             // The TimingBar script

    private int dialogueIndex = 0;

    void Start()

    {

        dialogueSpriteRenderer.enabled = false;

        barBackground.enabled = false;

        sliderWhite.enabled = false;

    }

    public void StartConversation()

    {

        dialogueIndex = 0;

        ShowDialogue();

    }

    void ShowDialogue()

    {

        if (dialogueIndex >= dialogueSprites.Length)

        {

            EndConversation();

            return;

        }

        // Show dialogue

        dialogueSpriteRenderer.sprite = dialogueSprites[dialogueIndex];

        dialogueSpriteRenderer.enabled = true;

        // Show bar + slider

        barBackground.enabled = true;

        sliderWhite.enabled = true;

        timingBarScript.StartBar();

    }

    public void OnTimingBarFinished(bool success)

    {

        // Hide bar and slider

        barBackground.enabled = false;

        sliderWhite.enabled = false;

        timingBarScript.HideBar();

        if (success)

        {

            dialogueIndex++;

            ShowDialogue();

        }

        else

        {

            // Optional: show failure bubble

            Debug.Log("Timing failed!");

        }

    }

    void EndConversation()

    {

        dialogueSpriteRenderer.enabled = false;

        barBackground.enabled = false;

        sliderWhite.enabled = false;

        Debug.Log("Conversation finished!");

    }

}

