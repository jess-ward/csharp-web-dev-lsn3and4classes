using System;
namespace SchoolPractice
{
    public class Student
    {
        private static int nextStudentId = 1;
        public string Name { get; set; }
        public int StudentId { get; set; }
        public int NumberOfCredits { get; set; }
        public double Gpa { get; set; }

        public Student(string name, int studentId,
            int numberOfCredits, double gpa)
        {
            Name = name;
            StudentId = studentId;
            NumberOfCredits = numberOfCredits;
            Gpa = gpa;
        }

        public Student(string name, int studentId)
        : this(name, studentId, 0, 0) { }

        public Student(string name)
        : this(name, nextStudentId)
        {
            nextStudentId++;
        }

        // TODO: Complete the AddGrade method.
        public void AddGrade(int courseCredits, double grade)
        {
            // Update the appropriate properties: NumberOfCredits, Gpa
            
            double totalQualityScore = Gpa * NumberOfCredits; //Calculate their current total quality score by using the formula gpa * numberOfCredits.

            totalQualityScore += courseCredits * grade; //Use the new course grade and course credits to update their total quality score

            NumberOfCredits += courseCredits; //Update the student’s total numberOfCredits

            Gpa = totalQualityScore / NumberOfCredits; //gpa = (total quality score) / (total number of credits)

        }

        //TODO: Complete the GetGradeLevel method here:
        public string GetGradeLevel(int credits)
        {
            // Determine the grade level of the student based on NumberOfCredits
            //Freshman (0-29 credits), Sophomore (30-59 credits), Junior (60-89 credits), or Senior (90+ credits)
            if (credits <= 29)
            {
                return "freshman";
            }
            else if (credits <= 59)
            {
                return "sophomore";
            }
            else if (credits <= 89)
            {
                return "junior";
            }
            else
            {
                return "senior";
            }
        }


        // TODO: Add your custom 'ToString' method here. Make sure it returns a well-formatted string rather
        //  than just the class fields.
        public override string ToString()
        {
            return $"{Name} Credits: {NumberOfCredits} GPA: {Gpa}";
        }


        // TODO: Add your custom 'Equals' method here. Consider which fields should match in order to call two
        //  Student objects equal.
        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }

            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            Student studentObj = obj as Student;
            return StudentId == studentObj.StudentId;
        }

        public override int GetHashCode()
        {
            return StudentId;
        }

    }
}
