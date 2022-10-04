namespace ConsoleAppUserInput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
=================================
0. 데이터 입력(5개)
1. 최소값
2. 최대값
3. 프로그램 종료
=================================
");
            List<double> dataList = new List<double>();
            bool isDataInput = false;
            bool isExit = false;
            double? input;

            Func<double?> fnInput = () =>
            {
                double rtn;
                var input = Console.ReadLine();
                if (Double.TryParse(input, out rtn))
                {
                    return rtn;
                }
                return null;
            };

            Func<bool> fnDataInput = () =>
            {
                Console.WriteLine($"{dataList.Count + 1}번째 값 입력:");
                var data = fnInput();
                if (data == null)
                {
                    Console.WriteLine("숫자를 입력해 주세요.");
                }
                else
                {
                    dataList.Add(data.Value);
                    if (dataList.Count == 5) return false;
                }
                return true;
            };

            do
            {
                if (isDataInput)
                {
                    if (!fnDataInput())
                    {
                        isDataInput = false;
                    }
                }
                else
                {
                    Console.WriteLine("메뉴 선택:");
                    input = fnInput();
                    switch (input)
                    {
                        case 0:
                            dataList.Clear();
                            isDataInput = true;
                            fnDataInput();
                            break;
                        case 1:
                            if (dataList.Count > 0)
                            {
                                Console.WriteLine($"최소값: {dataList.Min()}");
                            }
                            else
                            {
                                Console.WriteLine("0번 메뉴를 선택해서 데이터를 입력하세요.");
                            }
                            break;
                        case 2:
                            if (dataList.Count > 0)
                            {
                                Console.WriteLine($"최대값: {dataList.Max()}");
                            }
                            else
                            {
                                Console.WriteLine("0번 메뉴를 선택해서 데이터를 입력하세요.");
                            }
                            break;
                        case 3:
                            isExit = true;
                            break;
                        default:
                            Console.WriteLine("1~3까지 메뉴를 선택하세요.");
                            break;
                    }
                }
            }
            while (!isExit);
        }
    }
}