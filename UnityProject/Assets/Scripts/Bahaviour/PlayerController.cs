using UnityEngine;
using CnControls;
using System.Collections;
using Helpers;

public class PlayerController : MonoBehaviour
{

    #region Editor Variables
    [Header("Controllers")]
    [SerializeField]
    private PlayerAnimationController mAnimationController;
    [SerializeField]
    private Rigidbody2D mRigidbody2d;
    [SerializeField]
    private Transform mTransform;

    [Header("Movement")]
    [SerializeField]
    [Range(5.0f,15.0f)]
    private float Speed = 7.5f;

    #endregion


    #region Variables
    public Vector3 lookVector;
    public Vector3 destinationRotation;
    #endregion

    #region Public Geters
    #endregion


    void Awake()
    {
        InitVariables();
    }



    void Update()
    {
        mRigidbody2d.velocity = new Vector2(CnInputManager.GetAxis(InputHelper.MOVE_JOYSTICK_HORIZONTAL)*Speed,
                                            CnInputManager.GetAxis(InputHelper.MOVE_JOYSTICK_VERTICAL) * Speed);

        lookVector = new Vector3(CnInputManager.GetAxis(InputHelper.LOOK_JOYSTICK_HORIZONTAL) ,
                                            CnInputManager.GetAxis(InputHelper.LOOK_JOYSTICK_VERTICAL) ,0.0f);

        destinationRotation = Quaternion.FromToRotation(transform.position, lookVector).eulerAngles;
        destinationRotation.x = 0.0f;
        destinationRotation.y = 0.0f;
        mTransform.rotation = Quaternion.Euler(destinationRotation);



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


    #region Private Methods

    private void InitVariables()
    {

        if (mAnimationController == null)
            mAnimationController = this.GetComponent<PlayerAnimationController>();
        if (mRigidbody2d == null)
            mRigidbody2d = this.GetComponent<Rigidbody2D>();
        if (mTransform == null)
            mTransform = this.GetComponent<Transform>();
    }

    #endregion



    #region Public Methods


    #endregion

}
