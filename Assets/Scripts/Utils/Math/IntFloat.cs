using System;
using UnityEngine;

namespace Utils.Math
{
    public struct IntFloat
    {
        public long value;

        public int scale;

//        public IntegerFloat(float value, int scale)
//        {
//            this.value = (long)(value * scale);
//            this.scale = scale;
//        }

        public IntFloat(long value, int scale)
        {
            this.value = value;
            this.scale = scale;
        }

        public int IntValue
        {
            get { return (int)(value / scale); }
        }
        
        public float FloatValue
        {
            get
            {
                return (float)((double)value / (double)scale);
            }
        }
        
        public void SetScale(int scaleValue)
        {
            if (scale == scaleValue)
            {
                return;
            }

            value = value * scaleValue / scale;
            scale = scaleValue;
        }

        public void SetScalePositive()
        {
            if (scale < 0)
            {
                value = -value;
                scale = -scale;
            }
        }
        
        public static IntFloat operator+(IntFloat a,IntFloat b)
        {
            a.SetScalePositive();
            b.SetScalePositive();

            if (a.scale == b.scale)
            {
                return new IntFloat(a.value + b.value,a.scale);
            }
            else
            {
                int lowestCommonMultiple = MathUtil.GetLowestCommonMultiple(a.scale, b.scale);
                long value = a.value * lowestCommonMultiple / a.scale + b.value * lowestCommonMultiple / b.scale;
                return new IntFloat(value,lowestCommonMultiple);
            }
        }

        public static IntFloat operator +(IntFloat a, int b)
        {
            return new IntFloat(a.value + b * a.scale,a.scale);
        }

        public static IntFloat operator -(IntFloat a, IntFloat b)
        {
            a.SetScalePositive();
            b.SetScalePositive();
            if (a.scale == b.scale)
            {
                return new IntFloat(a.value - b.value,a.scale);
            }
            else
            {
                int lowestCommonMultiple = MathUtil.GetLowestCommonMultiple(a.scale, b.scale);
                long value = a.value * lowestCommonMultiple / a.scale - b.value * lowestCommonMultiple / b.scale;
                return new IntFloat(value,lowestCommonMultiple);
            }
        }
        
        public static IntFloat operator -(IntFloat a, int b)
        {
            return new IntFloat(a.value - b * a.scale,a.scale);
        }
        
        public static IntFloat operator -(IntFloat a)
        {
            return new IntFloat(-a.value,a.scale);
        }

        public static IntFloat operator *(IntFloat a, IntFloat b)
        {
            IntFloat targte = new IntFloat(a.value,a.scale);
            
            long newScale = (long)a.scale * b.scale;
            if (MathUtil.IsInt32Overflow(newScale))
            {
                targte.value = a.value * b.value / b.scale;
                Debug.LogWarning("int32 overflow!!");
            }
            else
            {
                targte.value = a.value * b.value;
                targte.scale = a.scale * b.scale;
            }
            targte.SetScalePositive();
            return targte;
        }
        
        public static IntFloat operator *(IntFloat a, int b)
        {
            return new IntFloat(a.value * b,a.scale);
        }

        public static IntFloat operator /(IntFloat a, IntFloat b)
        {
            IntFloat targte = new IntFloat(a.value,a.scale);
            
            long newScale = b.value * a.scale;
            if (MathUtil.IsInt32Overflow(newScale))
            {
                targte.value = a.value * b.scale / b.value;
                Debug.LogWarning("int32 overflow!!");
            }
            else
            {
                targte.value = a.value * b.scale;
                targte.scale = (int) newScale;
            }
            
            targte.SetScalePositive();
            return targte;
        }
        
        public static IntFloat operator /(IntFloat a, int b)
        {
            IntFloat targte = new IntFloat(a.value,a.scale);
            
            long newScale = (long) a.scale * b;
            if (MathUtil.IsInt32Overflow(newScale))
            {
                targte.value = a.value / b;
                Debug.LogWarning("int32 overflow!!");
            }
            else
            {
                targte.scale = a.scale * b;
            }

            targte.SetScalePositive();
            return targte;
        }

        public static bool operator >(IntFloat a, IntFloat b)
        {
            return a.value * b.scale > b.value * a.scale;
        }
        
        public static bool operator >(IntFloat a, int b)
        {
            return a.value > b * a.scale;
        }
        
        public static bool operator <(IntFloat a, IntFloat b)
        {
            return a.value * b.scale < b.value * a.scale;
        }
        
        public static bool operator <(IntFloat a, int b)
        {
            return a.value < b * a.scale;
        }
        
        public static bool operator ==(IntFloat a, IntFloat b)
        {
            return a.value * b.scale == b.value * a.scale;
        }
        
        public static bool operator ==(IntFloat a, int b)
        {
            return a.value == b * a.scale;
        }
        
        public static bool operator !=(IntFloat a, IntFloat b)
        {
            return a.value * b.scale != b.value * a.scale;
        }
        
        public static bool operator !=(IntFloat a, int b)
        {
            return a.value != b * a.scale;
        }
        
        public static bool operator >=(IntFloat a, IntFloat b)
        {
            return a > b || a == b;
        }
        
        public static bool operator <=(IntFloat a, IntFloat b)
        {
            return a < b || a == b;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            } 
            else if (obj is IntFloat)
            {
                return this == (IntFloat)obj;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("(value={0},scale={1},float={2})",value,scale,FloatValue);
        }
    }
}