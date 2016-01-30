using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class ExtendedMath 
{
    public static float Tau { get { return 6.2831853f; } }

    public static float InvertValue(float value) { return value * -1; }

    public static int GetTriangle(IntPoint xy, IntPoint gridSize, int numberOfTris, int triModifier) { return (((xy.y * gridSize.x) + xy.x) * (numberOfTris/3)) + triModifier; }

    public static IntPoint DistanceIntervals(Vector2 end, Vector2 start, Vector2 distanceOfMeasurement) { return new IntPoint((int)((end.x - start.x) / (distanceOfMeasurement.x)), (int)((end.y - start.y) / (distanceOfMeasurement.y))); }

    public static IntPoint DistanceIntervals(IntPoint end, IntPoint start, IntPoint distanceOfMeasurement) { return new IntPoint((int)((end.x - start.x) / (distanceOfMeasurement.x)), (int)((end.y - start.y) / (distanceOfMeasurement.y))); }

    public static float NormRand () { return UnityEngine.Random.Range(0f, 1f); }

    public static float Interpolate(float y1, float y2, float mutate) { return (y1 * (1 - mutate) + y2 * mutate); }

    public static float RescaleValue(float rescaleVal, float newMin, float newMax, float oldMin, float oldMax) { return (float)(((rescaleVal - oldMin) * (newMax - newMin)) / (oldMax - oldMin)) + newMin; }

    public static float DistanceEuclidaen(Vector3 From, Vector3 To) { return Mathf.Sqrt(Mathf.Pow(From.x - To.x, 2) + Mathf.Pow(From.y - To.y, 2) + Mathf.Pow(From.z - To.z, 2)); }

    public static float DistanceManhattan(Vector2 one, Vector2 two) { return Mathf.Abs(one.x - two.x) + Mathf.Abs(one.y - two.y); }

    public static float DistanceChebyshev(Vector2 one, Vector2 two) { return Mathf.Max(Mathf.Abs(one.x - two.x), Mathf.Abs(one.y - two.y)); }

    public static float DistancePerpedicularLine(Vector2 LineStart, Vector2 arbitraryPoint, float n) { return ((LineStart - arbitraryPoint) - ((LineStart - arbitraryPoint) * n)).sqrMagnitude; }

    public static bool PointWithinCircle(Vector2 circleCenter, Vector2 testPoint, float radius) { return (Mathf.Pow((circleCenter.x - testPoint.x), 2) + Mathf.Pow((circleCenter.y - testPoint.y), 2) <= Mathf.Pow(radius, 2)); }

	public static float CosineOfTwoVectors(Vector3 one, Vector3 two) { return Vector3.Dot(one, two)/(one.magnitude * two.magnitude); }

	public static float SineOfTwoVectors(Vector3 one, Vector3 two) { return Vector3.Cross(one, two).magnitude/(one.magnitude * two.magnitude); }

	public static float AngleBetweenVectorsRadians(Vector3 thisPos, Vector3 target)	{ return Mathf.Atan2(target.y - thisPos.y, target.x - thisPos.x); }

	public static float AngleBetweenVectorsDegrees(Vector3 thisPos, Vector3 target) { return AngleBetweenVectorsRadians(thisPos, target) * Mathf.Rad2Deg; }	

	public static Vector2 OrbitAtDistRad(Vector2 centerPoint, float angleInRad, float radius)
	{
		float cosTheta = Mathf.Cos(angleInRad);
		float sinTheta = Mathf.Sin(angleInRad);
		return new Vector2(centerPoint.x + (radius * cosTheta), centerPoint.y + (radius * sinTheta));
	}

	public static Vector2 OrbitAtDistDeg(Vector2 centerPoint, float angleInDegrees, float radius)
	{
		float radAngle = angleInDegrees * Mathf.Deg2Rad;		
		return OrbitAtDistRad(centerPoint, radAngle, radius);
	}

	public static Vector2 StaticOrbit(Vector2 pointToRotate, Vector2 centerPoint, float angleInDegrees)
	{
		float radAngle = angleInDegrees * Mathf.Deg2Rad;
		float cosTheta = Mathf.Cos(radAngle);
		float sinTheta = Mathf.Sin(radAngle);
		return new Vector2(
			cosTheta * (pointToRotate.x - centerPoint.x) - sinTheta * (pointToRotate.y - centerPoint.y) + centerPoint.x,
			sinTheta * (pointToRotate.x - centerPoint.x) + cosTheta * (pointToRotate.y - centerPoint.y) + centerPoint.y);
	}
}
