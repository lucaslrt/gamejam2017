using UnityEngine;
using System.Collections;

public class TreeDestroyer : MonoBehaviour {

    public GameObject treeDestructionPoint;
    // Use this for initialization
    void Start()
    {
        treeDestructionPoint = GameObject.Find("TreeDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < treeDestructionPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
