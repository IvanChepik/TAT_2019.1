using System;
using Materials;
using Materials.Materials;

namespace DEV_4
{
    /// <summary>
    /// This program is a gathering of classes of studying materials
    /// </summary>
    public class EntryPoint
    {
        /// <summary>
        /// Method Main
        /// Entry point.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            try
            {
                var history = new Discipline("history");
                var lecture = new Lecture("textLecture", "URL", "Info", PresentationFormat.PDF, history);
                var lab = new Lab("LabInfo", lecture);
                var seminar = new Seminar("SeminarInfo",lecture);
                var lecture2 = lecture.Clone() as Lecture;
                var lab2 = lab.Clone() as Lab;
                //Console.WriteLine(lab.MaterialData.Information);
                //////Console.WriteLine(lab2.MaterialData.Information);
                //lab2.MaterialData.Information = "LabInfo2";
                //Console.WriteLine(lab.MaterialData.Information);
                //Console.WriteLine(lab2.MaterialData.Information);
                Console.WriteLine(lecture.Lentg);
                Console.WriteLine(lecture2.Lentg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
