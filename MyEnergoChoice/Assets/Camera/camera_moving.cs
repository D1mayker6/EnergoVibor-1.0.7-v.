using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class camera_moving : MonoBehaviour
{
    private float LeftLimit = -60f;
    private float RightLimit = 20f;
    private float UpLimit = 37f;
    private float DownLimit = -17f;
    private float SpeedMoving = 60f;
    public Vector3 CenterPos = new Vector3(-20.4f, 6.5f, -171.7803f);
    void Update()
    {
        float scrollweeel = Input.GetAxis("Mouse ScrollWheel");
        if (Input.GetKey(KeyCode.W))
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * SpeedMoving);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * SpeedMoving);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * SpeedMoving);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * SpeedMoving);
        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, LeftLimit, RightLimit),
            Mathf.Clamp(transform.position.y, DownLimit, UpLimit),
            transform.position.z
            );
        if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.position = CenterPos;
        }
    }

}
