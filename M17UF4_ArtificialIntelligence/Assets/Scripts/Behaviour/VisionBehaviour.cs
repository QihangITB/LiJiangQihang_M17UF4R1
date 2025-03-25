using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VisionBehaviour : MonoBehaviour
{
    const float Half = 2f;

    public Transform VisionLine;
    public float VisionAngle = 90f;

    private SphereCollider _sC;

    private void Start()
    {
        _sC = gameObject.GetComponentInChildren<SphereCollider>();
    }

    private void Update()
    {
        DrawVisionLines();
    }

    public bool IsInVision(GameObject player)
    {
        Vector3 origin = transform.position;
        Vector3 destiny = player.transform.position;
        origin.y = destiny.y = VisionLine.position.y;

        Vector3 directionToPlayer = destiny - origin;

        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        Debug.DrawRay(origin, directionToPlayer * _sC.radius ,Color.yellow);

        if (angleToPlayer <= VisionAngle / Half)
        {
            RaycastHit hit;
            if (Physics.Raycast(origin, directionToPlayer, out hit, _sC.radius))
            {
                Debug.Log("Collisiona con: " + hit.collider.tag);
                if (hit.collider.CompareTag(player.tag))
                {
                    return true;
                }
            }
        }
        return false;
    }

    void DrawVisionLines()
    {
        Vector3 leftDirection = Quaternion.Euler(0, -(VisionAngle/Half), 0) * transform.forward;
        Vector3 rightDirection = Quaternion.Euler(0, (VisionAngle / Half), 0) * transform.forward;

        Debug.DrawRay(transform.position, leftDirection * _sC.radius, Color.red);
        Debug.DrawRay(transform.position, rightDirection * _sC.radius, Color.red);
    }
}
