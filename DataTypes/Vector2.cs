using System;

namespace ByteBee.Framework.DataTypes
{
    public sealed class Vector2 : IEquatable<Vector2>
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public static Vector2 Zero { get; } = new Vector2(0, 0);
        public static Vector2 One { get; } = new Vector2(1, 1);

        public static Vector2 I { get; } = new Vector2(1, 0);
        public static Vector2 J { get; } = new Vector2(0, 1);

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
                    default:
                        
                        throw new IndexOutOfRangeException(
                            $"An 2D vector has exact 2 values. There are no definitions at position '{index}'.");
                }
            }
        }

        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Vector2(double s) : this(s, s)
        {
        }

        public Vector2(double[] a) : this(a[0], a[1])
        {
        }

        public Vector2(Vector2 v) : this(v.X, v.Y)
        {
        }

        public Vector2(Tuple<double, double> t) : this(t.Item1, t.Item2)
        {
        }

        public override string ToString()
        {
            return $"X:{X}|Y:{Y}";
        }

        public static implicit operator Vector2(double[] arr)
        {
            return new Vector2(arr);
        }

        public static implicit operator Vector2(Tuple<double, double> tuple)
        {
            return new Vector2(tuple);
        }

        public static implicit operator double[] (Vector2 v)
        {
            return new[] { v.X, v.Y };
        }

        public static implicit operator Tuple<double, double>(Vector2 v)
        {
            return new Tuple<double, double>(v.X, v.Y);
        }

        #region Add

        public Vector2 Add(double x, double y)
        {
            return new Vector2(
                X + x,
                Y + y
            );
        }

        public Vector2 Add(Vector2 v)
        {
            return Add(v.X, v.Y);
        }

        public Vector2 Add(double s)
        {
            return Add(s, s);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return a.Add(b);
        }

        public static Vector2 operator +(Vector2 v, double s)
        {
            return v.Add(s);
        }

        public static Vector2 operator +(double s, Vector2 v)
        {
            return v.Add(s);
        }

        #endregion

        #region Subtract

        public Vector2 Subtract(double x, double y)
        {
            return new Vector2(X - x, Y - y);
        }

        public Vector2 Subtract(Vector2 v)
        {
            return Subtract(v.X, v.Y);
        }

        public Vector2 Subtract(double s)
        {
            return Subtract(s, s);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return a.Subtract(b);
        }

        public static Vector2 operator -(Vector2 v, double s)
        {
            return v.Subtract(s);
        }

        public static Vector2 operator -(double s, Vector2 v)
        {
            return new Vector2(
                s - v.X,
                s - v.Y
            );
        }

        #endregion

        #region Multiply

        public Vector2 Multiply(double x, double y)
        {
            return new Vector2(X * x, Y * y);
        }

        public Vector2 Multiply(Vector2 v)
        {
            return Multiply(v.X, v.Y);
        }

        public Vector2 Multiply(double s)
        {
            return Multiply(s, s);
        }

        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return a.Multiply(b);
        }

        public static Vector2 operator *(Vector2 v, double s)
        {
            return v.Multiply(s);
        }

        public static Vector2 operator *(double s, Vector2 v)
        {
            return v.Multiply(s);
        }

        #endregion

        #region Divide

        public Vector2 Divide(double x, double y)
        {
            return new Vector2(X / x, Y / y);
        }


        public Vector2 Divide(Vector2 v)
        {
            return Divide(v.X, v.Y);
        }

        public Vector2 Divide(double s)
        {
            return Divide(s, s);
        }


        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return a.Divide(b);
        }

        public static Vector2 operator /(Vector2 v, double s)
        {
            return v.Divide(s);
        }

        public static Vector2 operator /(double s, Vector2 v)
        {
            return new Vector2(
                s / v.X,
                s / v.Y
            );
        }

        #endregion

        public Vector2 Round(int precision)
        {
            return new Vector2(
                Math.Round(X, precision),
                Math.Round(Y, precision)
            );
        }

        public Vector2 Abs()
        {
            return new Vector2(
                Math.Abs(X),
                Math.Abs(Y)
            );
        }

        public static Vector2 operator +(Vector2 v)
        {
            return v.Abs();
        }

        public Vector2 Negate()
        {
            return new Vector2(-X, -Y);
        }

        public static Vector2 operator -(Vector2 v)
        {
            return v.Negate();
        }


        public bool IsLessThan(Vector2 v)
        {
            return X < v.X && Y < v.Y;
        }

        public bool IsLessThanOrEqual(Vector2 v)
        {
            return X <= v.X && Y <= v.Y;
        }

        public bool IsGreaterThan(Vector2 v)
        {
            return X > v.X && Y > v.Y;
        }

        public bool IsGreaterThanOrEqual(Vector2 v)
        {
            return X >= v.X && Y >= v.Y;
        }

        public double GetLength()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public Vector2 Normalize()
        {
            double length = GetLength();
            return Divide(length);
        }

        public bool Equals(Vector2 v)
        {
            return IsEqual(v);
        }

        public bool IsEqual(Vector2 v)
        {
            return IsEqual(v, 10E-9);
        }

        public bool IsZero()
        {
            return IsEqual(this, 10E-9);
        }

        public bool IsEqual(Vector2 v, double t)
        {
            bool xAreEqual = Math.Abs(X - v.X) <= t;
            bool yAreEqual = Math.Abs(Y - v.Y) <= t;

            return xAreEqual && yAreEqual;
        }

        public static bool operator ==(Vector2 a, Vector2 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Vector2 a, Vector2 b)
        {
            return !a.Equals(b);
        }

        public static bool operator >(Vector2 a, Vector2 b)
        {
            return a.IsGreaterThan(b);
        }

        public static bool operator <(Vector2 a, Vector2 b)
        {
            return a.IsLessThan(b);
        }

        public static bool operator >=(Vector2 a, Vector2 b)
        {
            return a.IsGreaterThanOrEqual(b);
        }

        public static bool operator <=(Vector2 a, Vector2 b)
        {
            return a.IsLessThanOrEqual(b);
        }

        public override bool Equals(object obj)
        {
            return !ReferenceEquals(null, obj) && obj is Vector2 v && Equals(v);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                // ReSharper disable NonReadonlyMemberInGetHashCode
                int hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                // ReSharper restore NonReadonlyMemberInGetHashCode
                return hashCode;
            }
        }
    }
}