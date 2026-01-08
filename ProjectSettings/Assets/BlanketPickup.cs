using UnityEngine;
public class BlanketPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<AlienSkinChanger>().ChangeToUpgraded();
            Destroy(gameObject);
        }
    }
}