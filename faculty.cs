using System;

class Faculty : Person{
   
   public string Id { get; set; }
   public string Title { get; set; }
   public DateTime DateOfEmployment { get; set; }
   public string Employer{ get; set; }
   public decimal YearlySalary{ get; set; }
   public string College{ get; set; }
   public bool Tenured { get; set; }
  
   
   public Faculty() : base(){
       Title = "Instructor";  
   }
  
   public Faculty(string FirstName,string LastName): base(FirstName, LastName){
       Title = "Instructor";  
   }
  
   public bool GrantTenure(){
       int yearsWorked = 0;
       if((DateTime.Today.Month == DateOfEmployment.Month) && (DateTime.Today.Day == DateOfEmployment.Day)){
               yearsWorked = DateOfEmployment.Year - DateTime.Today.Year;              
       }else
           yearsWorked = ((DateOfEmployment.Year - DateTime.Today.Year) - 1);              
       if(yearsWorked >= 5)
           Tenured = true;
       else
           Tenured = false;
       return Tenured;
   }
  
   public void Promote(){
       int experience = 0;
       if((DateTime.Today.Month == DateOfEmployment.Month) && (DateTime.Today.Day == DateOfEmployment.Day)){
               experience = DateTime.Today.Year - DateOfEmployment.Year;              
       }else
           experience = ((DateTime.Today.Year - DateOfEmployment.Year) - 1);              
       if(Title.Equals("Instructor") && experience > 2){
           Title = "Assistant Professor";
           Console.WriteLine("Faculty promoted to Assiatant Professor Rank");
       }
       if(Title.Equals("Assistant Professor") && experience > 5){
           Title = "Associate Professor";
           Console.WriteLine("Faculty promoted to Associate Professor Rank");
       }
       if(Title.Equals("Associate Professor") && experience > 10){
           Title = "Professor";
           Console.WriteLine("Faculty promoted to Professor Rank");
       }
       if(Title.Equals("Professor")){          
           Console.WriteLine("No more promotion possible");
       }
   }
   public override void Intro(){
       base.Intro();
       Console.WriteLine("I work as " + Title + " at " + College + " since " + DateOfEmployment.Year);
   }
}