using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private bool isCameraLocked = false;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;
    private int scrollMultiplier = 250;
    private float minY = 10f;
    private float maxY = 80f;

    // Update is called once per frame
    void Update () {
        // Toggle isCameraLocked
        if (Input.GetKeyDown(KeyCode.Space)) {
            isCameraLocked = !isCameraLocked;
            if (isCameraLocked) { Debug.Log("Locked"); }
            if (!isCameraLocked) { Debug.Log("Unlocked"); }
        }

        if (isCameraLocked) {
            return;
        }

		if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness) {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        // Zooming in and out with mouse scrollwheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * scrollMultiplier * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
