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

        public void AddNewTask(string task)
        {
            _tasks.Add(task);
        }

        public void AddNewQuestion(string question, string answer)
        {
            _questionsAndAnswers.Add(question, answer);
        }

        public Seminar(MaterialData materialData, Lecture lecture) : base(materialData)
        {
            _tasks = new List<string>();
            _questionsAndAnswers = new Dictionary<string, string>();
            lecture.AddSeminars(this);           
        }

        public object Clone()
        {
            return new Seminar(MaterialData, Lecture);
        }
    }
}