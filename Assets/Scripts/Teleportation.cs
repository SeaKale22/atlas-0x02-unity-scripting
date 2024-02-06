using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public GameObject player;
    public GameObject teleTwin;
    [SerializeField] private float cooldownDuration;
    bool isOnCooldown = false;
    void OnTriggerEnter(Collider other)
    {
        if (!isOnCooldown)
        {
            Teleportation teleTwinScript = teleTwin.GetComponent<Teleportation>();
            TeleportPlayer();
            Debug.Log("Teleported!");
            StartCoroutine(teleTwinScript.CoolDown(cooldownDuration));
            StartCoroutine(CoolDown(cooldownDuration));
        }
        else
        {
            Debug.Log("Teleports are on cooldown!");
        }
    }

    IEnumerator CoolDown (float duration)
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(duration);
        isOnCooldown = false;
    }
    void TeleportPlayer()
    {
        float targetX = teleTwin.transform.position.x;
        float targetZ = teleTwin.transform.position.z;

        Vector3 targetPosition = new Vector3(targetX, player.transform.position.y, targetZ);
        player.transform.position = targetPosition;
    }
}
