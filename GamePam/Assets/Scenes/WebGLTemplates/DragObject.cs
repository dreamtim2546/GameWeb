using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] bool isDragging = false;
    private Vector3 initialPosition;
    [SerializeField] int currentSnapIndex = -1; // ���˹� Snap Point �Ѩ�غѹ

    [SerializeField] GameManager gameManager;

    private void Start()
    {
        initialPosition = transform.position; // �ѹ�֡���˹�������鹢ͧ Object
    }


    void OnMouseDown()
    {
       
        if (gameManager.isCheck == false)
        {
            OnDrangDown();
        }

    }

    void OnMouseUp()
    {

        if (gameManager.isCheck == false)
        {
            OnDrangUp();
        }
       
    }

    void Update()
    {
        

        // �Ѿവ���˹�੾������͡��ѧ Drag

        OnDrang();



    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void SnapToNearestPoint()
    {
        // �� SnapManager �Ҩش�����ҧ���������ش
        int nearestIndex = SnapManager.Instance.GetNearestAvailableSnapPointIndex(transform.position, 1.0f);

        if (nearestIndex != -1) // ����Ҩش������������
        {
            Transform snapPoint = SnapManager.Instance.GetSnapPointTransform(nearestIndex);
            transform.position = snapPoint.position;

            // �ͧ�ش Snap
            SnapManager.Instance.OccupySnapPoint(nearestIndex);
            currentSnapIndex = nearestIndex;
        }
        else
        {
            // �������ըش��ҧ���������� �駡�Ѻ���˹��������
            transform.position = initialPosition;
        }
    }
    private void OnDrangDown()
    {
       
        offset = transform.position - GetMouseWorldPosition();
        isDragging = true;

        // �Ŵ��͡�ش Snap �Ѩ�غѹ (�����)
        if (currentSnapIndex != -1)
        {
            SnapManager.Instance.ReleaseSnapPoint(currentSnapIndex);
            currentSnapIndex = -1;
        }
        AudioManager.Instance.PlaySound("Button");
    }
    private void OnDrangUp()
    {
        isDragging = false;
        SnapToNearestPoint(); // ���¡�ѧ��ѹ�Ѻ Object 仵Դ�ش
        AudioManager.Instance.PlaySound("Button");
    }
    private void OnDrang()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

}