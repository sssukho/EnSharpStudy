using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRegistration
{
    class TimeTableLectureVO
    {
        int frontTime;
        int backTime;
        int pracFrontTime;
        int pracBackTime;
        bool isPrac;
        bool monday;
        bool tuesday;
        bool wednesday;
        bool thursday;
        bool friday;
        string pracDay;
        string classroom;
        string lectureName;

        public TimeTableLectureVO(int frontTime, int backTime, int pracFrontTime, int pracBackTime, bool isPrac, bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, string classroom, string lectureName, string pracDay)
        {
            this.frontTime = frontTime;
            this.backTime = backTime;
            this.pracFrontTime = pracFrontTime;
            this.pracBackTime = pracBackTime;
            this.isPrac = isPrac;
            this.monday = monday;
            this.tuesday = tuesday;
            this.wednesday = wednesday;
            this.thursday = thursday;
            this.friday = friday;
            this.classroom = classroom;
            this.lectureName = lectureName;
            this.pracDay = pracDay;
        }

        public int FrontTime
        {
            get { return frontTime; }
            set { frontTime = value; }
        }

        public int BackTime
        {
            get { return backTime; }
            set { backTime = value; }
        }

        public int PracFrontTime
        {
            get { return pracFrontTime; }
            set { pracFrontTime = value; }
        }

        public int PracBackTime
        {
            get { return pracBackTime; }
            set { pracBackTime = value; }
        }

        public bool IsPrac
        {
            get { return isPrac; }
            set { isPrac = value; }
        }

        public bool Monday
        {
            get { return monday; }
            set { monday = value; }
        }

        public bool Tuesday
        {
            get { return tuesday; }
            set { tuesday = value; }
        }

        public bool Wednesday
        {
            get { return wednesday; }
            set { wednesday = value; }
        }

        public bool Thursday
        {
            get { return thursday; }
            set { thursday = value; }
        }

        public bool Friday
        {
            get { return friday; }
            set { friday = value; }
        }

        public string Classroom
        {
            get { return classroom; }
            set { classroom = value; }
        }
        
        public string LectureName
        {
            get { return lectureName; }
            set { lectureName = value; }
        }

        public string PracDay
        {
            get { return pracDay; }
            set { pracDay = value; }
        }
    }
}
