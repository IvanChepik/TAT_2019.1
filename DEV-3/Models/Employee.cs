namespace Models
{
    /// <summary>
    /// Abstract class Employee
    /// this class included common fields of all employes.
    /// </summary>
    public abstract class Employee
    {
        public abstract decimal Sum { get; }
        public  abstract int Productivity { get;  }
        public decimal Coef => Productivity / Sum;
    }
}
