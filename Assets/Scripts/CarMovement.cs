using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarMovement : MonoBehaviour
{
    public Transform[] waypoints; // Define waypoints in the Inspector
    public float speed = 5f; // Speed of the car

    private int currentWaypointIndex = 0;

    void Update()
    {
        if (waypoints.Length == 0) return;

        // Целевая точка пути с добавленным смещением по оси Y
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 targetPositionWithOffset = new Vector3(targetWaypoint.position.x, targetWaypoint.position.y + 5f, targetWaypoint.position.z);

        // Рассчитываем направление к целевой точке
        Vector3 direction = (targetPositionWithOffset - transform.position).normalized;

        // Перемещаем машину
        transform.position += direction * speed * Time.deltaTime;

        // Проверка на достижение точки пути с учётом смещения по оси Y
        if (Vector3.Distance(transform.position, targetPositionWithOffset) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

}

