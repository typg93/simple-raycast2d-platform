using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Vector2 follow; //the gameobject the camera is following
    private Vector3 target; //where the camera is pointed at (used for smoothing)


    [Tooltip("bounds camera inside this room")]  
    public BoxCollider2D levelBounds;
    private Vector3 levelMinBounds;
    private Vector3 levelMaxBounds;
    private Camera cam;
    private float halfScreenWidth;
    private float halfScreenHeight;

    void Start()
    {
        UpdateCamera();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        target.x = Mathf.Clamp(target.x, levelMinBounds.x + halfScreenWidth, levelMaxBounds.x - halfScreenWidth);
        target.y = Mathf.Clamp(target.y, levelMinBounds.y + halfScreenHeight, levelMaxBounds.y - halfScreenHeight);
        transform.position = new Vector3(target.x, target.y, transform.position.z);       
    }

    public void UpdateCamera()
    {
        levelMinBounds = levelBounds.bounds.min;
        levelMaxBounds = levelBounds.bounds.max;
        cam = GetComponent<Camera>();
        halfScreenHeight = cam.orthographicSize;
        halfScreenWidth = halfScreenHeight * Screen.width / Screen.height;
    }
}
