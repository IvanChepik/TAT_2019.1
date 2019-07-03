using System;
using System.Collections.Generic;

namespace Materials.Materials
{
    /// <summary>
    /// Class Seminar
    /// included a property Lecture, which corresponds to this Seminar.
    /// </summary>
    public class Seminar : Material, ICloneable
    {
        private List<string> _tasks;
        private Dictionary<string, string> _questionsAndAnswers;

        public Lecture Lecture { get; }

        /// <summary>
        /// Constructor Seminar
        /// Create new object Seminar and set a ref to corresponded lecture and add this to list of corresponded lecture.
        /// </summary>
        /// <param name="information">information which included in material data</param>
        /// <param name="lecture">corresponded lecture</param>
        public Seminar(string information, Lecture lecture) : base(information)
        {
            _tasks = new List<string>();
            _questionsAndAnswers = new Dictionary<string, string>();
            lecture.AddSeminars(this);
            Lecture = lecture;
        }

        /// <summary>
        /// Constructor Seminar
        /// for clone
        /// </summary>
        /// <param name="materialData">create new object Material Data which is copied by this</param>
        /// <param name="lecture">set a ref on this lecture</param>
        public Seminar(MaterialData materialData, Lecture lecture) : base(materialData)
        {
            _tasks = new List<string>();
            _questionsAndAnswers = new Dictionary<string, string>();
            lecture.AddSeminars(this);
        }

        public void AddNewTask(string task)
        {
            _tasks.Add(task);
        }

        public void AddNewQuestion(string question, string answer)
        {
            _questionsAndAnswers.Add(question, answer);
        }

        /// <summary>
        /// Method Clone
        ///  create new object with identical parameters
        /// </summary>
        /// <returns>copy of this object</returns>
        public object Clone()
        {
            return new Seminar(MaterialData, Lecture);
        }
    }
}