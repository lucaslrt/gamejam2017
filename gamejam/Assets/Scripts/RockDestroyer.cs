using UnityEngine;
using System.Collections;

public class RockDestroyer : MonoBehaviour
{

    public GameObject rockDestructionPoint;
    // Use this for initialization
    void Start()
    {
        rockDestructionPoint = GameObject.Find("RockDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < rockDestructionPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
