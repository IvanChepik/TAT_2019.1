using System;

namespace Materials.Materials
{
    /// <summary>
    /// Class Lab
    /// model of real life.
    /// </summary>
    public class Lab : Material, ICloneable
    {
        public Lecture Lecture { get; }
        public Lab(string information, Lecture lecture) : base(information)
        {
            lecture.AddLabs(this);
            Lecture = lecture;
        }

        public Lab(MaterialData materialData, Lecture lecture) : base(materialData)
        {
            lecture.AddLabs(this);
        }

        public object Clone()
        {
            return new Lab(MaterialData, Lecture);        
        }
    }
}