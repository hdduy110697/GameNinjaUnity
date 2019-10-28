using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothTimeX, smoothTimeY;
    public Vector2 velocity;

    public GameObject player;

    public Vector2 minPos, maxPos;
    public bool bound;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posx;
        float posy;
        //thi.: vi tri camera, player.: vi tri player, ref: ket noi lay cua player sang camera, thoi gian tri hoan
        if (player == null)
        {
            posx =this.transform.position.x;
            posy = this.transform.position.y;
        }
        else
        {
             posx = Mathf.SmoothDamp(this.transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
             posy = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
        }
     
        //set camera theo nhan vat
        transform.position = new Vector3(posx, posy, transform.position.z);


        if (bound)
        {
            //clamp: de gioi han vi tri duoc gioi han boi clamp
            transform.position = new Vector3 (Mathf.Clamp(transform.position.x, minPos.x, maxPos.x),
                Mathf.Clamp(transform.position.y, minPos.y, maxPos.y),
                Mathf.Clamp(transform.position.z, transform.position.z, transform.position.z)
                );
        }
    }
}
