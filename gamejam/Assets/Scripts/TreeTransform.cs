using UnityEngine;
using System.Collections;

public class TreeTransform : MonoBehaviour {

    [SerializeField]
    private SpriteRenderer spriteRender;
    [SerializeField]
    private Sprite treeSprite;

    private bool hasCollided = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "tail" && !hasCollided)
        {
            hasCollided = true;
            spriteRender.sprite = treeSprite;
        }
    }
}
