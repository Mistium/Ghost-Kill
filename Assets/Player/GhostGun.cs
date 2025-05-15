using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostGun : MonoBehaviour
{
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 target = hit.point;

            transform.position = new Vector3(transform.parent.position.x, transform.position.y, transform.parent.position.z);
            Vector3 direction = (target - transform.position).normalized;

            transform.position = new Vector3(transform.parent.position.x + 0.75f * direction.x, transform.position.y, transform.parent.position.z + 0.1f * direction.z);

            transform.LookAt(new Vector3(target.x, target.y, target.z));
            transform.Rotate(new Vector3(0, 90, 0));
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        }
    }
}
