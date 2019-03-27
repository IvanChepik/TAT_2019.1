using System;
using System.Collections.Generic;

namespace Materials.Materials
{
    /// <summary>
    /// Lecture 
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

        public List<Seminar> Seminars { get; }

        public List<Lab> Labs { get; }

        public Presentation Presentation { get; }

        public Lecture(string textLecture, string url, string information, PresentationFormat format, Discipline discipline) : base(information)
        {
            TextLecture = textLecture;
            Presentation = new Presentation(url,information, format);
            Seminars = new List<Seminar>();
            Labs = new List<Lab>();
            discipline.AddLectures(this);
            Discipline = discipline;
        }

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

        public object Clone()
        {
            var cloneLecture = new Lecture(TextLecture, Presentation.Url, MaterialData, Presentation.PresentationFormat, Discipline);
            foreach (var lab in Labs)
            {
                cloneLecture.AddLabs(new Lab(lab.MaterialData, this));
            }

            foreach (var seminar in Seminars)
            {
                cloneLecture.AddSeminars(new Seminar(seminar.MaterialData));
            }

            return cloneLecture;
        }
    }
}