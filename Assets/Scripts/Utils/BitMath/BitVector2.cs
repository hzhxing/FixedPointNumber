using UnityEngine;

namespace Utils.BitMath
{
    public struct BitVector2
    {
        public BitFloat x;
        public BitFloat y;

        public BitVector2(BitFloat x, BitFloat y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2 GetVector2()
        {
            return new Vector2(x.FloatValue,y.FloatValue);
        }

        public BitFloat SqrMagnitude
        {
            get { return x * x + y * y; }
        }

        public BitFloat Magnitude
        {
            get { return BitMathUtil.Sqrt(x * x + y * y); }
        }

        public void Add(BitVector2 v)
        {
            x = x + v.x;
            y = y + v.y;
        }

        public void Minus(BitVector2 v)
        {
            x = x - v.x;
            y = y - v.y;
        }

        public override bool Equals(object obj)
        {
            if (obj is BitVector2)
            {
                return this == (BitVector2) obj;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static BitVector2 Create(Vector2 vect)
        {
            return new BitVector2(BitFloat.Create(vect.x),BitFloat.Create(vect.y));
        }

        public static BitFloat Dot(BitVector2 a, BitVector2 b)
        {
            return a.x * b.x + a.y * b.y;
        }

        public static BitVector2 operator +(BitVector2 a, BitVector2 b)
        {
            return new BitVector2(a.x + b.x,a.y + b.y);
        }
        
        public static BitVector2 operator -(BitVector2 a, BitVector2 b)
        {
            return new BitVector2(a.x - b.x,a.y - b.y);
        }
        
        public static BitVector2 operator *(BitVector2 a, int b)
        {
            return new BitVector2(a.x * b,a.y * b);
        }
        
        public static BitVector2 operator /(BitVector2 a, int b)
        {
            return new BitVector2(a.x / b,a.y / b);
        }
        
        public static bool operator ==(BitVector2 a, BitVector2 b)
        {
            return a.x == b.x && a.y == b.y;
        }
        
        public static bool operator !=(BitVector2 a, BitVector2 b)
        {
            return a.x == b.x && a.y == b.y;
        }

        public static BitVector2 One
        {
            get {return new BitVector2(BitFloat.One, BitFloat.One);}
        }

        public static BitVector2 Zero
        {
            get {return new BitVector2(BitFloat.Zero,BitFloat.Zero);}
        }

        public static BitVector2 Left
        {
            get {return new BitVector2(BitFloat.Create(-1),BitFloat.Zero);}
        }
        
        public static BitVector2 Right
        {
            get {return new BitVector2(BitFloat.Create(1),BitFloat.Zero);}
        }
        
        public static BitVector2 Up
        {
            get {return new BitVector2(BitFloat.Zero,BitFloat.Create(1));}
        }
        
        public static BitVector2 Down
        {
            get {return new BitVector2(BitFloat.Zero,BitFloat.Create(-1));}
        }
    }
}