using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassRegistration
{
    class LectureVO
    {
        int index;
        string department;
        string lectureIndex;
        string classIndex;
        string lectureName;
        string division;
        string year;
        string grade;
        string time;
        string classroom;
        string professor;
        string language;
        

        public LectureVO(object department, object lectureIndex, object classIndex, object lectureName, object division, object year, object grade, object time, object classroom, object professor, object language)
        {
            this.department = department.ToString();
            this.lectureIndex = lectureIndex.ToString();
            this.classIndex = classIndex.ToString();
            this.lectureName = lectureName.ToString();
            this.division = division.ToString();
            this.year = year.ToString();
            this.grade = grade.ToString();
            this.time = time.ToString();
            this.professor = professor.ToString();
            this.language = language.ToString();
            if (classroom == null)
            {
                this.classroom = " ";
                return;
            }
            this.classroom = classroom.ToString();
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public string LectureIndex
        {
            get { return lectureIndex; }
            set { lectureIndex = value; }
        }

        public string ClassIndex
        {
            get { return classIndex; }
            set { classIndex = value; }
        }

        public string LectureName
        {
            get { return lectureName; }
            set { lectureName = value; }
        }

        public string Division
        {
            get { return division; }
            set { division = value; }
        }

        public string Year
        {
            get { return year; }
            set { year = value; }
        }

        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        public string Classroom
        {
            get { return classroom; }
            set { classroom = value; }
        }

        public string Professor
        {
            get { return professor; }
            set { professor = value; }
        }

        public string Language
        {
            get { return language; }
            set { language = value; }
        }
    }
}
