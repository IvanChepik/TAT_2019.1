

namespace Models
{
    /// <summary>
    /// Class Junior
    /// describes cost and productivity of real object Junior.
    /// </summary>
    public class Junior : Employee
    {
        public override decimal Sum => 500;
        public override int Productivity => 300;
    }
}
