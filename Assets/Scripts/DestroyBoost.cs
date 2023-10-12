using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoost : MonoBehaviour
{
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // ���� ������ ������ ����� ��� "Enemy"
        {
            Destroy(this.gameObject); // ���������� ������ ������
            BoostSpawner._isBoostExist = false;
        }
    }
}