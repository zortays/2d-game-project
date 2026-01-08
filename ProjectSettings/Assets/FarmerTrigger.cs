using UnityEngine;
public class FarmerTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;  // drag your DialogueManager here
    public string playerTag = "Player";      // make sure your player GameObject is tagged "Player"
    private bool conversationStarted = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!conversationStarted && other.CompareTag(playerTag))
        {
            dialogueManager.StartConversation();
            conversationStarted = true;  // prevent it from retriggering
        }
    }
}