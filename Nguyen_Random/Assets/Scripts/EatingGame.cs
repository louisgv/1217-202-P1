using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: LAB <lab@mail.rit.edu>
/// Description: Behavior of a eating game, with score tracking and trigger detector
/// Restriction: N/A
/// </summary>
public class EatingGame : MonoBehaviour {

    private int score = 0;

    public List<GameObject> listOfExplosionPrefabs;

    public int explosionTimeout = 5;

    public int flyingTimeout = 5;

    public float flyingForce = 3000f;

    /// <summary>
    /// Detect trigger and kick them up to the sky
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.AddComponent<Rigidbody>();

        var otherRigidBody = other.gameObject.GetComponent<Rigidbody>();

        other.isTrigger = false;

        otherRigidBody.isKinematic = false;

        otherRigidBody.AddForce(Vector3.up * flyingForce);

        score++;

        StartCoroutine(ExplosionDelayed(other.gameObject));
    }

    /// <summary>
    /// Wait for the object to fly up some height to explode
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    private IEnumerator ExplosionDelayed(GameObject other)
    {
        yield return new WaitForSeconds(flyingTimeout);

        var randomExplosion = listOfExplosionPrefabs[UnityEngine.Random.Range(0, listOfExplosionPrefabs.Count)];

        var randomExplosionInstance = Instantiate(randomExplosion, other.transform.position, Quaternion.identity);

        Destroy(randomExplosionInstance, explosionTimeout);

        Destroy(other.gameObject);
    }

    /// <summary>
    /// Showing score and winning text
    /// </summary>
    private void OnGUI()
    {
        if (score == 162)
        {
            GUI.Box(new Rect(10, Screen.height - 64, 180, 54), "GREAT JOB! THEY ARE ALL SMOKED!");
        } else
        {
            GUI.Box(new Rect(10, Screen.height - 64, 180, 54), "SMOKE'EM ALL\nScore:\n" + score + "/162");
        }
    }
}
