using UnityEngine;

namespace Utils.Math
{
    public struct IntVector2
    {
        public long x;
        public long y;

        public int scale;

        public IntVector2(long x, long y,int scale)
        {
            this.x = x;
            this.y = y;
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
            this.scale = scale;
        }

        public Vector2 GetVector2()
        {
            return new Vector2(x / (float)scale,y / (float)scale);
        }

        public IntFloat SqrMagnitude
        {
            get { return new IntFloat((x * x + y * y) / scale, scale); }
        }

        public IntFloat Magnitude
        {
            get
            {
                return new IntFloat(MathUtil.Sqrt(x * x + y * y),scale);
            }
        }

        public void Add(IntVector2 value)
        {
            if (scale == value.scale)
            {
                x = x + value.x;
                y = y + value.y;
            }
            else
            {
                int lowestCommonMultiple = MathUtil.GetLowestCommonMultiple(scale, value.scale);
                x = x * lowestCommonMultiple / scale + value.x * lowestCommonMultiple / value.scale;
                y = y * lowestCommonMultiple / scale + value.y * lowestCommonMultiple / value.scale;
                scale = lowestCommonMultiple;
            }
            
        }

        public void Minus(IntVector2 value)
        {
            if (scale == value.scale)
            {
                x = x - value.x;
                y = y - value.y;
            }
            else
            {
                int lowestCommonMultiple = MathUtil.GetLowestCommonMultiple(scale, value.scale);
                x = x * lowestCommonMultiple / scale - value.x * lowestCommonMultiple / value.scale;
                y = y * lowestCommonMultiple / scale - value.y * lowestCommonMultiple / value.scale;
                scale = lowestCommonMultiple;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj is IntVector2)
            {
                return this == (IntVector2) obj;
            }
            
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{{x={0} y={1} scale={2}}}",x,y,scale);
        }

        public static IntFloat Dot(IntVector2 a, IntVector2 b)
        {
            return new IntFloat(a.x * b.x + a.y * b.y,a.scale * b.scale);
        }
        
        public static IntVector2 operator +(IntVector2 a, IntVector2 b)
        {
            if (a.scale == b.scale)
            {
                return new IntVector2(a.x + b.x,a.y + b.y,a.scale);
            }
            else
            {
                int lowestCommonMultiple = MathUtil.GetLowestCommonMultiple(a.scale, b.scale);
                long x = a.x * lowestCommonMultiple / a.scale + b.x * lowestCommonMultiple / b.scale;
                long y = a.y * lowestCommonMultiple / a.scale + b.y * lowestCommonMultiple / b.scale;
                return new IntVector2(x,y,lowestCommonMultiple);
            }
           
        }

        public static IntVector2 operator -(IntVector2 a, IntVector2 b)
        {
            if (a.scale == b.scale)
            {
                return new IntVector2(a.x - b.x,a.y - b.y,a.scale);
            }
            else
            {
                int lowestCommonMultiple = MathUtil.GetLowestCommonMultiple(a.scale, b.scale);
                long x = a.x * lowestCommonMultiple / a.scale - b.x * lowestCommonMultiple / b.scale;
                long y = a.y * lowestCommonMultiple / a.scale - b.y * lowestCommonMultiple / b.scale;
                return new IntVector2(x,y,lowestCommonMultiple);
            }            
        }
        
        public static IntVector2 operator *(IntVector2 a, int value)
        {
            return new IntVector2(a.x * value,a.y * value,a.scale);
        }

        public static IntVector2 operator /(IntVector2 a, int value)
        {
            return new IntVector2(a.x,a.y,a.scale * value);
        }
        
        public static bool operator ==(IntVector2 a, IntVector2 b)
        {
            return (a.x * b.scale) == (b.x * a.scale) && (a.y * b.scale) == (b.y * a.scale);
        }
        
        public static bool operator !=(IntVector2 a, IntVector2 b)
        {
            return (a.x * b.scale) != (b.x * a.scale) || (a.y * b.scale) != (b.y * a.scale);
        }

        private static IntVector2 mZero = new IntVector2(0, 0,1);
        public static IntVector2 Zero
        {
            get { return mZero;}
        }

        private static IntVector2 mOne = new IntVector2(1,1,1);
        public static IntVector2 One
        {
            get { return mOne; }
        }
        
        private static IntVector2 mRight = new IntVector2(1,0,1);
        public static IntVector2 Right
        {
            get { return mRight; }
        }
        
        private static IntVector2 mLeft = new IntVector2(-1,0,1);
        public static IntVector2 Left
        {
            get { return mLeft; }
        }
        
        private static IntVector2 mUp = new IntVector2(1,0,1);
        public static IntVector2 Up
        {
            get { return mUp; }
        }
        
        private static IntVector2 mDown = new IntVector2(-1,0,1);
        public static IntVector2 Down
        {
            get { return mDown; }
        }
    }
}