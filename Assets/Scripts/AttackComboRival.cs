using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComboRival : MonoBehaviour, IAttack {

    public float rotationSpeed = 10;
    public Material[] telegraphColours;
    public Transform boss;
    public Renderer dangerZone;
    public float pauseTime = 1.0f;

    void Start() {
        dangerZone.enabled = true;
        dangerZone.sharedMaterial = telegraphColours[0];
    }

    public IEnumerator Attack () {
        float rotation = 180.0f;
        dangerZone.sharedMaterial = telegraphColours [1];
        yield return new WaitForSeconds (0.5f);

        while (rotation > 0.0f) {
            dangerZone.sharedMaterial = telegraphColours [1];
            rotation -= rotationSpeed * Time.deltaTime;
            boss.transform.localRotation = Quaternion.Euler (0.0f, rotation, 0.0f);
            yield return null;
            dangerZone.sharedMaterial = telegraphColours [0];
        }

        yield return new WaitForSeconds(pauseTime);

        while (rotation < 180.0f) {
            dangerZone.sharedMaterial = telegraphColours [1];
            rotation += rotationSpeed * Time.deltaTime;
            boss.transform.localRotation = Quaternion.Euler (0.0f, rotation, 0.0f);
            yield return null;
            dangerZone.sharedMaterial = telegraphColours [0];
        }

        yield return new WaitForSeconds(pauseTime);

        while (rotation > 0.0f) {
            dangerZone.sharedMaterial = telegraphColours [1];
            rotation -= rotationSpeed * Time.deltaTime;
            boss.transform.localRotation = Quaternion.Euler (0.0f, rotation, 0.0f);
            yield return null;
            dangerZone.sharedMaterial = telegraphColours [0];
        }

        boss.transform.localRotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);

    }
}
