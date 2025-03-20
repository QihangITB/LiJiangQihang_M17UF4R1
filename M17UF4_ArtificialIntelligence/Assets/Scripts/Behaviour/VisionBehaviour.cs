using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VisionBehaviour : MonoBehaviour
{
    private const float Half = 2f;
    public float VisionAngle = 90f;

    private void Update()
    {
        DrawVisionLines();
    }

    public bool IsInVision(GameObject player)
    {
        Vector3 directionToPlayer = player.transform.position - transform.position;
        directionToPlayer.y = 0;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        // Si el jugador está dentro del ángulo de visión
        if (angleToPlayer <= VisionAngle / Half)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToPlayer.normalized, out hit))
            {
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
        SphereCollider _sC = gameObject.GetComponentInChildren<SphereCollider>();

        Vector3 leftDirection = Quaternion.Euler(0, -45, 0) * transform.forward;
        Vector3 rightDirection = Quaternion.Euler(0, 45, 0) * transform.forward;

        Debug.DrawRay(transform.position, leftDirection * _sC.radius, Color.red);
        Debug.DrawRay(transform.position, rightDirection * _sC.radius, Color.red);
    }
}
