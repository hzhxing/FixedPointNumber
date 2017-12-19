using UnityEngine;
using Utils.BitMath;

public class Test : MonoBehaviour
{
    private void Awake()
    {
        float fa = 200f;
        float fb = 2155.358f;

        BitFloat bfa = BitFloat.Create(fa);
        BitFloat bfb = BitFloat.Create(fb);
        
        Debug.LogFormat("fa + fb={0}  bfa + bfb={1}",fa + fb ,(bfa + bfb).FloatValue);
        Debug.LogFormat("fa - fb={0}  bfa - bfb={1}",fa - fb ,(bfa - bfb).FloatValue);
        Debug.LogFormat("fa * fb={0}  bfa * bfb={1}",fa * fb ,(bfa * bfb).FloatValue);
        Debug.LogFormat("fa / fb={0}  bfa / bfb={1}",fa / fb ,(bfa / bfb).FloatValue);
        Debug.LogFormat("fa % fb={0}  bfa % bfb={1}",fa % fb ,(bfa % bfb).FloatValue);
        Debug.LogFormat("PI={0}  bitPI={1}",Mathf.PI ,BitMathUtil.PI.FloatValue);
        Debug.LogFormat("sqrt(fa)={0}  sqrt(bfa)={1}",Mathf.Sqrt(fa),BitMathUtil.Sqrt(bfa).FloatValue);
        Debug.LogFormat("abs(fa)={0}  abs(bfa)={1}",Mathf.Abs(fa) ,BitMathUtil.Abs(bfa).FloatValue);
        Debug.LogFormat("floor(fa)={0}  floor(bfa)={1}",Mathf.Floor(fa) ,BitMathUtil.Floor(bfa).FloatValue);
        Debug.LogFormat("round(fa)={0}  round(bfa)={1}",Mathf.Round(fa) ,BitMathUtil.Round(bfa).FloatValue);
        Debug.LogFormat("ceil(fa)={0}  ceil(bfa)={1}",Mathf.Ceil(fa) ,BitMathUtil.Ceil(bfa).FloatValue);
        Debug.LogFormat("Min(fa,fb)={0}  Min(bfa,bfb)={1}",Mathf.Min(fa,fb) ,BitMathUtil.Min(bfa,bfb).FloatValue);
        Debug.LogFormat("Max(fa,fb)={0}  Max(bfa,bfb)={1}",Mathf.Max(fa,fb) ,BitMathUtil.Max(bfa,bfb).FloatValue);
        Debug.LogFormat("Deg2Rad(fa)={0}  Deg2Rad(bfa)={1}",Mathf.Deg2Rad * fa ,BitMathUtil.Deg2Rad(bfa).FloatValue);
        Debug.LogFormat("Sin(fa)={0}  Sin(bfa)={1}",Mathf.Sin(Mathf.Deg2Rad * fa) ,BitMathUtil.Sin(bfa).FloatValue);
        Debug.LogFormat("Cos(fa)={0}  Cos(bfa)={1}",Mathf.Cos(Mathf.Deg2Rad * fa) ,BitMathUtil.Cos(bfa).FloatValue);
    }
}