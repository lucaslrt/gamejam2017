using UnityEngine;
using System.Collections;

public class TrunkDestroyer : MonoBehaviour
{

    public GameObject trunkDestructionPoint;
    // Use this for initialization
    void Start()
    {
        trunkDestructionPoint = GameObject.Find("TrunkDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < trunkDestructionPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
