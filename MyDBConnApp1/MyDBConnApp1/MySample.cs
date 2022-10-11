using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyDBConnApp1
{
    public class MySample
    {
        private static string strConn = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog = BOARD; Integrated Security = true";
        private static SqlConnection connection;

        /**
         * 
         * 일반 쿼리문 사용
         * 게시글 단건 조회
         */
        public void SelectById()
        {
            List<Board> boards = new List<Board>();

            Console.Write("게시글 번호를 입력하세요 : ");
            int boardId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(strConn))
            {
                Board selectedBoard = new Board();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * from dbo.TB_Board where Board_Id = " + boardId;

                try
                {
                    connection.Open();
                    Console.WriteLine("DB연결에 성공 하였습니다.");
                }
                catch (Exception)
                {
                    Console.WriteLine("DB연결에 실패 하였습니다.");
                }

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Board board = new Board();
                    board.Board_Id = int.Parse(reader["Board_Id"].ToString());

                    boards.Add(board);
                }

                connection.Close();

                foreach (var item in boards)
                {
                    Console.Write(JsonConvert.SerializeObject(item));
                }

                Console.WriteLine();
            }

        }

        /**
         * 
         * 프로시저 사용
         */
        public void SelectByIdProcedure()
        {
            List<Board> boardList = new List<Board>();
            Console.Write("게시글 번호를 입력하세요 : ");
            int boardId = int.Parse(Console.ReadLine());

            using (connection = new SqlConnection(strConn))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "[dbo].[UP_BOARD_TB_BOARD_R]"; // 프로시저명
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SEQ", boardId);


                try
                {
                    connection.Open();
                    Console.WriteLine("DB 연결 성공");
                }
                catch (Exception e)
                {
                    Console.WriteLine("DB 연결 실패 ! " + e.Message);
                }

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Board board = new Board();
                    board.Board_Id = int.Parse(reader["SEQ"].ToString());

                    boardList.Add(board);
                }

                connection.Close();

                foreach (var item in boardList)
                {
                    Console.Write(JsonConvert.SerializeObject(item));
                }

                Console.WriteLine();

            }

         }

        public void UpdateByProcedure()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = conn;

                    cmd.CommandText = "[dbo].[UP_BOARD_TB_BOARD_U]"; // 프로시저명

                    cmd.CommandType = CommandType.StoredProcedure;

                    // 데이터 입력
                    Console.Write("수정하실 번호를 입력해 주세요.");
                    int num = int.Parse(Console.ReadLine());
                    cmd.Parameters.AddWithValue("@SEQ", num);

                    Console.Write("수정하실 내용을 입력해 주세요 : ");
                    string contents = Console.ReadLine();
                    cmd.Parameters.AddWithValue("@CONTENT", contents);

                    // 명령을 수행하고 영향을 받은 행의 수를 반환
                    int result = cmd.ExecuteNonQuery();
                    if (result == 0)
                    {
                        Console.WriteLine("존재하지 않는 번호입니다.");
                        return;
                    }

                    Console.Write("정말로 수정하시겠습니까 ? (Y/N)");
                    string str = Console.ReadLine();
                    if (str.ToUpper() == "Y")
                    {
                        Console.WriteLine("게시글이 수정되었습니다.");
                    }
                    else
                    {
                        Console.WriteLine("Y 또는 N을 입력해주세요.");
                        return;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("숫자만 입력 가능합니다.");
                }
            }
        }
    }

}
