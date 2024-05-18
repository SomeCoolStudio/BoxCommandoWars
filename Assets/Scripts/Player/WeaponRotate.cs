using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponRotate : MonoBehaviour
{

    [SerializeField]
    private float offset;

    [SerializeField]
    private Transform playerTransform;



    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);

        Vector2 scale = transform.localScale;

        if (Mathf.Abs(rotation_z) > 90)
        {

            scale.y = -1;
            playerTransform.transform.localRotation = Quaternion.Euler(0f, 180, 0f);
        }
        else if (Mathf.Abs(rotation_z) < 90)
        {
            scale.y = 1;
            playerTransform.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        transform.localScale = scale;
    }
}
