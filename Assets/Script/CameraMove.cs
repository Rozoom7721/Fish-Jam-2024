using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Camera cam;
    private Vector3 moveDrag;
    [SerializeField] private SpriteRenderer mapSprite;
    private float mapMinX, mapMinY, mapMaxX, mapMaxY;

    private void Update()
    {

        CameraMovement();

    }
    private void Awake()
    {
        mapMinX = mapSprite.transform.position.x - mapSprite.bounds.size.x / 2f;
        mapMaxX = mapSprite.transform.position.x + mapSprite.bounds.size.x / 2f;
        mapMinY = mapSprite.transform.position.y - mapSprite.bounds.size.y / 2f;
        mapMaxY = mapSprite.transform.position.y + mapSprite.bounds.size.y / 2f;
    }


    private void CameraMovement()
    {

        if (Input.GetMouseButtonDown(0))
        {
            moveDrag = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 difference = moveDrag - cam.ScreenToWorldPoint(Input.mousePosition);
            //print("origin " + moveDrag + " newPosition " + cam.ScreenToWorldPoint(Input.mousePosition) + " =difference" + difference);
            cam.transform.position = ClampCamera(cam.transform.position + difference);



        }
        
    }
    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;
        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }
}

