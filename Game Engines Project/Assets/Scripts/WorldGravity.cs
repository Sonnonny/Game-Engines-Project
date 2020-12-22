using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGravity : MonoBehaviour
{
    public float gravity = -100;

    public void Attract(Transform playerTransform)
    {

        //Debug.Log("hello2");

        Vector3 gravityUp = (playerTransform.position - new Vector3(transform.position.x, transform.position.y + 10, transform.position.z)).normalized;
        Vector3 localUp = playerTransform.up;

        playerTransform.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * playerTransform.rotation;
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, 50f * Time.deltaTime);
    }
}
