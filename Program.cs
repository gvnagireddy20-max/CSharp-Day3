using System;

class Employee
{
    public int EmployeeId { get; private set; }
    public string EmployeeName { get; private set; } = string.Empty;
    public string Department { get; private set; } = string.Empty;

    private double monthlySalary;
    public double MonthlySalary
    {
        get => monthlySalary;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Monthly salary cannot be negative.");

            monthlySalary = value;
        }
    }

    public Employee(int employeeId, string employeeName, string department, double monthlySalary)
    {
        if (employeeId <= 0)
            throw new ArgumentOutOfRangeException(nameof(employeeId), "Employee ID must be a positive number.");

        if (string.IsNullOrWhiteSpace(employeeName))
            throw new ArgumentException("Employee name cannot be empty.");

        if (string.IsNullOrWhiteSpace(department))
            throw new ArgumentException("Department cannot be empty.");

        EmployeeId = employeeId;
        EmployeeName = employeeName;
        Department = department;
        MonthlySalary = monthlySalary;
    }

    public double CalculateAnnualSalary()
    {
        return MonthlySalary * 12;
    }

    public void ApplySalaryRaise(double raisePercentage)
    {
        if (raisePercentage <= 0)
            throw new ArgumentOutOfRangeException(nameof(raisePercentage), "A salary raise must be greater than 0.");

        double raiseAmount = MonthlySalary * raisePercentage / 100;
        MonthlySalary = MonthlySalary + raiseAmount;
    }

    public void DisplayDetails()
    {
        Console.WriteLine("Employee Information");
        Console.WriteLine($"Employee ID: {EmployeeId}");
        Console.WriteLine($"Employee Name: {EmployeeName}");
        Console.WriteLine($"Department: {Department}");
        Console.WriteLine($"Monthly Salary: {MonthlySalary:C}");
        Console.WriteLine($"Annual Salary: {CalculateAnnualSalary():C}");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter employee 1 details:");
            Console.Write("ID: ");
            int id1 = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string name1 = Console.ReadLine();
            Console.Write("Department: ");
            string dept1 = Console.ReadLine();
            Console.Write("Monthly Salary: ");
            double salary1 = double.Parse(Console.ReadLine());

            Employee employee1 = new Employee(id1, name1, dept1, salary1);

            Console.WriteLine();
            Console.WriteLine("Enter employee 2 details:");
            Console.Write("ID: ");
            int id2 = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string name2 = Console.ReadLine();
            Console.Write("Department: ");
            string dept2 = Console.ReadLine();
            Console.Write("Monthly Salary: ");
            double salary2 = double.Parse(Console.ReadLine());

            Employee employee2 = new Employee(id2, name2, dept2, salary2);

            Console.WriteLine();
            Console.WriteLine("Enter raise percentage for employee 1: ");
            double raise = double.Parse(Console.ReadLine());

            employee1.ApplySalaryRaise(raise);

            Console.WriteLine();
            Console.WriteLine("Employee 1 details:");
            employee1.DisplayDetails();
            Console.WriteLine();
            Console.WriteLine("Employee 2 details:");
            employee2.DisplayDetails();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("\nDay 3 OOP Employee Payroll System completed successfully.");
        }
    }
}
