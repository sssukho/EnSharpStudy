using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRegistration
{
    class InterestingLectureVO
    {
        object department;
        object lectureIndex;
        object classIndex;
        object lectureName;
        object division;
        object year;
        object grade;
        object time;
        object classroom;
        object professor;
        object language;

        public InterestingLectureVO(object department, object lectureIndex, object classIndex, object lectureName, object division, object year, object grade, object time, object classroom, object professor, object language)
        {
            this.department = department;
            this.lectureIndex = lectureIndex;
            this.classIndex = classIndex;
            this.lectureName = lectureName;
            this.division = division;
            this.year = year;
            this.grade = grade;
            this.time = time;
            this.classroom = classroom;
            this.professor = professor;
            this.language = language;
        }

        public object Department
        {
            get { return department; }
            set { department = value; }
        }

        public object LectureIndex
        {
            get { return lectureIndex; }
            set { lectureIndex = value; }
        }

        public object ClassIndex
        {
            get { return classIndex; }
            set { classIndex = value; }
        }

        public object LectureName
        {
            get { return lectureName; }
            set { lectureName = value; }
        }

        public object Division
        {
            get { return division; }
            set { division = value; }
        }

        public object Year
        {
            get { return year; }
            set { year = value; }
        }

        public object Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public object Time
        {
            get { return time; }
            set { time = value; }
        }

        public object Classroom
        {
            get { return classroom; }
            set { classroom = value; }
        }

        public object Professor
        {
            get { return professor; }
            set { professor = value; }
        }

        public object Language
        {
            get { return language; }
            set { language = value; }
        }
    }
}
