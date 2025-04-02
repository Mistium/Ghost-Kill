using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public player_transform playerTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Called when another collider enters this object's trigger collider
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToDetect))
        {
            Debug.Log($"{tagToDetect} entered trigger: " + gameObject.name);
        }
    }
    
    // Called when another collider collides with this object
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagToDetect))
        {
            Debug.Log($"{tagToDetect} collided with: " + gameObject.name);
        }
    }
}
