using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name 
        {
            get; set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public virtual event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public virtual Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }

    public class InMemoryBook: Book
    {
        private List<double> grades;


        public InMemoryBook(string name) : base(name)
        {
            Name = name;
            grades = new List<double>();
        }
        public override void AddGrade(double grade){
            if (grade <= 100 && grade >= 0) {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            } else {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
            
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics(){

            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            for(var i = 0; i < grades.Count; i++){
                result.High = Math.Max(grades[i], result.High);
                result.Low = Math.Min(grades[i], result.Low);
                result.Average += grades[i];
            }

            result.Average /= grades.Count;

            switch(result.Average){
                case var d when d >= 90.00:
                    result.Letter = "A";
                    break;
                case var d when d >= 80.00:
                    result.Letter = "B";
                    break;
                case var d when d >= 70.00:
                    result.Letter = "C";
                    break;
                case var d when d >= 60.00:
                    result.Letter = "D";
                    break;
                default:
                    result.Letter = "F";
                    break;
            }

            return result;
        }
    }
}