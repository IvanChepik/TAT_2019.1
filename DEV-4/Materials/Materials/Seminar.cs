using System;
using System.Collections.Generic;

namespace Materials.Materials
{
    public class Seminar : Material, ICloneable
    {
        private List<string> _tasks;
        private Dictionary<string, string> _questionsAndAnswers;

        public Lecture Lecture { get; }

        public Seminar(string information, Lecture lecture) : base(information)
        {
            _tasks = new List<string>();
            _questionsAndAnswers = new Dictionary<string, string>();
            lecture.AddSeminars(this);
            Lecture = lecture;
        }

        public Seminar(MaterialData materialData) : base(materialData)
        {
            _tasks = new List<string>();
            _questionsAndAnswers = new Dictionary<string, string>();
            Lecture.AddSeminars(this);
            
        }

        public object Clone()
        {
            return new Seminar(MaterialData);
        }
    }
}