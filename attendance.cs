using System;
using System.Collections;
using System.IO.Pipes;
using System.Reflection.Emit;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.Serialization;
public class NameWithoutAlphabets : Exception
{
    public NameWithoutAlphabets(string message) : base(message)
    {
    }
}
public class PasswordIncorrect : Exception
{
    public PasswordIncorrect(string message) : base(message)
    {
    }
}
public abstract class Teacher
{
    protected string role, choice, checkUserName, checkPassword, choice2, password1;
    private string Person;
    string[] userName = new string[8] { "dp", "rakshu", "ganesh", "sandy", "sri", "meens", "smri", "ms" };
    string[] password = new string[10];
    int flag = 1, flag1 = 0;
    public string person
    {
        get { return Person; }
        set { Person = value; }
    }
    public abstract void Register1();
    public void Teacher1()
    {
        Console.WriteLine("Enter Your Role(Teacher/Student)");
        role = Console.ReadLine().ToLower();
        if (role == "teacher")
        {
            Console.WriteLine("Create an Account(press 'a'),Already have an acc?(Press 'b')");
            choice = Console.ReadLine().ToLower();
            if (choice == "a")
            {
                Console.WriteLine("Enter UserName");
                checkUserName = Console.ReadLine();
                bool result = checkUserName.Any(x => !char.IsLetter(x));
                try
                {
                    if (result)
                    {
                        throw (new NameWithoutAlphabets("Name should contain only letters"));
                    }
                }
                catch (NameWithoutAlphabets e)
                {
                    Console.WriteLine("NameWithoutAlphabets: {0}", e.Message);
                }
                for (int i = 0; i < userName.Length; i++)
                {
                    if (userName[i] == checkUserName.ToLower())
                    {
                        Console.WriteLine("Enter Password");
                        password[i] = Console.ReadLine();
                        try
                        {
                            if ((password[i].Length < 8 || password[i].Length > 14) && password[i].Contains(" "))
                            {
                                throw (new PasswordIncorrect("Enter a valid password containing 8 to 14 characters with no space!!!"));
                            }
                        }
                        catch (PasswordIncorrect e)
                        {
                            Console.WriteLine("PasswordIncorrect: {0}", e.Message);
                        }
                        flag = 0;
                        choice = "b";
                    }
                }
                if (flag == 1)
                {
                    Console.WriteLine("Username not available ");
                }
            }
            if (choice == "b")
            {
                Console.WriteLine("Login");
                Console.WriteLine("Enter Your Name: ");
                checkUserName = Console.ReadLine();
                Console.WriteLine("Enter Your Password: ");
                checkPassword = Console.ReadLine();
                for (int i = 0; i < userName.Length; i++)
                {
                    if (userName[i] == checkUserName.ToLower())
                    {
                        flag1 = 1;
                        if (password[i] == checkPassword)
                        {
                            Console.WriteLine("You successfully logged in!!!");
                            choice = "ln";
                        }
                        else
                        {
                            Console.WriteLine("Password incorrect!!");
                        }

                    }

                }
                if (flag1 == 0)
                {
                    Console.WriteLine("Username incorrect!!!");
                }

            }
        }
        if (role == "student")
        {
            if (choice == "ln")
            {
                Console.WriteLine("If you Want to login(press 'a')");
                choice2 = Console.ReadLine();
                if (choice2 == "a")
                {
                    Console.WriteLine("Enter your name");
                    person = Console.ReadLine();
                    bool result = person.Any(x => !char.IsLetter(x));

                    try
                    {
                        if (result)
                        {
                            throw (new NameWithoutAlphabets("Name should contain only letters"));

                        }
                    }

                    catch (NameWithoutAlphabets e)
                    {
                        Console.WriteLine("NameWithoutAlphabets: {0}", e.Message);
                    }
                    Console.WriteLine("Enter your Password");
                    password1 = Console.ReadLine();
                    try
                    {
                        if ((password1.Length < 8 || password1.Length > 14) && password1.Contains(" "))
                        {
                            throw (new PasswordIncorrect("Enter a valid password containing 8 to 14 characters with no space!!!"));
                        }
                    }
                    catch (PasswordIncorrect e)
                    {
                        Console.WriteLine("PasswordIncorrect: {0}", e.Message);
                    }
                    Console.WriteLine("You have successfully logged in,{0}", person);
                }
            }
        }
    }
}

public class Register : Teacher
{
    string cls_name, Atten, extra, ext;
    string[] sub_name = new string[5];
    protected string[] StudentName = new string[30];
    protected string[] StudentRegno = new string[30];
    public int store, dp;
    int i = 0;
    public override void Register1()
    {
        if (choice == "ln")
        {
            while (true)
            {
                Console.WriteLine("Enter {0} Student name: ", i + 1);
                StudentName[i] = Console.ReadLine();
                Console.WriteLine("Enter {0} Student RegNo: ", i + 1);
                StudentRegno[i] = Console.ReadLine();
                i++;
                store = i;
                Console.WriteLine("Do you want to add a student?(press'1') exit?(press 2')");
                extra = Console.ReadLine();
                if (extra == "2")
                {
                    break;
                }
                else
                {
                    continue;                }

            }
        }
    }
}
public class attendance : Register
{
    protected string cls_name, Atten, extra, abs;
    protected string[] date = new string[100];
    protected string[] Abs = new string[100];
    protected string[] sub_name = new string[100];
    protected int s = 0, n = 0, c = 0, co = 0;
    protected int[] count = new int[30];
    protected int[] a = new int[30];
    protected int[] c1 = new int[30];
    protected int[] percent = new int[10];
    public void attendance1()
    {
        if (choice == "ln")
        {
            Console.WriteLine("Enter the subject: ");
            sub_name[s] = Console.ReadLine();
            s++;
            while (true)
            {
                Console.WriteLine("Enter date to which you want to give attendance: ");
                date[n] = Console.ReadLine();
                Console.WriteLine("Enter the students reg no who are absent, after entering type 'next' to go out!!");
                for (int i = c; i < 100; i++)
                {
                    abs = Console.ReadLine();
                    if (abs != "next")
                    {
                        Abs[i] = abs;
                        co++;
                    }
                    else
                    {
                        break;
                    }
                }
                abs = "null";
                c = c + co;
                c1[n] = co;
                if (n > 0)
                {
                    a[n] = co + a[n - 1];
                }
                else
                {
                    a[n] = co;
                }
                co = 0;
                Console.WriteLine("\nIf you want to enter for next date press 1 else 2");
                extra = Console.ReadLine();
                if (extra == "1")
                {
                    n++;
                }
                else
                {
                    break;
                }
            }

            for (int i = 0; i < store; i++)
            {
                for (int j = 0; j < Abs.Length; j++)
                {
                    if (StudentRegno[i] == Abs[j])
                    {
                        count[i] += 1;
                    }
                }
            }
        }
    }
}
public class student : attendance
{
    int j, r = 0, flag = 0, flag1 = 1;
    public void student1(string a1)
    {
        if (choice == "ln")
        {
            Console.WriteLine("Enter the date for which the attendance has to be displayed:(If you want to display for all dates enter 'all')");
            string d = Console.ReadLine();
            Console.WriteLine("Subject: " + sub_name[s - 1]);
            Console.WriteLine();
            if (d == "all")
            {
                for (int i = 0; i <= n; i++)
                {
                    Console.WriteLine("Date: " + date[i]);
                    Console.WriteLine("Name\tRegno\tAttendance");
                    for (int k = 0; k < store; k++)
                    {
                        for (int j = r; j < a[i]; j++)
                        {
                            if (StudentRegno[k] == Abs[j])
                            {
                                Console.WriteLine(StudentName[k] + "\t" + Abs[j] + "\tabsent");
                                flag = 1;
                            }
                        }
                        if (flag == 0)
                        {
                            Console.WriteLine(StudentName[k] + "\t" + StudentRegno[k] + "\tpresent");
                        }
                        else
                        {
                            flag = 0;
                        }

                    }
                    r += c1[i];
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i <= n; i++)
                {
                    if (d == date[i])
                    {
                        Console.WriteLine("Date: " + date[i]);
                        for (int k = 0; k < store; k++)
                        {
                            for (int j = r; j < a[i]; j++)
                            {

                                if (StudentRegno[k] == Abs[j])
                                {
                                    Console.WriteLine(StudentName[k] + "\t" + Abs[j] + "\tabsent");
                                    flag = 1;
                                }
                            }
                            if (flag == 0)
                            {
                                Console.WriteLine(StudentName[k] + "\t" + StudentRegno[k] + "\tpresent");

                            }
                            else
                            {
                                flag = 0;
                            }
                        }
                    }
                    else
                    {
                        r += c1[i];
                    }
                }
            }
            n += 1;
            for (int i = 0; i < store; i++)
            {
                percent[i] = (n - count[i]) * 100;
                percent[i] /= n;
                Console.WriteLine("Name\tRegno\tdays_absent\tpercent");
                Console.WriteLine(StudentName[i] + "\t" + StudentRegno[i] + "\t" + count[i] + "\t\t" + percent[i]);
            }
            n -= 1;
            dp = 1;
        }
    }
    public delegate void student_del();
    public void student1()
    {

        for (int i = 0; i < store; i++)
        {
            if (person == StudentName[i])
            {
                Console.WriteLine(StudentName[i] + "\t" + StudentRegno[i] + "\t" + sub_name[s - 1] + "\t" + count[i] + "\t\t" + percent[i]);
            }
        }
    }
}
public class hello : student
{
    public hello()
    {
        Console.WriteLine("You have entered into attendance management console app!!");
    }
    public hello(string message)
    {        
        Console.WriteLine("Welcome "+message);
        Console.WriteLine("First enter as teacher to give details");
    }   
    public static void Main()
    {
        string roles;
        Console.WriteLine("Enter your name: ");    
        string user=Console.ReadLine();
        hello[] h = new hello[30];
        hello hh = new hello(user);
        int i = 0;
        h[i] = new hello();
        h[i].Teacher1();
        h[i].Register1();
        h[i].attendance1();
        h[i].student1("Attendance has been taken");    

        if (h[0].choice == "ln")
        {
        repeat:
      
            Console.WriteLine("Do you want to enter the system again? if yes press 1 else 2");
            string next = Console.ReadLine();

            if (next == "1")
            {

                Console.WriteLine("Do you want to enter as teacher or student?");
                 roles = Console.ReadLine();

                if (roles == "teacher")
                {
                    i++;
                    h[i] = new hello();
                    h[i].StudentName = h[0].StudentName;
                    h[i].StudentRegno = h[0].StudentRegno;
                    h[i].store = h[0].store;
                    h[i].choice = h[0].choice;
                    h[i].attendance1();
                    h[i].student1("Attendance has been taken");

                    goto repeat;

                }

                else
                {

                    h[i].Teacher1();
                    Console.WriteLine("Name\tRegno\tSubject\tdays_absent\tpercent");
                    for (int d = 0; d <= i; d++)
                    {
                        h[d].person = h[i].person;
                        student_del s = new student_del(h[d].student1);
                        s();
                    }

                    goto repeat;
                }
            }
            else
            {
                
                goto endloop;
            endloop: Console.WriteLine("The end");
                Console.WriteLine("Press Enter Key to Exit..");
                Console.ReadLine();

            }
        }

    }
}
