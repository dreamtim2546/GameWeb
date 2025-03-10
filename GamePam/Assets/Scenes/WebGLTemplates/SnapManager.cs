using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapManager : MonoBehaviour
{
    public static SnapManager Instance; 

    [SerializeField]
    private List<Transform> snapPoints; // �ش��͡������㹩ҡ
    private List<bool> snapPointOccupied; // ʶҹС�èͧ�ش��͡

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // ��˹�ʶҹ�������鹢ͧ�ش��͡������
        snapPointOccupied = new List<bool>(new bool[snapPoints.Count]);
    }

    // �ѧ��ѹ��Ǩ�Ҩش��͡�����ҧ���������ش
    public int GetNearestAvailableSnapPointIndex(Vector3 position, float maxDistance)
    {
        int nearestIndex = -1;
        float nearestDistance = float.MaxValue;

        for (int i = 0; i < snapPoints.Count; i++)
        {
            if (!snapPointOccupied[i]) // ��Ǩ�ͺ��Ҩش����ѧ��ҧ����
            {
                float distance = Vector2.Distance(position, snapPoints[i].position);
                if (distance < nearestDistance && distance <= maxDistance)
                {
                    nearestDistance = distance;
                    nearestIndex = i;
                }
            }
        }

        return nearestIndex; // �������ըش��ҧ���������� �Ф׹��� -1
    }

    // �ѧ��ѹ�ͧ�ش��͡
    public void OccupySnapPoint(int index)
    {
        if (index >= 0 && index < snapPoints.Count)
        {
            snapPointOccupied[index] = true;
        }
    }

    // �ѧ��ѹ�Ŵ�ͧ�ش��͡
    public void ReleaseSnapPoint(int index)
    {
        if (index >= 0 && index < snapPoints.Count)
        {
            snapPointOccupied[index] = false;
        }
    }

    // �׹���˹� Transform �ͧ snapPoint ��� index
    public Transform GetSnapPointTransform(int index)
    {
        if (index >= 0 && index < snapPoints.Count)
        {
            return snapPoints[index];
        }

        return null;
    }
}
