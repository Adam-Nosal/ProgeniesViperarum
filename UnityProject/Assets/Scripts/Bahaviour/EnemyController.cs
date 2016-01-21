using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    bool isDead = false;
    bool isAttacking = false;

    [Header("Controllers")]
    [SerializeField]
    private EnemyAnimationController mAnimationController;

    [Header("Movement")]
    [SerializeField]
    Transform targetTransform;
    [SerializeField]
    float moveSpeed = 3.0f;
    [SerializeField]
    float rotationSpeed = 3.0f;
    
    [SerializeField]
    float activityRange = 50.0f;
    [SerializeField]
    float stopRange = 10.25f;

    [Header("Stats")]
    [SerializeField]
    int health = 50;

    private Transform mTransform;
    void Awake()
    {
        mTransform = transform;
    }

    void Start()
    {
        targetTransform = GameObject.FindWithTag("Player").transform;

    }

    void Update()
    {
        float distance = Vector2.Distance(mTransform.position, targetTransform.position);

        Debug.Log("Enemy " + gameObject.GetInstanceID() + " distance to target " + distance);



        if (distance <= activityRange && distance > stopRange)
        {
            Debug.Log("Enemy " + gameObject.GetInstanceID() + " moving");
            mTransform.position += mTransform.up * moveSpeed * Time.deltaTime;
            mAnimationController.PlayWalkAnimation();
        }
        else if (distance <= stopRange)
        {
            mAnimationController.PlayAttackAnimation();
        }

        LookAtTarget();
    }

    private void LookAtTarget()
    {

        Vector3 diff = targetTransform.position - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        Quaternion lQuaternion = Quaternion.Euler(0f, 0f, rot_z -90.0f);

       // float lookRotation;
        //Quaternion lQuaternion;
        //lookRotation = Quaternion.LookRotation(targetTransform.position - mTransform.position).eulerAngles.z;
       // lQuaternion = new Quaternion();
        //lQuaternion.eulerAngles = new Vector3(0.0f, 0.0f, lookRotation);

        mTransform.rotation = Quaternion.Slerp(mTransform.rotation, lQuaternion, rotationSpeed * Time.deltaTime);
    }

    void Die()
    {
        mAnimationController.PlayDeadAnimation();
    }
}
