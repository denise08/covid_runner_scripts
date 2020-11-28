using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;

    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

    //public float speed;
    //public bool MoveRight;

    //// Use this for initialization
    //void Update()
    //{
    //    //if (transform.position.x > 4f)
    //    //{
    //    //    MoveRight = false;
    //    //}

    //    //if (transform.position.x < -4f)
    //    //{
    //    //    MoveRight = true;
    //    //}

    //    if (MoveRight)
    //    {
    //        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);

    //    }
    //    else
    //    {
    //        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    //    }

    //    Debug.Log(MoveRight);

    //}
    //void OnTriggerEnter2D(Collider2D trig)
    //{
    //    Debug.Log("Entered trigger");

    //    if (trig.gameObject.CompareTag("Platform"))
    //    {
    //        Debug.Log("platform check");
    //        if (MoveRight)
    //        {
    //            MoveRight = false;
    //        }
    //        else
    //        {
    //            MoveRight = true;
    //        }
    //    }
    //}
}
