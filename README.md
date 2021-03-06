# FixedPointNumber

定点数实现方案  

* IntFloat、IntVector2、IntVector3  
	* 每个浮点数带有一个缩放值  
	* 加减法使用最小公倍数的方式实现  
	* 乘除法直接计算分子与分母（缩放值即为分母），精度不会丢失，带来的问题是很容易超出long的最大值  
	* 开方运算使用位+二分实现，效率比系统Mathf.Sqrt差很多  
	* Sin和Cos使用查表的方式实现  
  
* BitFloat、BitVector2、BitVector3  
	* 所有浮点数使用统一缩放值  
	* 使用按位左移（操作符<<）方式实现，使用时先设定位移的值BitFloat.BIT(默认是10),数值越大精度越高，数值也容易越界(long)  
	* 加减乘除最终都会运算至统一缩放值，会造成精度丢失  
	* 开方使用公式实现  
	* Sin和Cos使用泰勒公式实现  
  
定点数应用于帧同步以确保不同的客户端运算结果一致，推荐使用第二种方式实现，使用位移性能比较好，并且数值不容易越界(long)，第一种乘除法很容易越界
  