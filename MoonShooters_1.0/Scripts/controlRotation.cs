using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlRotation : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float mouseX;
    private float mouseY;
    private float cameraDif;
    public GameObject projectilPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //Difference of camera
        cameraDif = Camera.main.transform.position.y - transform.position.y;
    }
    
    // Update is called once per frame
    void Update()
    {
        //Gets mouse position
        mouseX = Input.mousePosition.x;

        mouseY = Input.mousePosition.y;

        Vector3 worldpos = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, cameraDif));

        Vector3 turretLookDirection = new Vector3(worldpos.x, transform.position.y, worldpos.z);

        transform.LookAt(turretLookDirection);
    }
}
