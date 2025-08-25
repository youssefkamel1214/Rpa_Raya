namespace FirstDemo
{

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }
    internal class Program
    {
        public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            SortedDictionary<string, int> result = new SortedDictionary<string, int>();
            Dictionary<string, int> count = new Dictionary<string, int>();
            foreach (var emp in employees)
            {
                if (result.ContainsKey(emp.Company))
                {
                    result[emp.Company] += emp.Age;
                    count[emp.Company] += 1;
                }
                else
                {
                    result[emp.Company] = emp.Age;
                    count[emp.Company] = 1;
                }
             
            }
            foreach (var key in result.Keys.ToList())
            {
                result[key] =Convert.ToInt32(Math.Round( (double)result[key] /(double) count[key]));
            }
            return result.ToDictionary(x => x.Key, x => x.Value);
        }

        public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            SortedDictionary<string, int> count = new SortedDictionary<string, int>();
            foreach (var emp in employees)
            {
                if (count.ContainsKey(emp.Company))
                {
                    count[emp.Company] += 1;
                }
                else
                {
                    count[emp.Company] = 1;
                }
            }
            return count.ToDictionary(x => x.Key, x => x.Value);
        }

        public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            SortedDictionary<string, Employee> result = new SortedDictionary<string, Employee>();
            foreach (var emp in employees)
            {
                
                if(result.ContainsKey(emp.Company))
                {
                    if(result[emp.Company].Age < emp.Age)
                    {
                        result[emp.Company] = emp;
                    }
                }
                else
                {
                    result[emp.Company] = emp;
                }
            }
            return result.ToDictionary(x => x.Key, x => x.Value);
        }
        static void Main(string[] args)
        {
            int countOfEmployees = int.Parse(Console.ReadLine());

            var employees = new List<Employee>();

            for (int i = 0; i < countOfEmployees; i++)
            {
                string str = Console.ReadLine();
                string[] strArr = str.Split(' ');
                employees.Add(new Employee
                {
                    FirstName = strArr[0],
                    LastName = strArr[1],
                    Company = strArr[2],
                    Age = int.Parse(strArr[3])
                });
            }

            foreach (var emp in AverageAgeForEachCompany(employees))
            {
                Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in CountOfEmployeesForEachCompany(employees))
            {
                Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in OldestAgeForEachCompany(employees))
            {
                Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
            }
        }
    }
}


