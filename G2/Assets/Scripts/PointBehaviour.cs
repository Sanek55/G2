using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBehaviour : MonoBehaviour
{
    private LineManager lineManager;
    public int pointID;
    public Vector3 offset; // �������� ����� ����� � ��������
    private Camera mainCamera;


    public float yCord = -5f;

    private void Awake()
    {
        mainCamera = Camera.main; // �������� �������� ������
        lineManager = FindObjectOfType<LineManager>();
    }
    private void OnMouseDown()
    {
        // ��������� �������� ����� �������� ������� � �������� ����
        Vector3 mousePosition = GetMouseWorldPosition();
        offset = transform.position - mousePosition;
    }
    private void OnMouseDrag()
    {
        // ��������� ������� ������� �� ����� ��������������
        Vector3 mousePosition = GetMouseWorldPosition();
        transform.position = new Vector3(mousePosition.x, yCord, mousePosition.z) + offset;
        lineManager.points[pointID] = transform.position;

    }
    public Vector3 GetMouseWorldPosition()
    {
        // �������� ������� ������� ����
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = mainCamera.WorldToScreenPoint(transform.position).z; // ��������� �������
        return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }       
}
