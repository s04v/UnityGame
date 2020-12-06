using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Math
{
    public static Vector2 RandomVector2(Vector2 min, Vector2 max)
    {
        return new Vector2(UnityEngine.Random.Range(min.x, max.x), UnityEngine.Random.Range(min.y, min.y));
    }

    public static Vector2 RandomPos(Vector2 min, Vector2 max)
    {
        Vector2 randomDirection = RandomDirection();

        Vector2 randomPosition = RandomVector2(min, max);
        randomDirection = Vector2.Scale(randomDirection, randomPosition);

        return randomDirection;
    }

    public static Vector2 RandomPos(Vector2 min, Vector2 max, Vector2 direction)
    {
        Vector2 randomPosition = RandomVector2(min, max);
        direction = Vector2.Scale(direction, randomPosition);

        return direction;
    }

    public static Vector2 RandomDirection()
    {
        Vector2 randomDirection = Random.insideUnitCircle;
        randomDirection.Normalize();

        return randomDirection;
    }
}
