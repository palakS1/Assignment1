//LINQ BASED CODING ASSESSMENT-1 (18 JULY 2022)

using System.Diagnostics.CodeAnalysis;
using System.Linq;

//STRING ARRAY
Console.WriteLine("STRING ARRAY-");
var students = new List<Student> {
new Student{FirstName="Amara",LastName="Sriram",Age=21, Gender="M", TeamName="A" },
new Student{FirstName="Muskan",LastName="Muskan",Age=20, Gender="F", TeamName="A" },
new Student{FirstName="Rahul",LastName="Yadav",Age=21, Gender="M", TeamName="A" },
new Student{FirstName="Shraddha",LastName="Shraddha",Age=20, Gender="F", TeamName="A" },
new Student{FirstName="Aishwarya",LastName="Verma",Age=19, Gender="F", TeamName="A" },

new Student{FirstName="Shreya",LastName=" ",Age=20, Gender="F", TeamName="B" },
new Student{FirstName="Nandhita",LastName=" ",Age=20, Gender="F", TeamName="B" },
new Student{FirstName="Shashwat",LastName=" ",Age=20, Gender="M", TeamName="B" },
new Student{FirstName="Siddarth",LastName=" ",Age=21, Gender="M", TeamName="B" },
new Student{FirstName="Shriya",LastName=" ",Age=20, Gender="F", TeamName="B" },

new Student{FirstName="Sriram",LastName=" ",Age=21, Gender="M", TeamName="C" },
new Student{FirstName="Sneha",LastName="Sinha",Age=20, Gender="F", TeamName="C" },
new Student{FirstName="Simran",LastName="Singh",Age=20, Gender="F", TeamName="C" },
new Student{FirstName="Subhash",LastName="Gurjar",Age=21, Gender="M", TeamName="C" },
new Student{FirstName="Umeed",LastName="Chandel",Age=19, Gender="F", TeamName="C" },

new Student{FirstName="Vaibhav",LastName="Bhatnagar",Age=21, Gender="M", TeamName="D" },
new Student{FirstName="Pujitha",LastName="Vavilapalli",Age=20, Gender="F", TeamName="D" },
new Student{FirstName="Palak",LastName="Soni",Age=20, Gender="F", TeamName="D" },
new Student{FirstName="Saurabh",LastName="Kumar",Age=21, Gender="M", TeamName="D" },
new Student{FirstName="Tisha",LastName="Varshney",Age=20, Gender="F", TeamName="D" },
new Student{FirstName="Aman",LastName="Asati",Age=21, Gender="M", TeamName="D" }
};
//------------------------------------------------------------------------------------------------------------------------------------

//1.get all the students count for each team (GROUPBY, COUNT)
var studentCount = students.GroupBy(student => student.TeamName);
Console.WriteLine("\n1. Total Number of students in each Team: ");
foreach(var totalCount in studentCount)
{
    Console.WriteLine("   Team "+ totalCount.Key + ": " + totalCount.Count() + " ");
}
//------------------------------------------------------------------------------------------------------------------------------------

//2. get all the male students list (WHERE, COUNT)
var maleStu = students.Where(student => student.Gender == "M");
Console.WriteLine("\n2. List of Male students: ", maleStu.Count());
foreach (var i in maleStu)
{ 
    Console.WriteLine("   " + i.FirstName + " " + i.LastName + ", ");
}
//------------------------------------------------------------------------------------------------------------------------------------

//3. get all the female students list (WHERE, LONG COUNT)
var femaleStu = students.Where(student => student.Gender == "F");
Console.WriteLine("\n\n3. List of Female students: ", femaleStu.LongCount());
foreach (var i in femaleStu)
{
    Console.WriteLine("   " + i.FirstName + " " + i.LastName + ", ");
}
//------------------------------------------------------------------------------------------------------------------------------------

//4. get all the male students with age 20 (WHERE, SELECT)
var maleAge20 = students.Where(student => (student.Gender == "M" && student.Age == 20))
                        .Select(student => new { student.FirstName, student.LastName });
Console.Write("\n\n4. Male students who are 20 years old: ");
foreach (var i in maleAge20)
{
    Console.Write(" {0}, ", i.FirstName + " " + i.LastName);
}
//------------------------------------------------------------------------------------------------------------------------------------

//5. get all the female students with age 19 (WHERE, SELECT)
var femaleAge19 = students.Where(student => (student.Gender == "F" && student.Age == 19))
                          .Select(student => new {student.FirstName, student.LastName}); //using anonymous type
Console.Write("\n\n5. Female students who are 19 years old: ");
foreach (var i in femaleAge19)
{
    Console.Write(" {0}, ", i.FirstName + " " + i.LastName);
}
//------------------------------------------------------------------------------------------------------------------------------------

//6. get all the students starts with FirstName as "A or a"
var startsWithA = students.Where(students => students.FirstName.ToUpper()
                          .StartsWith('A'));
Console.Write("\n\n6. Name starts with A: ");
foreach (var i in startsWithA)
{
    Console.Write("{0} ", i.FirstName + " " + i.LastName + ", ");
}
//------------------------------------------------------------------------------------------------------------------------------------

//7. get all the students whose lastname is "" (WHERE)
var noLastName = students.Where(students => students.LastName == " ");
Console.WriteLine("\n\n7. Students who don't have a last name: ");
foreach(var i in noLastName)
{
    Console.WriteLine("   " + i.FirstName);
}
//------------------------------------------------------------------------------------------------------------------------------------

//8.get top 2 students in each team(for example Amara and Muskan are top 2 students in A team) (GROUP BY, TAKE)
var countTeamMembers = students.GroupBy(student => student.TeamName);
Console.WriteLine("\n\n8. First Two Students Of Each Team: ");
foreach(var group1 in countTeamMembers)
{
    Console.Write("\n   Group "+group1.Key + ": ");

    var student = group1.TakeLast(2);
    foreach(var group2 in student)
    {
        Console.Write(group2.FirstName + " " + group2.LastName + ", ");
    }
}
//------------------------------------------------------------------------------------------------------------------------------------
//9.get the students from 8th position to 17th position (TAKE, RANGE)
var take8to17 = students.Take(new Range(8, 17));
Console.WriteLine("\n\n9. Students from 8th to 17th position: ");
foreach (var item in take8to17)
{
    Console.WriteLine("   " + item.FirstName + " " + item.LastName + ",");
}
//------------------------------------------------------------------------------------------------------------------------------------
//10. get all the students FirstName with Age (CONVERT ALL)
var getFirstNameAndAge = students.ConvertAll(student => student.FirstName +" (Age: "+ student.Age + ")" ); //we have converted student object to srting
Console.WriteLine("\n\n10. First Name & Age Of All Students: ");
foreach (var item in getFirstNameAndAge)
{
    Console.WriteLine("    " + item);
}


//------------------------------------------------------------------------------------------------------------------------------------
Console.WriteLine("THANK YOU!");
//------------------------------------------------------------------------------------------------------------------------------------

//class is defined because there is reusability of code
class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string TeamName { get; set; }
    public string ToString()
    {
        return (this.FirstName + " " + this.LastName);
    }
}
//------------------------------------------------------------------------------------------------------------------------------------
