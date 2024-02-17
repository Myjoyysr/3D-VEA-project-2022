using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBounce : MonoBehaviour
{
    public GameObject cube;
    public float height;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
      public void Update()
      {
          float y = (Mathf.Sin(Time.time * speed + (transform.position.x * 10 + transform.position.z * 10)) * height);
          cube.transform.position = new Vector3(transform.position.x, ( gameObject.transform.parent.position.y+y), transform.position.z);
      }
}
