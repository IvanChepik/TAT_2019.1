namespace Materials
{
    /// <summary>
    /// Class Material
    /// including main fields for entity and has override methods
    /// </summary>
    public abstract class Material
    {
        public MaterialData MaterialData { get; }

        public Material(string information)
        {
            MaterialData = new MaterialData(information);
        }

        public Material(MaterialData materialData)
        {
            MaterialData = new MaterialData(materialData.Information,materialData.Guid);
        }

        public override string ToString()
        {
            return MaterialData.Information;
        }

        public override bool Equals(object obj)
        {
            return obj is Material compareObj && MaterialData.Guid == compareObj.MaterialData.Guid;
        }

        public override int GetHashCode()
        {
            return MaterialData.Guid.GetHashCode();
        }
    }
}