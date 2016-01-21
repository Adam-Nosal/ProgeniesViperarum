using UnityEngine;
using System.Collections;
using Helpers;

public class EnemyAnimationController : MonoBehaviour
{

    [SerializeField]
    private Animator mAnimator;


    // Use this for initialization
    void Awake()
    {
       mAnimator =  gameObject.GetComponent<Animator>();
    }
    


    public void PlayWalkAnimation()
    {
        mAnimator.SetBool(AnimatorHelper.ENEMY_IS_ATTACKING_PARAM, false);
        mAnimator.SetBool(AnimatorHelper.ENEMY_IS_DEAD_PARAM, false);

    }
    public void PlayDeadAnimation()
    {
        mAnimator.SetBool(AnimatorHelper.ENEMY_IS_DEAD_PARAM, true);

    }
    public void PlayAttackAnimation()
    {
        mAnimator.SetBool(AnimatorHelper.ENEMY_IS_ATTACKING_PARAM,true);

    }
}

