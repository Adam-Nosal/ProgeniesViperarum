using UnityEngine;
using System.Collections;
using Helpers;

public class BulletController : MonoBehaviour {

    [SerializeField]
    private float speed = 25.0f;
    [SerializeField]
    private Vector3 destination;
    private bool move = false;

	// Use this for initialization
	public void Shoot(Vector3 originDestination) {
        destination = originDestination;
        move = true;

	}
	
	// Update is called once per frame
	void Update () {
        if (move)
            this.transform.Translate(destination * speed * Time.deltaTime, Space.World);
    }


    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void OnCollision2D(Collider2D other)
    {
        if(other.gameObject.tag == TagHelper.EnemyTag)
        {

        }
    }


}
