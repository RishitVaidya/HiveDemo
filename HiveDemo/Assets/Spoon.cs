using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spoon : MonoBehaviour
{

    public float force = 10f;
    public float forceOffset = 0.1f;

    public Transform raycast_point;

    public Joystick joystick;

    public GameObject honey;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndActivateHoney());
    }

    IEnumerator WaitAndActivateHoney() 
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < honey.transform.childCount; i++)
        {
            honey.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        Vector3 direction = new Vector3(joystick.Direction.x, joystick.Direction.y, 0);

        GetComponent<Rigidbody>().velocity = direction * 5;
        //transform.Translate(direction * Time.deltaTime * 10, Space.World);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3,12), Mathf.Clamp(transform.position.y, 3, 19), transform.position.z);
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

    public void OnClick_Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
    }

}
