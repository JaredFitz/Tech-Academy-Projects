using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeStudentCourses
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void assignment1Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a List of Courses (add three example Courses ...
             * make up the details).  Each Course should have at least two
             * Students enrolled in them.  Use Object and Collection
             * Initializers.  Then, iterate through each Course and print
             * out the Course's details and the Students that are enrolled in
             * each Course. (use foreach course and foreach student)
             */
            resultLabel.Text = "";
            var courses = new List<Course>() {
                new Course { CourseId = 1, Name = "Physical Education",
                    Students = new List<Student>() {
                        new Student { StudentId = 111, Name = "Jared Fitzpatrick" },
                        new Student { StudentId = 222, Name = "Damian Lillard" },
                        new Student { StudentId = 333, Name = "CJ McCollum"} } },
                new Course { CourseId = 2, Name = "Algebra",
                    Students = new  List<Student>() {
                        new Student { StudentId = 222, Name = "Damian Lillard" },
                        new Student { StudentId = 333, Name = "CJ McCollum" },
                        new Student { StudentId = 444, Name = "Jusuf Nurkic" } } },
                new Course { CourseId = 3, Name = "Chemistry",
                    Students = new List<Student>() {
                        new Student { StudentId = 111, Name = "Jared Fitzpatrick" },
                        new Student { StudentId = 333, Name = "CJ McCollum" },
                        new Student { StudentId = 444, Name = "Jusuf Nurkic" } } }
            };

            foreach (var course in courses)
            {
                resultLabel.Text += String.Format("Course: {0} - {1}<br/>",
                    course.CourseId,
                    course.Name );

                foreach (var student in course.Students)
                {
                    resultLabel.Text += String.Format("&nbsp&nbspStudent: {0} - {1}<br/>",
                        student.StudentId,
                        student.Name );
                }
            }
        }

        protected void assignment2Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a Dictionary of Students (add three example Students
             * ... make up the details).  Use the StudentId as the 
             * key.  Each student must be enrolled in two Courses.  Use
             * Object and Collection Initializers.  Then, iterate through
             * each student and print out to the web page each Student's
             * info and the Courses the Student is enrolled in.
             */
            resultLabel.Text = "";
            Course course1 = new Course() { CourseId = 1, Name = "Physical Education" };
            Course course2 = new Course() { CourseId = 2, Name = "Algebra" };
            Course course3 = new Course() { CourseId = 3, Name = "Chemistry" };

            Dictionary<int, Student> students = new Dictionary<int, Student>()
            {
                {1, new Student { StudentId = 111, Name = "Jared Fitzpatrick", Courses = new List<Course> {course1, course3} } },
                {2, new Student { StudentId = 222, Name = "Damian Lillard", Courses = new List<Course> {course1, course2} } },
                {3, new Student { StudentId = 333, Name = "CJ McCollum", Courses = new List<Course> {course2, course3} } }
            };

            foreach (var student in students)
            {
                resultLabel.Text += String.Format("Student: {0} - {1}<br/>",
                    student.Value.StudentId,
                    student.Value.Name);
                foreach (var course in student.Value.Courses)
                {
                    resultLabel.Text += String.Format("&nbsp&nbspCourse: {0} {1}<br/>",
                        course.CourseId,
                        course.Name);
                }
            }
        }

        protected void assignment3Button_Click(object sender, EventArgs e)
        {
            /*
             * We need to keep track of each Student's grade (0 to 100) in a 
             * particular Course.  This means at a minimum, you'll need to add 
             * another class, and depending on your implementation, you will 
             * probably need to modify the existing classes to accommodate this 
             * new requirement.  Give each Student a grade in each Course they
             * are enrolled in (make up the data).  Then, for each student, 
             * print out each Course they are enrolled in and their grade.
             */
            resultLabel.Text = "";

            var students = new List<Student>()
            {
                new Student { StudentId = 111, Name = "Jared Fitzpatrick",
                    Enrollments = new List<Enrollment>() {
                        new Enrollment { Grade = 92, Course = new Course { CourseId = 111, Name = "Physical Education"} },
                        new Enrollment { Grade = 85, Course = new Course { CourseId = 222, Name = "Chemistry" } } } },
                new Student { StudentId = 222, Name = "Damian Lillard",
                    Enrollments = new List<Enrollment>() {
                        new Enrollment { Grade = 98, Course = new Course { CourseId = 111, Name = "Physical Education"} },
                        new Enrollment { Grade = 83, Course = new Course { CourseId = 222, Name = "Algebra" } } } }
            };

            foreach (var student in students)
            {
                resultLabel.Text += String.Format("Student: {0} {1}<br/>", student.StudentId, student.Name);
                foreach (var enrollment in student.Enrollments)
                {
                    resultLabel.Text += String.Format("&nbsp&nbspEnrolled In: {0} - Grade: {1}<br/>",
                    enrollment.Course.Name,
                    enrollment.Grade);
                }
            }
        }
    }
}