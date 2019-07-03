namespace Materials
{
    /// <summary>
    /// Class Material
    /// including MaterialData of materials entity and has override methods
    /// </summary>
    public abstract class Material
    {
        public MaterialData MaterialData { get; }

        /// <summary>
        /// Constructor Material
        /// create new object materialdata for this Material object.
        /// </summary>
        /// <param name="information">information about entity</param>
        public Material(string information)
        {
            MaterialData = new MaterialData(information);
        }

        /// <summary>
        /// Constructor Material
        /// for copy
        /// </summary>
        /// <param name="information">information about entity</param>
        public Material(MaterialData materialData)
        {
            MaterialData = new MaterialData(materialData.Information,materialData.Guid);
        }

        /// <summary>
        /// Method ToString
        /// return information about this entity
        /// </summary>
        /// <returns>information about this entity</returns>
        public override string ToString()
        {
            return MaterialData.Information;
        }

        /// <summary>
        /// Method Equals
        /// compare two object by their guid.
        /// </summary>
        /// <param name="obj">object to compare</param>
        /// <returns>true if equals or false</returns>
        public override bool Equals(object obj)
        {
            return obj is Material compareObj && MaterialData.Guid == compareObj.MaterialData.Guid;
        }

        /// <summary>
        /// Method GetHashCode
        /// is override because Equals is override
        /// for avoid problems with HashSet and Dictionary.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return MaterialData.Guid.GetHashCode();
        }
    }
}