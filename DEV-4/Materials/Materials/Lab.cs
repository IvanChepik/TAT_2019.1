using System;

namespace Materials.Materials
{
    /// <summary>
    /// Class Lab
    /// included a property Lecture, which corresponds to this lab.
    /// </summary>
    public class Lab : Material, ICloneable
    {
        public Lecture Lecture { get; }

        /// <summary>
        /// Constructor Lab
        /// Create new object Lab and set a ref to corresponded lecture and add this to list of corresponded lecture.
        /// </summary>
        /// <param name="information">information which included in material data</param>
        /// <param name="lecture">corresponded lecture</param>
        public Lab(string information, Lecture lecture) : base(information)
        {
            lecture.AddLabs(this);
            Lecture = lecture;
        }

        /// <summary>
        /// Constructor Lab
        /// for clone.
        /// </summary>
        /// <param name="materialData">create new object Material Data which is copied by this</param>
        /// <param name="lecture">set a ref on this lecture</param>
        public Lab(MaterialData materialData, Lecture lecture) : base(materialData)
        {
            lecture.AddLabs(this);
        }

        /// <summary>
        /// Method Clone
        /// create new object with identical parameters
        /// </summary>
        /// <returns>copy of this object</returns>
        public object Clone()
        {
            return new Lab(MaterialData, Lecture);        
        }
    }
}