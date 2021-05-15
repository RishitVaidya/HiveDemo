using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoon : MonoBehaviour
{

    public float force = 10f;
    public float forceOffset = 0.1f;

    public Transform raycast_point;

    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        Vector3 direction = new Vector3(-joystick.Direction.y, 0, joystick.Direction.x);

        transform.Translate(direction * Time.deltaTime * 10, Space.World);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -15, 22), transform.position.y, Mathf.Clamp(transform.position.z, -6, 9));
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(raycast_point.position, -Vector3.up, out hit))
        {
            print("Found an object - distance: " + hit.distance);
            MeshDeformer deformer = hit.collider.GetComponent<MeshDeformer>();
            if (deformer)
            {
                Vector3 point = hit.point;
                point += hit.normal * forceOffset;
                deformer.AddDeformingForce(point, force);
            }
        }
            
    }

}
