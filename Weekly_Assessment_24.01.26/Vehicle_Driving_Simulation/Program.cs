using System;

public class Vehicle
{
    //your code goes here
    protected int wheels;
    public Vehicle(int wheels)
    {
        this.wheels = wheels;
    }
    public virtual string Drive()
    {
        return $"{wheels} wheeler driving";
    }    
}

class TwoWheeler : Vehicle
{
   //your code goes here
   public TwoWheeler() : base(2){}

}

class HMV : Vehicle
{
    //your code goes here
    public HMV(int wheels) : base(wheels){}
}

class Source
{
    static void Main(string[] args)
    {
       //your code goes here
       Vehicle obj1 = new TwoWheeler();
       Vehicle obj2 = new HMV(8);

       Console.WriteLine(obj1.Drive());
       Console.WriteLine(obj2.Drive());
    }
}
