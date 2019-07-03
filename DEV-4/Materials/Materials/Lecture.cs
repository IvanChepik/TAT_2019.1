using System;
using System.Collections.Generic;

namespace Materials.Materials
{
    /// <summary>
    /// Class Lecture
    /// included list of seminars and list of labs and a property discipline, which corresponds to this lecture.
    /// </summary>
    public class Lecture : Material, ICloneable
    {
        private string _textLecture;

        public Discipline Discipline { get; }
        public string TextLecture
        {
            get => _textLecture;

            set
            {
                if (value.Length > 100000 || value.Length == 0)
                {
                    throw new WrongLengthException("Your lecture's text is wrong");
                }

                _textLecture = value;
            }
        }

        public int CountOfLabs => Labs.Count;

        public int CountOfSeminar => Seminars.Count;

        public List<Seminar> Seminars { get; }

        public List<Lab> Labs { get; }

        public Presentation Presentation { get; }

        /// <summary>
        /// Constructor Lecture
        /// create new object Lecture and create lists of seminars and labs.
        /// </summary>
        /// <param name="textLecture">text of lecture</param>
        /// <param name="url">url of presentation. Create new presentation by this</param>
        /// <param name="information">create new presentation by this and new object Material Data which is included in Lecture</param>
        /// <param name="format">format of presentation</param>
        /// <param name="discipline">discipline which fits it</param>
        public Lecture(string textLecture, string url, string information, PresentationFormat format, Discipline discipline) : base(information)
        {
            TextLecture = textLecture;
            Presentation = new Presentation(url, information, format);
            Seminars = new List<Seminar>();
            Labs = new List<Lab>();
            discipline.AddLectures(this);
            Discipline = discipline;
        }

        /// <summary>
        /// Constructor Lecture
        /// for clone.
        /// </summary>
        /// <param name="textLecture">text of lecture</param>
        /// <param name="url">url of presentation. Create new presentation by this</param>
        /// <param name="materialData">create new presentation by this and new object Material Data which is copied by this</param>
        /// <param name="format">format of presentation</param>
        /// <param name="discipline">discipline which fits it</param>
        private Lecture(string textLecture, string url, MaterialData materialData, PresentationFormat format, Discipline discipline) : base(materialData)
        {
            TextLecture = textLecture;
            Presentation = new Presentation(url, materialData.Information, format);
            Seminars = new List<Seminar>();
            Labs = new List<Lab>();
            discipline.AddLectures(this);
            Discipline = discipline;
        }
        public void AddSeminars(params Seminar[] seminar)
        {
            Seminars.AddRange(seminar);
        }

        public void AddLabs(params Lab[] lab)
        {
            Labs.AddRange(lab);
        }

        /// <summary>
        /// Method Clone
        /// Create new object of type Lecture with identical parameters
        /// and list of new labs and seminars with identical parameters.
        /// </summary>
        /// <returns>return copy of Lecture object</returns>
        public object Clone()
        {
            var cloneLecture = new Lecture(TextLecture, Presentation.Url, MaterialData, Presentation.PresentationFormat, Discipline);
            foreach (var lab in Labs)
            {
                new Lab(lab.MaterialData, cloneLecture);
            }

            foreach (var seminar in Seminars)
            {
                new Seminar(seminar.MaterialData, cloneLecture);
            }

            return cloneLecture;
        }
    }
}