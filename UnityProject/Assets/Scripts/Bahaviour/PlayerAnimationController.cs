using UnityEngine;
using System.Collections;
using Helpers;

public class PlayerAnimationController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private Animator mAnimator;

    #endregion

    #region Variables
    #endregion

    #region Public Geters
    #endregion



    void Awake()
    {
        InitVariables();
        PlayIdleAnimation();
    }


    #region Private Methods

    private void InitVariables()
    {
        if (mAnimator == null)
            mAnimator = this.GetComponent<Animator>();


    }

    #endregion

    #region Public Methods


    public void PlayReloadAnimation(bool origin)
    {
         mAnimator.SetBool(PlayerAnimatorHelper.PLAYER_IS_RELOADING_PARAM, true);
    }

    public void PlayShootAnimation(bool origin)
    {
         mAnimator.SetBool(PlayerAnimatorHelper.PLAYER_IS_SHOOTING_PARAM, true);
    }

    public void PlayIdleAnimation(){

              mAnimator.SetBool(PlayerAnimatorHelper.PLAYER_IS_SHOOTING_PARAM, false);
             mAnimator.SetBool(PlayerAnimatorHelper.PLAYER_IS_RELOADING_PARAM, false);
    }

    public void PlayWalkAnimation(float velocity)
    {
        mAnimator.SetFloat(PlayerAnimatorHelper.PLAYER_VELOCITY_PARAM, velocity);
    }

    #endregion

}
