using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public GameObject EntityToFollow;

    void Start()
    {

    }

    void Update()
    {
        var toFollow = EntityToFollow.transform;
        transform.position = new Vector3(toFollow.position.x, toFollow.position.y, -10);
        var size = GetComponent<Camera>().orthographicSize;
        //GetComponent<Camera>().orthographicSize -= GetComponent<Camera>().orthographicSize * 3f;
        GetComponent<Camera>().orthographicSize = Mathf.Clamp(GetComponent<Camera>().orthographicSize, 7f, 7f);
    }
}
