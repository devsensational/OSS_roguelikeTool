using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveManager : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;
    private Vector3 targetPosition;

    void Start()
    {

    }

    void Update()
    {
        if (target.gameObject != null)
        {
            // this�� ī�޶� �ǹ� (z���� ī�޶��� �״�� ����)
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);

            // vectorA -> B���� T�� �ӵ��� �̵�
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
