using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    [SerializeField] private Vector3 moveVelocity;

    [SerializeField] private Camera mainCamera;

    [SerializeField] float jumpForce;
    [SerializeField] CapsuleCollider collider;
    [SerializeField] LayerMask groundLayers;


    [SerializeField] private Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        collider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal")*moveSpeed, myRigidbody.velocity.y , Input.GetAxisRaw("Vertical")*moveSpeed);


        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        float rayLength;

        if (groundPlane.Raycast(cameraRay,out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3 (pointToLook.x, transform.position.y,pointToLook.z));
        }


        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 t = new Vector3(Random.value, Random.value, Random.value); 
            myRigidbody.AddForce(t * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(collider.bounds.center, new Vector3(collider.bounds.center.x, collider.bounds.min.y, collider.bounds.center.z), collider.radius * .9f, groundLayers );
    }

    private void FixedUpdate()
    {
        myRigidbody.velocity = moveInput;
    }
}
