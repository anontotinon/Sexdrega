using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThirdPersonMovement : MonoBehaviour
{
    
    public CharacterController controller;
    public float speed = 1f;
    public float turnSmoothTime = 0.1f;
    public Transform cam;
    float turnSmoothVelocity;
    
    private bool isGrounded;
    [SerializeField] private LayerMask groundMask;
    float groundCheckDistance = 0.1f;

    Vector3 moveVector;
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    public Animator anim;
    public float speedFactor = 1;
    Interactable focus;

    int layerMask = 1 << 8;
    System.Random rand;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        layerMask = ~layerMask;
        rand = new System.Random();
    }
    
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else
            {
                Walk();
            }
            controller.Move(moveDir.normalized*speed*speedFactor*Time.deltaTime);
            
        }
        else 
        {
            Idle();
        }

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Attack());
        }

        //Interact
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 10000, layerMask)) //100 before layermask
            {
                Debug.Log(hit.collider.gameObject);
                Interactable obj = hit.collider.GetComponent<Interactable>();
                
              
                if (obj != null)
                {
                    Debug.Log(obj);
                    SetFocus(obj);
                }
            }
        }

        //Hit

        if (Input.GetKey(KeyCode.Escape))
            if(Cursor.lockState == CursorLockMode.None)
                Cursor.lockState = CursorLockMode.Locked;
            else
                Cursor.lockState = CursorLockMode.None;

    }

    void SetFocus(Interactable newFocus)
    {
        focus = newFocus;
        focus.Interact();
    }

    

    private void Walk()
    {
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
        speedFactor = 1;

    }

    private void Run()
    {
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
        speedFactor = 2f;
 
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
        speedFactor = 1;
  
    }

    private IEnumerator Attack()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 1);
        anim.SetTrigger("Attack");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            if(hit.collider.tag == "tree")
            {
                GameObject treeGameObj = hit.collider.gameObject;
                Tree tree = treeGameObj.GetComponent<Tree>();
                
                tree.HP -= 10;
                if(tree.HP <= 0)
                {
                    Destroy(treeGameObj);
                    
                    SpawnManager.instance.SpawnWood(treeGameObj.transform, rand.Next(1,5));
                }
            }

        }

        yield return new WaitForSeconds(0.9f);
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 0);
    }
    
}
