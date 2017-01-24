using UnityEngine;
using System.Collections;

public class RockBroke : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer spriteRender;
    [SerializeField]
    private Sprite rockSprite;
    private bool hasCollided = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "attack")
        {
            hasCollided = true;
            this.gameObject.tag = "broken";
            spriteRender.sprite = rockSprite;
        }
    }
}
