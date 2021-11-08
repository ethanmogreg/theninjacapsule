using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Camera playerCamera;
    public CharacterController controller;
    public float jumpForce;
    public float gravityScale;
    public Vector3 externalMovement;
    public bool isSprinting = false;
    private Vector3 moveDirection;
    public GameObject projectilePrefab;
    private ImpactReceiver impact;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        impact = GetComponent<ImpactReceiver>();
    }

    // Update is called once per frame
    void Update()
    {
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical") * moveSpeed) + (transform.right * Input.GetAxisRaw("Horizontal") * moveSpeed);
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject ninjaStar = Instantiate(projectilePrefab);
            ninjaStar.transform.position = transform.position + playerCamera.transform.forward;
            ninjaStar.transform.forward = playerCamera.transform.forward;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }

        if (controller.isGrounded)
        {
            if (isSprinting)
            {
                moveSpeed = 15;
                jumpForce = 22;
            }

            else
            {
                moveSpeed = 5;
                jumpForce = 20;
            }

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        //Gives player gradual descent.
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!controller.isGrounded && hit.normal.y <= 0.1f)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.DrawRay(hit.point, hit.normal, Color.red, 1.25f);
                moveDirection.y = jumpForce;
                if (Input.GetKey(KeyCode.W))
                {
                    impact.AddImpact(-transform.forward, 100);
                    moveSpeed = 0;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    impact.AddImpact(transform.forward, 100);
                    moveSpeed = 0;
                }

                if (Input.GetKey(KeyCode.D))
                {
                    impact.AddImpact(-transform.right, 100);
                    moveSpeed = 0;
                }

                if (Input.GetKey(KeyCode.A))
                {
                    impact.AddImpact(transform.right, 100);
                    moveSpeed = 0;
                }

            }
        }
    }


}
