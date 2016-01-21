using UnityEngine;
using CnControls;
using System.Collections;
using Helpers;

public class PlayerController : MonoBehaviour
{

 
    [Header("Controllers")]
    [SerializeField]
    private PlayerAnimationController mAnimationController;
    [SerializeField]
    private Rigidbody2D mRigidbody2d;
    
    private Transform mTransform;

    [Header("Joysticks")]
    [SerializeField]
    private SimpleJoystick movementJoy;
    [SerializeField]
    private SimpleJoystick lookJoy;

    [Header("Prefabs")]
    [SerializeField]
    private GameObject bulletPrefab;

    [Header("Movement")]
    [SerializeField]
    [Range(5.0f,15.0f)]
    private float speed = 7.5f;
    [SerializeField]
    private Transform bulletSpawn;

 


    
    public Vector3 lookVector;
    public Vector3 destinationRotation;
 



    void Awake()
    {
        InitVariables();
        lookJoy.OnDragDelegate += LookJoystickMoved;
            
    }

    private void LookJoystickMoved(float vertical, float horizontal)
    {
        Vector3 diff = new Vector3(horizontal,vertical) - mTransform.position;
        diff.Normalize();

        float zAxisRotation = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        Quaternion bulletRotation = new Quaternion();
        bulletRotation.eulerAngles = new Vector3(0f,0f, zAxisRotation);

        GameObject bullet = (GameObject) Instantiate(bulletPrefab, bulletSpawn.position, bulletRotation);
        bullet.GetComponent<BulletController>().Shoot(new Vector3( horizontal, vertical,  0f));
    }


    void Update()
    {
        mRigidbody2d.velocity = new Vector2(CnInputManager.GetAxis(InputHelper.MOVE_JOYSTICK_HORIZONTAL)*speed,
                                            CnInputManager.GetAxis(InputHelper.MOVE_JOYSTICK_VERTICAL) * speed);

        lookVector = new Vector3(CnInputManager.GetAxis(InputHelper.LOOK_JOYSTICK_HORIZONTAL) ,
                                            CnInputManager.GetAxis(InputHelper.LOOK_JOYSTICK_VERTICAL) ,0.0f);

        Vector3 diff = lookVector - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z );
        

        //animation handling
        if (mRigidbody2d.velocity.x > 0 )
            mAnimationController.PlayWalkAnimation(mRigidbody2d.velocity.x);
        else
        if ( mRigidbody2d.velocity.y > 0)
            mAnimationController.PlayWalkAnimation(mRigidbody2d.velocity.y);
        else
            mAnimationController.PlayWalkAnimation(0.0f);
        //TODO: implement different walk animation speed if player speed is high 
    
    }


 

    private void InitVariables()
    {

        if (mAnimationController == null)
            mAnimationController = this.GetComponent<PlayerAnimationController>();
        if (mRigidbody2d == null)
            mRigidbody2d = this.GetComponent<Rigidbody2D>();
        if (mTransform == null)
            mTransform = this.GetComponent<Transform>();
    }





}
