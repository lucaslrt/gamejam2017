using UnityEngine;
using System.Collections;

public class TrunkBroke : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer spriteRender;
    [SerializeField]
    private Sprite trunkSprite;
    private bool hasCollided = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "attack" && !hasCollided)
        {
            hasCollided = true;
            Debug.Log("Tag before: " + gameObject.tag);
            gameObject.tag = "broken";
            Debug.Log("Tag after: " + gameObject.tag);
            spriteRender.sprite = trunkSprite;
        }
    }
}
