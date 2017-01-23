using UnityEngine;
using System.Collections;

public class RockGenerator : MonoBehaviour
{
    public GameObject rock;
    public Transform rockGenerationPoint;
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
        if (transform.position.x < rockGenerationPoint.position.x)
        {

            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            transform.position = new Vector3(transform.position.x + distanceBetween, transform.position.y, transform.position.z);

            Instantiate(rock, transform.position, transform.rotation);
        }

    }

}

