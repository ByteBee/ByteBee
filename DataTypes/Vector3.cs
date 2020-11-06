using System;

namespace ByteBee.Framework.DataTypes
{
    public sealed class Vector3 : IEquatable<Vector3>
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public static Vector3 Zero { get; } = new Vector3(0, 0, 0);
        public static Vector3 One { get; } = new Vector3(1, 1, 1);

        public static Vector3 I { get; } = new Vector3(1, 0, 0);
        public static Vector3 J { get; } = new Vector3(0, 1, 0);
        public static Vector3 K { get; } = new Vector3(0, 0, 1);

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return X;
                    case 1:
                        return Y;
                    case 2:
                        return Z;
                    default:
                        
                        throw new IndexOutOfRangeException(
                            $"An 3D vector has exact 3 values. There are no definitions at position '{index}'.");
                }
            }
        }

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3(double s) : this(s, s, s)
        {
        }

        public Vector3(double[] a) : this(a[0], a[1], a[2])
        {
        }

        public Vector3(Vector3 v) : this(v.X, v.Y, v.Z)
        {
        }

        public Vector3(Tuple<double, double, double> t) : this(t.Item1, t.Item2, t.Item3)
        {
        }

        public override string ToString()
        {
            return $"X:{X}|Y:{Y}|Z:{Z}";
        }

        public static implicit operator Vector3(double[] arr)
        {
            return new Vector3(arr);
        }

        public static implicit operator Vector3(Tuple<double, double, double> tuple)
        {
            return new Vector3(tuple);
        }

        public static implicit operator double[] (Vector3 v)
        {
            return new[] { v.X, v.Y, v.Z };
        }

        public static implicit operator Tuple<double, double, double>(Vector3 v)
        {
            return new Tuple<double, double, double>(v.X, v.Y, v.Z);
        }

        #region Add

        public Vector3 Add(double x, double y, double z)
        {
            return new Vector3(
                X + x,
                Y + y,
                Z + z
            );
        }

        public Vector3 Add(Vector3 v)
        {
            return Add(v.X, v.Y, v.Z);
        }
        
        public Vector3 Add(double s)
        {
            return Add(s, s, s);
        }
        
        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return a.Add(b);
        }
        
        public static Vector3 operator +(Vector3 v, double s)
        { 
            return v.Add(s);
        }

        public static Vector3 operator +(double s, Vector3 v)
        {
            return v.Add(s);
        }

        #endregion

        #region Subtract

        public Vector3 Subtract(double x, double y, double z)
        {
            return new Vector3(X - x, Y - y, Z - z);
        }

        public Vector3 Subtract(Vector3 v)
        {
            return Subtract(v.X, v.Y, v.Z);
        }

        public Vector3 Subtract(double s)
        {
            return Subtract(s, s, s);
        }
        
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return a.Subtract(b);
        }

        public static Vector3 operator -(Vector3 v, double s)
        {
            return v.Subtract(s);
        }

        public static Vector3 operator -(double s, Vector3 v)
        {
            return new Vector3(
                s - v.X,
                s - v.Y,
                s - v.Z
            );
        }

        #endregion

        #region Multiply

        public Vector3 Multiply(double x, double y, double z)
        {
            return new Vector3(X * x, Y * y, Z * z);
        }
        
        public Vector3 Multiply(Vector3 v)
        {
            return Multiply(v.X, v.Y, v.Z);
        }

        public Vector3 Multiply(double s)
        {
            return Multiply(s, s, s);
        }
        
        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            return a.Multiply(b);
        }

        public static Vector3 operator *(Vector3 v, double s)
        {
            return v.Multiply(s);
        }

        public static Vector3 operator *(double s, Vector3 v)
        {
            return v.Multiply(s);
        }

        #endregion

        #region Divide

        public Vector3 Divide(double x, double y, double z)
        {
            return new Vector3(X / x, Y / y, Z / z);
        }


        public Vector3 Divide(Vector3 v)
        {
            return Divide(v.X, v.Y, v.Z);
        }

        public Vector3 Divide(double s)
        {
            return Divide(s, s, s);
        }

        
        public static Vector3 operator /(Vector3 a, Vector3 b)
        {
            return a.Divide(b);
        }

        public static Vector3 operator /(Vector3 v, double s)
        {
            return v.Divide(s);
        }

        public static Vector3 operator /(double s, Vector3 v)
        {
            return new Vector3(
                s / v.X,
                s / v.Y,
                s / v.Z
            );
        }

        #endregion

        public Vector3 Round(int precision)
        {
            return new Vector3(
                Math.Round(X, precision),
                Math.Round(Y, precision),
                Math.Round(Z, precision)
            );
        }

        public Vector3 Abs()
        {
            return new Vector3(
                Math.Abs(X),
                Math.Abs(Y),
                Math.Abs(Z)
            );
        }

        public static Vector3 operator +(Vector3 v)
        {
            return v.Abs();
        }

        public Vector3 Negate()
        {
            return new Vector3(-X, -Y, -Z);
        }
        
        public static Vector3 operator -(Vector3 v)
        {
            return v.Negate();
        }


        public bool IsLessThan(Vector3 v)
        {
            return X < v.X && Y < v.Y && Z < v.Z;
        }

        public bool IsLessThanOrEqual(Vector3 v)
        {
            return X <= v.X && Y <= v.Y && Z <= v.Z;
        }

        public bool IsGreaterThan(Vector3 v)
        {
            return X > v.X && Y > v.Y && Z > v.Z;
        }

        public bool IsGreaterThanOrEqual(Vector3 v)
        {
            return X >= v.X && Y >= v.Y && Z >= v.Z;
        }

        public double GetLength()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public Vector3 Normalize()
        {
            double length = GetLength();
            return Divide(length);
        }

        public bool Equals(Vector3 v)
        {
            if (ReferenceEquals(null, v))
            {
                return false;
            }

            if (ReferenceEquals(this, v))
            {
                return true;
            }

            return X.Equals(v.X) && Y.Equals(v.Y) && Z.Equals(v.Z);
        }

        public bool IsEqual(Vector3 v)
        { 
            return IsEqual(v, 10E-9);
        }

        public bool IsZero()
        {
            return IsEqual(this, 10E-9);
        }

        public bool IsEqual(Vector3 v, double t)
        {
            bool xAreEqual = Math.Abs(X - v.X) <= t;
            bool yAreEqual = Math.Abs(Y - v.Y) <= t;
            bool zAreEqual = Math.Abs(Z - v.Z) <= t;

            return xAreEqual && yAreEqual && zAreEqual;
        }

        public static bool operator ==(Vector3 a, Vector3 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Vector3 a, Vector3 b)
        {
            return !a.Equals(b);
        }

        public static bool operator >(Vector3 a, Vector3 b)
        {
            return a.IsGreaterThan(b);
        }

        public static bool operator <(Vector3 a, Vector3 b)
        {
            return a.IsLessThan(b);
        }

        public static bool operator >=(Vector3 a, Vector3 b)
        {
            return a.IsGreaterThanOrEqual(b);
        }

        public static bool operator <=(Vector3 a, Vector3 b)
        {
            return a.IsLessThanOrEqual(b);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Vector3 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();

                return hashCode;
            }
        }
    }
}