using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace R2
{
    public class Patrol : MonoBehaviour
    {
        public Transform[] patrolPoints;

        private int currentPoint;
        public float moveSpeed;

        private Animator anim;

        public bool usesAnimator = true;

        // Start is called before the first frame update
        void Start()
        {
            if (usesAnimator)
            {
                anim = gameObject.GetComponent<Animator>();
            }
            transform.position = patrolPoints[0].position;
            currentPoint = 0;
        }


        // Update is called once per frame
        void Update()
        {

            if (transform.position == patrolPoints[currentPoint].position)
            {
                currentPoint++;
            }

            if (currentPoint >= patrolPoints.Length)
            {
                currentPoint = 0;
            }

            if (usesAnimator)
            {
                anim.SetFloat("forward", .9f);
            }
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
        }
        void OnCollisionEnter(Collision other)
        {
            Debug.Log("BULLET KEK");
            if (other.transform.tag == "Bullet")
            {
                Destroy(other.gameObject, 0.1f);
                Debug.Log("OSUTTIIN");
                Destroy(gameObject, 0.1f);
            }
        }



    }



}
