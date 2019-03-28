using System.Collections.Generic;
using Materials.Materials;

namespace Materials
{
    /// <summary>
    /// class Discipline
    /// included list of all lectures of this discipline
    /// </summary>
    public class Discipline : Material
    {
        private readonly List<Lecture> _lectures;

        public List<Material> this[int index] => GetAllMaterials(_lectures[index]);

        public Discipline(string information) : base(information)
        {
            _lectures = new List<Lecture>();
        }

        /// <summary>
        /// Method GetAllMaterials
        /// return all materials (seminars, labs) of argument lecture.
        /// </summary>
        /// <param name="lecture">lecture which has necessary materials</param>
        /// <returns>list of all materials</returns>
        private List<Material> GetAllMaterials(Lecture lecture)
        {
            var lectureMaterials = new List<Material>();
            lectureMaterials.AddRange(lecture.Seminars);
            lectureMaterials.AddRange(lecture.Labs);
            lectureMaterials.Add(lecture);
            return lectureMaterials;
        }

        public void AddLectures(params Lecture[] lectures)
        {
            _lectures.AddRange(lectures);
        }

    }
}