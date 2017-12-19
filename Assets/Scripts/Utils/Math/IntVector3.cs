using UnityEngine;

namespace Utils.Math
{
    public struct IntVector3
    {
        public long x;
        public long y;
        public long z;

        public int scale;

        public IntVector3(long x, long y, long z, int scale)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.scale = scale;
        }

        public void SetScale(int scale)
        {
            if (this.scale == scale)
            {
                return;
            }

            x = x * scale / this.scale;
            y = y * scale / this.scale;
            z = z * scale / this.scale;
            this.scale = scale;
        }

        public Vector3 GetVector3()
        {
            return new Vector3(x / (float)scale,y / (float)scale,z / (float)scale);
        }

        public IntFloat SqrMagnitude
        {
            get {return new IntFloat((x * x + y * y + z * z)/scale,scale);}
        }

        public IntFloat Magnitude
        {
            get {return new IntFloat(MathUtil.Sqrt(x * x + y * y + z * z),scale);}
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj is IntVector3)
            {
                return this == (IntVector3) obj;
            }
            
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{{x={0} y={1} y={2} scale={3}}}",x,y,z,scale);
        }

        public static IntFloat Dot(IntVector3 a, IntVector3 b)
        {
            long newScale = (long)a.scale * b.scale;
            if (MathUtil.IsInt32Overflow(newScale))
            {
                Debug.LogWarning("int32 overflow!!");
                return new IntFloat((a.x * b.x + a.y * b.y + a.z * b.z) / b.scale,a.scale);
            }
            else
            {
                return new IntFloat(a.x * b.x + a.y * b.y + a.z * b.z,(int)newScale);
            }
        }

        public static IntVector3 Cross(IntVector3 a, IntVector3 b)
        {
            long x = a.y * b.z - a.z * b.y;
            long y = a.z * b.x - a.x * b.z;
            long z = a.x * b.y - a.y * b.x;
            long scale = a.scale * b.scale;
            
            if (MathUtil.IsInt32Overflow(scale))
            {
                Debug.LogWarning("int32 overflow!!");
                x = x / b.scale;
                y = y / b.scale;
                z = z / b.scale;
                scale = a.scale;
            }
            
            return new IntVector3(x,y,z,(int)scale);
        }

        public static IntFloat Distance(IntVector3 a, IntVector3 b)
        {
            long x, y, z;
            int scale;
            
            if (a.scale == b.scale)
            {
                x = a.x - b.x;
                y = a.y - b.y;
                z = a.z - b.z;
                scale = a.scale;
                
            }
            else
            {
                int lowestCommonMultiple = MathUtil.GetLowestCommonMultiple(a.scale, b.scale);
                x = a.x * lowestCommonMultiple / a.scale - b.x * lowestCommonMultiple / b.scale;
                y = a.y * lowestCommonMultiple / a.scale - b.y * lowestCommonMultiple / b.scale;
                z = a.z * lowestCommonMultiple / a.scale - b.z * lowestCommonMultiple / b.scale;
                scale = lowestCommonMultiple;
            }
            
            return new IntFloat(MathUtil.Sqrt(x * x + y * y + z * z), scale);
        }
        
        public static IntVector3 operator +(IntVector3 a, IntVector3 b)
        {
            if (a.scale == b.scale)
            {
                long x = a.x + b.x;
                long y = a.y + b.y;
                long z = a.z + b.z;
                return new IntVector3(x,y,z,a.scale);
            }
            else
            {
                int lowestCommonMultiple = MathUtil.GetLowestCommonMultiple(a.scale, b.scale);
                long x = a.x * lowestCommonMultiple / a.scale + b.x * lowestCommonMultiple / b.scale;
                long y = a.y * lowestCommonMultiple / a.scale + b.y * lowestCommonMultiple / b.scale;
                long z = a.z * lowestCommonMultiple / a.scale + b.z * lowestCommonMultiple / b.scale;
                return new IntVector3(x,y,z,lowestCommonMultiple);
            }
        }
        
        public static IntVector3 operator -(IntVector3 a, IntVector3 b)
        {
            if (a.scale == b.scale)
            {
                long x = a.x - b.x;
                long y = a.y - b.y;
                long z = a.z - b.z;
                return new IntVector3(x,y,z,a.scale);
            }
            else
            {
                int lowestCommonMultiple = MathUtil.GetLowestCommonMultiple(a.scale, b.scale);
                long x = a.x * lowestCommonMultiple / a.scale - b.x * lowestCommonMultiple / b.scale;
                long y = a.y * lowestCommonMultiple / a.scale - b.y * lowestCommonMultiple / b.scale;
                long z = a.z * lowestCommonMultiple / a.scale - b.z * lowestCommonMultiple / b.scale;
                return new IntVector3(x,y,z,lowestCommonMultiple);
            }
        }

        public static IntVector3 operator *(IntVector3 a, int value)
        {
            return new IntVector3(a.x * value,a.y * value,a.z * value,a.scale);
        }
        
        public static IntVector3 operator /(IntVector3 a, int value)
        {
            return new IntVector3(a.x,a.y,a.z,a.scale * value);
        }

        public static bool operator ==(IntVector3 a, IntVector3 b)
        {
            return (a.x * b.scale) == (b.x * a.scale) && (a.y * b.scale) == (b.y * a.scale) &&
                   (a.z * b.scale) == (b.z * a.scale);
        }
        
        public static bool operator !=(IntVector3 a, IntVector3 b)
        {
            return (a.x * b.scale) != (b.x * a.scale) || (a.y * b.scale) != (b.y * a.scale) ||
                   (a.z * b.scale) != (b.z * a.scale);
        }
    }
}