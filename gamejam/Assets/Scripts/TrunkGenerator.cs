using UnityEngine;
using System.Collections;

public class TrunkGenerator : MonoBehaviour
{
    public GameObject trunk;
    public Transform trunkGenerationPoint;
    public float distanceBetween;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < trunkGenerationPoint.position.x)
        {

            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            transform.position = new Vector3(transform.position.x + distanceBetween, transform.position.y, transform.position.z);

            Instantiate(trunk, transform.position, transform.rotation);
        }

    }

}

