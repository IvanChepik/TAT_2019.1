namespace Models
{
    /// <summary>
    /// Class Lead
    /// describes cost and productivity of real object Lead.
    /// </summary>
    public class Lead : Senior
    {
        public override decimal Sum => 5000;
        public override int Productivity => 2300;
    }
}
