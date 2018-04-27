using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;


namespace ClassRegistration
{
    class SearchLecture
    {
        public SearchLecture()
        {
        }

        public void SearchDepartment(List<LectureListVO> lectureList)
        {
            Print print = new Print();
            string inputDepartment;

            print.InputMsg("개설학과 전공");
            inputDepartment = Console.ReadLine();

            List<LectureListVO> foundList = lectureList.FindAll(lecture => lecture.Department.Equals(inputDepartment));
            print.ShowLecture(foundList);
        }

        public void SearchLectureIndex()
        {

        }

        public void SearchLectureName()
        {

        }

        public void SearchYear()
        {

        }

        public void SearchProfessor()
        {

        }

        public void SearchInterstingLecture()
        {

        }
    }
}
