using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Aim_Weapon : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb; //this rigidbody2d has to be attached to the crosshair. The crosshairs canvas must be set to render in world, the crosshair image has to be placed in front of character and resized.
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;
    //this script goes on the camera
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToViewportPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
        rb.rotation = angle;
    }
}
