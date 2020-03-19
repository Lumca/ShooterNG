using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip(("in ms^-1"))] [SerializeField] float xSpeed = 45f;
    [Tooltip(("in ms^-1"))] [SerializeField] float ySpeed = 45f;
    [SerializeField] float xEdge = 15f;
    [SerializeField] float yEdge = 7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementHorizontal();
        movementVertical();
        void movementHorizontal()
        {
            float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
            float xOffset = xThrow * xSpeed * Time.deltaTime;
            float rawNewXPos = transform.localPosition.x + xOffset;
            float clampXPos = Mathf.Clamp(rawNewXPos, -xEdge, xEdge);
            transform.localPosition = new Vector3(clampXPos, transform.localPosition.y, transform.localPosition.z);
        }
        
        void movementVertical()
        {
            float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
            float yOffset = yThrow * ySpeed * Time.deltaTime;
            float rawNewYPos = transform.localPosition.y + yOffset;
            float clampYPos = Mathf.Clamp(rawNewYPos, -yEdge, yEdge);
            transform.localPosition = new Vector3(transform.localPosition.x, clampYPos, transform.localPosition.z);
            
            transform.localRotation = Quaternion.Euler(0,0,0);
        }
        
    }
}
