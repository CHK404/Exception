using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_13_Exception
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                Console.Write("숫자를 입력하세요: ");
                string Input = Console.ReadLine();

                //문자열 정수 변환
                int number = int.Parse(Input);

                //입력 받은 숫자로 100 나눔
                int result = 100 / number;

                //추가 throw: 개발자가 의도적으로 오류를 발생시킴
                if(number < 0)
                {
                    throw new Exception("예외 발생. 개발자가 발생시킨 에러");
                }

                Console.WriteLine($"100 / {number} = {result}");
            }
            //.NET이 제공하는 기본 예외 클래스 중 일부
            catch(DivideByZeroException)
            {
                Console.WriteLine("오류: 0으로 나눌 수 없습니다.");
                Console.WriteLine($"[예외 메세지]: ");
            }
            catch (FormatException)
            {
                Console.WriteLine("오류: 숫자가 아닌 값을 입력하셨습니다.");
                Console.WriteLine($"[예외 메세지]: ");
            }
            catch (Exception ex)
            {
                /*
                 * 그 외 모든 예외 처리(예외 최상위 클래스) 
                 * 발생한 예외 객체를 Exception 타입으로 받아서 ex라는 객체명으로 사용 가능
                 * 
                 * Exception ex 객체로 할 수 있는 것
                 * ex.Message: 예외 메세지(사람이 읽을 수 있는 오류 설명)
                 * ex.StackMessage: 예외가 어디서 발생했는지 추적 정보
                 * ex.GetType(): 발생한 예외의 정확한 타입 반환
                 */
                Console.WriteLine("오류: 예기치 못한 오류가 발생했습니다.");
                Console.WriteLine($"[예외 메세지]: {ex.Message}");
                Console.WriteLine($"[예외 타입]: {ex.GetType()}");
                Console.WriteLine($"[스택 정보]: {ex.StackTrace}");

                Console.WriteLine("===================================");
                //참고) Console.WriteLine(ex);

                /*
                 * 주의사항
                 * 1. catch(Exception ex)는 마지막에 배치
                 * ㄴ 구체적인 예외를 먼저, 범용 Exception은 마지막
                 * 2. 예외를 너무 광범위하게 처리시 디버깅이 어려워지고 어떤 예외가 발생했는지 파악하기 힘듬
                 */
            }
            finally
            {
                //예외 발생 여부에 관계없이 실행되는 블록
                Console.WriteLine("프로그램을 종료합니다. 감사합니다.");
                Console.ReadLine();
            }

            //ex
            try
            {
                Console.Write("닉네임을 입력해주세요. ");
                string idInput = Console.ReadLine();

                if (idInput == "")
                {
                    throw new Exception("닉네임을 입력해주세요.");
                }
                if (idInput.Length < 2)
                {
                    throw new Exception("닉네임은 두글자 이상이어야 합니다.");
                }
                if (idInput.Contains("admin"))
                {
                    throw new Exception("닉네임에 admin은 포함할 수 없습니다.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("오류가 발생했습니다.");
                Console.WriteLine($"[예외 메세지]: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("프로그램을 종료합니다.");
            }
        }
        /*
         * ex객체 찍어볼 수 있다
         * Exception 객체는 .NET Framework의 내부 클래스이긴 하지만 볼 수 없는 건 아니다
         * 하지만 내부적인 모든 내용을 볼 수 있는건 아니다
         * 
         * Exception 클래스는 마이크로소프트가 제공하는 공식 문서와 오픈 소스 레포를 통해
         * 전체 속성, 메서드, 구조까지 전부 확인이 가능
         */
    }
}
