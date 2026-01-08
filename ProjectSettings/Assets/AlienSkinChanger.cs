using UnityEngine;
public class AlienSkinChanger : MonoBehaviour
{
    public SpriteRenderer alienRenderer;
    public Sprite normalSprite;
    public Sprite upgradedSprite;
    void Start()
    {
        alienRenderer.sprite = normalSprite;
    }
    public void ChangeToUpgraded()
    {
        alienRenderer.sprite = upgradedSprite;
    }
}