using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostGun : MonoBehaviour
{
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 target = hit.point;
            Debug.Log("Mouse Position in World Space: " + target);

            transform.position = new Vector3(transform.parent.position.x, transform.position.y, transform.parent.position.z);
            Vector3 direction = (target - transform.position).normalized;
            Debug.Log("Direction " + direction);

            transform.position = new Vector3(transform.parent.position.x + 0.75f * direction.x, transform.position.y, transform.parent.position.z + 0.1f * direction.z);
        }
    }
}
