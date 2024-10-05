using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public static Vector3 playerPosition;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    [SerializeField] float sideLimit = 12f;
    [SerializeField] float fixedForwardSpeed = 30f;
    [SerializeField] float fixedStrafeSpeed = 10f;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        playerPosition = transform.position;
    }

    void FixedUpdate()
    {
        velocity = new Vector3(Input.GetAxisRaw("Horizontal") * fixedStrafeSpeed, 0, fixedForwardSpeed);
        transform.Translate(velocity * Time.deltaTime);

        transform.localPosition = new Vector3(Mathf.Clamp(transform.position.x, sideLimit * -1f, sideLimit), transform.position.y, transform.position.z);
    }
}