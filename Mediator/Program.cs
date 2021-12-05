using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();

            Teacher teacher = new Teacher(mediator);
            Student student = new Student(mediator);

            mediator.Teacher = teacher;
            mediator.Students= new List<Student>{student};

            teacher.SendNewImageUrl("image.png");

            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved question from {0},{1}", student.Name, question);
        }

        public void SendNewImageUrl(string imageUrl)
        {
            Console.WriteLine("Teacher Changed Slide: {0}",imageUrl);
            Mediator.UpdateImage(imageUrl);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered the question {0},{1}",student.Name,answer);
        }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {

        }

        public void RecieveImage(string imageUrl)
        {
            Console.WriteLine("Student recieved image: {0}",imageUrl);

        }

        public void RecieveAnswer(string answer, Student student)
        {
            Console.WriteLine("student recieved answer: {0}",answer);
        }

        public string Name { get; set; }


    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string imageUrl)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(imageUrl);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer, student);
        }
    }

}
