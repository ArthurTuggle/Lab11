using System;

class Address{

   private string zipCode;
   private string state;
   public string AddressLine1 { get; set;}
   public string AddressLine2 { get; set;}
   public string City { get; set;}
   public string State {
       get{
           if (!String.IsNullOrEmpty(state))
               return state.ToUpper();
           else
               return String.Empty;
       }

       set{
           if (value.Length==2)
               state = value;
           else
               Console.WriteLine("State code should be 2 characters long");
       }
   }

   public string Zipcode {
       get{ return zipCode;}
       set{
           if (value.Length <= 5)
               zipCode = value;
           else
               Console.WriteLine("Invalid length");
       }
   }

   public void Display(){
       Console.WriteLine("Here's the address:");
       Console.WriteLine(AddressLine1);
       Console.WriteLine(AddressLine2);
       Console.WriteLine(City);
       Console.WriteLine(State);
       Console.WriteLine(Zipcode);
   }
}
class Person{
   
   public string FirstName { get; set; }
   public string LastName { get; set; }
   public virtual DateTime DateOfBirth { get; set; }
   public string SocialSecurity { get; set; }
   public string Email { get; set; }
   public string PhoneNumber { get; set; }
   public Address PermanentAddress;

   public Person(){
       PermanentAddress = new Address();
       Console.WriteLine("Person constructor");
   }

   public Person(string fname, string lname){
       FirstName = fname;
       LastName = lname;
       PermanentAddress = new Address();
       Console.WriteLine("Person constructor");
   }

   public virtual void Intro(){
       Console.WriteLine("Hello my name is "+ FirstName +" "+ LastName);
       PermanentAddress.Display();
   }
   public void IsBirthday(){
       if ((DateTime.Today.Month == DateOfBirth.Month)&&(DateTime.Today.Day == DateOfBirth.Day))
           Console.WriteLine("It's your birthday!!!");
       else
           Console.WriteLine("Today is not your birthday.");
   }
}
class Student : Person {
   public string Id{get; set;}
   public string School {get; set;}
   public double GPA {get; set;}
   public string Major {get; set;}
   public string AcademicStanding {get; set;}

   public override DateTime DateOfBirth {
       get{return base.DateOfBirth;}
       set{
           int age = DateTime.Today.Year - value.Year;
           Console.WriteLine("Age="+age);
           if (age >= 18)
               base.DateOfBirth = value;
           else
               Console.WriteLine("Age cannot be under 18");
       }
   }
   public Student() : base() {
       Console.WriteLine("Student constructor");
       AcademicStanding="Good";
   }

   public Student(string fname, string lname) : base(fname, lname){
       Console.WriteLine("Student constructor");
       AcademicStanding="Good";
   }

   public void SetAcademicStanding(){
       if (GPA >= 2.25)
           AcademicStanding = "Good";
       else
           AcademicStanding = "Not Good";
   }

   public override void Intro(){
       base.Intro();
       Console.WriteLine("I am a student studying in " + School);
   }

}


public class MainClass {
   public static void Main (string[] args) {
       

       Console.WriteLine("Testing Student 1");
       Student s1 = new Student();
       s1.FirstName = "Kara";
       s1.LastName="Kaiser";
       s1.DateOfBirth = Convert.ToDateTime("01/01/2020");
       s1.PermanentAddress.AddressLine1 = "999 Mallard Dr";
       s1.PermanentAddress.City = "Parma";
       s1.PermanentAddress.State = "OH";
       s1.PermanentAddress.Zipcode = "44143";
       s1.GPA = 2.1;
       s1.School = "Cleveland State University";
       s1.Intro();
       s1.IsBirthday();
       s1.SetAcademicStanding();
       Console.WriteLine(s1.AcademicStanding);
       Console.WriteLine("Testing Student 2");
       Student s2 = new Student("Andrew", "Peggman");
       s2.DateOfBirth = Convert.ToDateTime("01/01/1989");
       s2.PermanentAddress.AddressLine1 = "999 Mallard Dr";
       s2.PermanentAddress.City = "Parma";
       s2.PermanentAddress.State = "OH";
       s2.PermanentAddress.Zipcode = "44143";
       s2.GPA = 2.75;
       s2.School = "Ohio State University";
       s2.Intro();
       s2.IsBirthday();
       s2.SetAcademicStanding();
       Console.WriteLine(s2.AcademicStanding);
      
       Console.WriteLine("===================================");
       Console.WriteLine("Testing Faculty 1 ");
       Faculty faculty = new Faculty("John","Doe");
       faculty.DateOfBirth = Convert.ToDateTime("06/10/1990");
       faculty.PermanentAddress.AddressLine1 = "123 ABC Avenue";
       faculty.PermanentAddress.City = "New Delhi";
       faculty.PermanentAddress.State = "ND";
       faculty.PermanentAddress.Zipcode = "12345";
       faculty.SocialSecurity = "SSN001";
       faculty.Email = "john@abc.com";
       faculty.PhoneNumber = "1234567890";
      
       faculty.Id = "F1234";
       faculty.DateOfEmployment = Convert.ToDateTime("06/10/2010");
       faculty.YearlySalary = 10000.00M;
       faculty.College = "Tri - C";
       faculty.GrantTenure();
       faculty.Promote();
       faculty.Intro();      
   }

}