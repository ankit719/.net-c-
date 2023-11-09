using System.Collections.Generic;

namespace crud_list_Demo02
{
    public enum Department { HR, TEC, Tester };
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Department dept { get; set; }

    }
    public interface IEmployee
    {
        public Employee GetEmployee(int id);
        public IEnumerable<Employee> getAll();
        public void Add(Employee emp);
        public void Delete(int emp);
        public Employee Update(Employee emp);
    }
    public class EmpFun : IEmployee
    {
        private static List<Employee> empList;
        public EmpFun()
        {
            empList = new List<Employee>() {  new Employee() { Id=1,Name="Ankit yadav",Age=24,dept=Department.HR},
            new Employee() { Id=2,Name="Prashant lakara",Age=23,dept=Department.Tester},
            new Employee() { Id=3,Name="Satyendra kumar",Age=22,dept=Department.TEC},
            new Employee() { Id=4,Name="Himanshu koriya",Age=26,dept=Department.HR}};
        }
        public void Add(Employee emp)
        {
            emp.Id = empList.Max(x => x.Id) + 1;
            empList.Add(emp);
            throw new NotImplementedException();
        }

        public void Delete(int emp)
        {
            Employee tmp = empList.FirstOrDefault(x => x.Id == emp);
            if (tmp != null)
            {
                empList.Remove(tmp);
                Console.WriteLine("Employee remove successfully");

            }
            else
            {
                Console.WriteLine("Employee is not present");
            }

            throw new NotImplementedException();
        }

        public IEnumerable<Employee> getAll()
        {
            return empList;
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int id)
        {
            Employee emp = empList?.FirstOrDefault(x => x.Id == id);
            if (emp != null)
            {
                return emp;
            }
            else
            {
                return null;
            }
            throw new NotImplementedException();
        }

        public Employee Update(Employee emp)
        {
            Employee tmp=empList.FirstOrDefault(e=>e.Id == emp.Id);
            if (tmp != null)
            {
                tmp.dept = emp.dept;
                tmp.Age= emp.Age;
                tmp.Name= emp.Name;
            }
            throw new NotImplementedException();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IEmployee obj = new EmpFun();
            Display(obj);
            try
            {
                obj.Add(new Employee() { Name = "Vibhore", Age = 27, dept = Department.TEC });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            
            Display(obj);
            Employee e = obj.GetEmployee(2);
            if (e != null)
            {
                Console.WriteLine("{0} {1} {2} {3}", e.Id, e.Name, e.Age, e.dept);
            }
            try
            {
                obj.Delete(e.Id);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Display(obj);
            try
            {
                obj.Update(new Employee() {Id=1, Name = "Vibha", Age = 19, dept = Department.TEC });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Display(obj);
        }
        static void Display(IEmployee emp)
        {
            IEnumerable<Employee> tmp = emp.getAll();
            foreach (Employee e in tmp)
            {
                Console.WriteLine("{0} {1} {2} {3}", e.Id, e.Name, e.Age, e.dept);
            }
            Console.WriteLine("----------------------------------------------------------");
        }


    }

       
}
