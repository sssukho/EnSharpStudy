using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace LibraryManagement
{
    /// <summary>
    /// 로그 관리 클래스(관리자 전용)
    /// 로그 테이블에 추가하는 방식 -> 매 메소드의 끝부분에 로그 테이블에 Insert
    /// </summary>
    class DBManagement
    {
        AdminMenu adminMenu;
        DAO dao;
        Print print;
        ErrorCheck errorCheck;
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public DBManagement(AdminMenu adminMenu, DAO dao)
        {
            this.adminMenu = adminMenu;
            this.dao = dao;
            print = Print.GetInstance();
            errorCheck = ErrorCheck.GetInstance();
        }

        public void InitLog()
        {
            dao.InitLog();
            print.CompleteMsg("로그 테이블 초기화 완료");
            adminMenu.DBManagementMenu();
        }

        public void CheckLog()
        {
            print.PrintLog(dao.SelectLog());
            print.PreviousCheck();
            adminMenu.DBManagementMenu();
        }

        public void SaveLogFile()
        {
            MySqlDataReader dataReader;
            dataReader = dao.SelectLog();

            using (StreamWriter outputFile = new StreamWriter(filePath+"\\LogFile.txt"))
            {
               while(dataReader.Read())
                {
                    outputFile.WriteLine(dataReader["id"].ToString() + "    " + dataReader["action"].ToString() + "    " +
                        dataReader["keyword"].ToString() + "     " + dataReader["time"].ToString());
                }
            }
            dao.InsertLog("관리자", "로그 파일로 내보내기", null, DateTime.Now);
            print.CompleteMsg("로그 내역 텍스트 파일로 바탕화면에 생성 완료");
            adminMenu.DBManagementMenu();
        }

        public void RemoveLogFile()
        {
            filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if(File.Exists(filePath + "\\LogFile.txt") == false)
            {
                print.RemoveLogError();
                print.PreviousCheck();
                adminMenu.DBManagementMenu();
                return;
            }

            File.Delete(filePath + "\\LogFile.txt");
            print.CompleteMsg("로그 내역 삭제 완료");
            dao.InsertLog("관리자", "로그삭제", null, DateTime.Now);
            adminMenu.DBManagementMenu();
        }
    }
}
