

namespace Models
{
    public abstract class Employee
    {
        public abstract decimal Sum { get; }
        public  abstract int Productivity { get;  }
        public decimal Coef => Productivity / Sum;
    }
}
