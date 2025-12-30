using system;

namespace LPU_Common
{
    public class GenericClass<T>
    {
        public void SwapMe(ref T obj1, ref T obj2)
        {
            T temp;
            temp = obj1;
            obj1 = obj2;
            obj2 = temp;
        }
    }
}
