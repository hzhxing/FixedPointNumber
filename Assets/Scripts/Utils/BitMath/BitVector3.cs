using UnityEngine;

namespace Utils.BitMath
{
    public struct BitVector3
    {
        public BitFloat x;
        public BitFloat y;
        public BitFloat z;

        public BitVector3(BitFloat x, BitFloat y, BitFloat z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3 GetVector3()
        {
            return new Vector3(x.FloatValue,y.FloatValue,z.FloatValue);
        }

        public BitFloat SqrMagnitude
        {
            get { return x * x + y * y + z * z; }
        }

        public BitFloat Magnitude
        {
            get { return BitMathUtil.Sqrt(x * x + y * y + z * z); }
        }

        public override bool Equals(object obj)
        {
            if (obj is BitVector3)
            {
                return (BitVector3)obj == this;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static BitVector3 Create(Vector3 v)
        {
            return new BitVector3(BitFloat.Create(v.x),BitFloat.Create(v.y),BitFloat.Create(v.z));
        }

        public static BitFloat Dot(BitVector3 a, BitVector3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        public static BitVector3 Cross(BitVector3 a, BitVector3 b)
        {
            BitFloat x = a.y * b.z - a.z * b.y;
            BitFloat y = a.z * b.x - a.x * b.z;
            BitFloat z = a.x * b.y - a.y * b.x;
            
            return new BitVector3(x,y,z);
        }

        public static BitFloat Distance(BitVector3 a, BitVector3 b)
        {
            BitFloat x = a.x - b.x;
            BitFloat y = a.y - b.y;
            BitFloat z = a.z - b.z;

            return BitMathUtil.Sqrt(x * x + y * y + z * z);
        }

        public static BitVector3 operator +(BitVector3 a, BitVector3 b)
        {
            return new BitVector3(a.x + b.x,a.y + b.y,a.z * b.z);
        }
        
        public static BitVector3 operator -(BitVector3 a, BitVector3 b)
        {
            return new BitVector3(a.x - b.x,a.y - b.y,a.z - b.z);
        }
        
        public static BitVector3 operator *(BitVector3 a, int b)
        {
            return new BitVector3(a.x * b,a.y * b,a.z * b);
        }
        
        public static BitVector3 operator /(BitVector3 a, int b)
        {
            return new BitVector3(a.x / b,a.y / b,a.z / b);
        }

        public static bool operator ==(BitVector3 a, BitVector3 b)
        {
            return a.x == b.x && a.y == b.y && a.z == b.z;
        }
        
        public static bool operator !=(BitVector3 a, BitVector3 b)
        {
            return a.x != b.x || a.y != b.y || a.z != b.z;
        }

        public static BitVector3 One
        {
            get {return new BitVector3(BitFloat.One, BitFloat.One, BitFloat.One);}
        }

        public static BitVector3 Zero
        {
            get {return new BitVector3(BitFloat.Zero, BitFloat.Zero, BitFloat.Zero);}
        }

        public static BitVector3 Left
        {
            get {return new BitVector3(BitFloat.Create(-1), BitFloat.Zero, BitFloat.Zero);}
        }
        
        public static BitVector3 Right
        {
            get {return new BitVector3(BitFloat.One, BitFloat.Zero, BitFloat.Zero);}
        }
        
        public static BitVector3 Up
        {
            get {return new BitVector3(BitFloat.Zero, BitFloat.One, BitFloat.Zero);}
        }
        
        public static BitVector3 Down
        {
            get {return new BitVector3(BitFloat.Zero, BitFloat.Create(-1), BitFloat.Zero);}
        }
        
        public static BitVector3 Forward
        {
            get {return new BitVector3(BitFloat.Zero, BitFloat.Zero, BitFloat.One);}
        }
        
        public static BitVector3 Back
        {
            get {return new BitVector3(BitFloat.Zero, BitFloat.Zero, BitFloat.Create(-1));}
        }
    }
}