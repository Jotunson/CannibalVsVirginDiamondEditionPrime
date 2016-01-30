using UnityEngine;
using System.Collections;

public class IntPoint : Object
{
	protected int X, Y;
    public IntPoint() : base() {}
	public IntPoint(int x, int y) : base() {this.X = x;	this.Y = y;}
    public IntPoint(IntPoint xy) : base() { this.X = xy.x; this.Y = xy.y; }

	public int x {get{return X;} set{X = value;}}
	public int y {get{return Y;} set{Y = value;}}

    public override int GetHashCode() { return x ^ y; }
    public static IntPoint operator +(IntPoint i1, IntPoint i2){return new IntPoint(i1.x + i2.x, i1.y + i2.y);}
    public static IntPoint operator -(IntPoint i1, IntPoint i2){return new IntPoint(i1.x - i2.x, i1.y - i2.y);}
    public static IntPoint operator *(IntPoint i1, IntPoint i2) { return new IntPoint(i1.x * i2.x, i1.y * i2.y); }
    public static IntPoint operator /(IntPoint i1, IntPoint i2) { return new IntPoint(i1.x / i2.x, i1.y / i2.y); }
    public static IntPoint operator +(IntPoint i1, int i2) { return new IntPoint(i1.x + i2, i1.y + i2); }
    public static IntPoint operator -(IntPoint i1, int i2) { return new IntPoint(i1.x - i2, i1.y - i2); }
    public static IntPoint operator *(IntPoint i1, int i2) { return new IntPoint(i1.x * i2, i1.y * i2); }
    public static IntPoint operator /(IntPoint i1, int i2) { return new IntPoint(i1.x / i2, i1.y / i2); }
    public static bool operator >(IntPoint i1, IntPoint i2) {return (i1.x > i2.x & i1.y > i2.y ? true : false); }
    public static bool operator <(IntPoint i1, IntPoint i2) { return (i1.x < i2.x & i1.y < i2.y ? true : false); }
    public static bool operator <(IntPoint i1, int i2) { return (i1.x < i2 & i1.y < i2 ? true : false); }
    public static bool operator >(IntPoint i1, int i2) { return (i1.x > i2 & i1.y > i2 ? true : false); }
    public static bool operator !=(IntPoint i1, IntPoint i2) { return !((i2.x == i1.x) & (i2.y == i1.y)); }
    public static bool operator ==(IntPoint i1, IntPoint i2)
    {
        if (System.Object.ReferenceEquals(i1, i2))
        {
            return true;
        }

        if (((object)i1 == null) || ((object)i2 == null))
        {
            return false;
        }

        return ((i1.x == i2.x) & (i1.y == i2.y));
    }
    public override bool Equals(System.Object obj)
    {
        if (obj == null)
        {
            return false;
        }

        IntPoint p = obj as IntPoint;
        if ((System.Object)p == null)
        {
            return false;
        }

        return ((x == p.x) & (y == p.y));
    }
    public bool Equals(IntPoint p)
    {
        // If parameter is null return false:
        if ((object)p == null)
        {
            return false;
        }

        // Return true if the fields match:
        return ((x == p.x) & (y == p.y));
    }
}
