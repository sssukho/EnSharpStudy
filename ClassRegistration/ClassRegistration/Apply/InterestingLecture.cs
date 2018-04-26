using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRegistration
{
    enum LectureSearch { EXIT, DEPARTMENT, LECTURE_INDEX, LECTURE_NAME, YEAR, PROFESSOR, INTERESTING_LECTURE }
    class InterestingLecture
    {
        Menu menu;
        List<InterestingLectureVO> interestingLectureList;

        public InterestingLecture(Menu menu, List<InterestingLectureVO> interstingLectureList)
        {
            this.menu = menu;
            this.interestingLectureList = interstingLectureList;
        }

        public void SearchLecture(int searchType)
        {

        }

        public void AddLecture()
        {

        }

        public void RemoveLecture()
        {

        }

        public void JoinInterstingLecture()
        {

        }
    }
}
