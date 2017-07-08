using Resume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Data
{
    public class DbIntialize

    {

        public static void Intialize(ResumeContext context)
        {
            context.Database.EnsureCreated();

           if (context.Job.Any())
             {
               return;
            // }

            var contact = new Contact[]
            {
                new Contact {FirstName="Nick",
                             MiddleName="E",
                             LastName="Waye",
                             StreetNumber=3071,
                             Street="Wagon Tire",
                             City="Many Moons",
                             State="NM",
                             ZipCode=87031,
                             PhoneNumber="505-891-0976",
                             EmailAddr="nickwaye@none.com",
                             Website="",
                             Employments = new Employment[]
                             {
                                 new Employment()
                                 {
                                     Jobs = new Job[]
                                     {
                                         new Job(){
                                         EmployerName = "ASRC",
                                         JobTitle = "Engineer",
                                         StartDate = DateTime.Now.AddDays(-500),
                                         StopDate = DateTime.Now.AddDays(-300),
                                         JobDescription = "blah",

                                         Accomplishments = new Accomplishment[]
                                          {
                                         new Accomplishment()
                                            {
                                            Description = "Some stuff"
                                            },
                                         new Accomplishment()
                                            {
                                             Description = "More stuff"
                                            }

                                         }
                                         },
                                         new Job(){
                                         EmployerName = "United States Air Force",
                                         JobTitle = "Ground Radio",
                                         StartDate = DateTime.Now.AddDays(-1500),
                                         StopDate = DateTime.Now.AddDays(-800),
                                         JobDescription = "Radio Communications Repair",

                                         Accomplishments = new Accomplishment[]
                                          {
                                         new Accomplishment()
                                            {
                                            Description = "Dis Some stuff"
                                            },
                                         new Accomplishment()
                                            {
                                             Description = "More Heroic stuff"
                                            }

                                         }
                                         },



                                     },


                                 }
                             },
                             References = new Reference[]
                                     {
                                new Reference{FirstName="Chris",
                                      MiddleName="NMN",
                                      LastName="Newey",
                                      Employer="ASRC",
                                      JobTitle="Software Developer",
                                      Relationship="Co-Worker",
                                      PhoneNumber="505-555-0922",
                                      EmailAddr ="newey@yahoo.com"},
                                new Reference{FirstName="Brian",
                                      MiddleName="NMN",
                                      LastName="Jones",
                                      Employer="CNM",
                                      JobTitle="Software Developer",
                                      Relationship="Instructor",
                                      PhoneNumber="505-555-1023",
                                      EmailAddr ="JonesSolution@yahoo.com"}
                                     },


                             ProfessionalSkills = new ProfessionalSkill[]
                             {
                                 new ProfessionalSkill
                                 {
                                    SkillDescription =".NET Jr. Developer",
                                    Date=DateTime.Today,
                                    InstitutionName="CNM",
                                    State="NM",
                                    City="ABQ",
                                    ZipCode=87111}

                             },

                            Educations = new Education[]
                            {
                                new Education
                                {
                                   InstitutionName="University of Maryland",
                                   State="MD",
                                   City="College Park",
                                   StartDate=DateTime.Now.AddDays(-5405),
                                   EndDate= DateTime.Now.AddDays(-2811),
                                   Graduation=DateTime.Now.AddDays(-2613)

                                }


                            }
                    }

            };


            foreach (Contact c in contact)
            {
                context.Contact.Add(c);
            }
            context.SaveChanges();

            //    var references = new Reference[]
            //    {
            //        new Reference{FirstName="Chris",
            //                      MiddleName="NMN",
            //                      LastName="Newey",
            //                      Employer="ASRC",
            //                      JobTitle="Software Developer",
            //                      Relationship="Co-Worker",
            //                      PhoneNumber="505-555-0922",
            //                      EmailAddr ="neweyc@yahoo.com"},
            //        new Reference{FirstName="Brian",
            //                      MiddleName="NMN",
            //                      LastName="Jones",
            //                      Employer="CNM",
            //                      JobTitle="Software Developer",
            //                      Relationship="Instructor",
            //                      PhoneNumber="505-555-1023",
            //                      EmailAddr ="JonesSolution@yahoo.com"}
            //    };

            //    foreach (Reference r in references)
            //    {
            //        context.Reference.Add(r);
            //    }
            //    context.SaveChanges();

            //    var jobs = new Job[]
            //    {
            //    new Job{JobDescription="Did System Stuff",
            //        EmployerName ="ASRC", JobTitle="Systems Engineer",
            //        StartDate =DateTime.Parse("2005-09-01"),
            //        StopDate =DateTime.Parse("2015-09-01")},
            //    new Job{JobDescription="Did Software Stuff",
            //        EmployerName ="Lockhead Martin",
            //        JobTitle ="Sotfware Engineer",
            //        StartDate =DateTime.Parse("2001-09-11"),
            //        StopDate =DateTime.Parse("2005-09-01")}
            //    };

            //    foreach (Job j in jobs)
            //    {
            //        context.Job.Add(j);
            //    }
            //    context.SaveChanges();

            //    var accomplishment = new Accomplishment[]
            //   {
            //        new Accomplishment{accomplishment="I did stuff"},
            //        new Accomplishment{accomplishment="I did lots of stuff"}
            //   };

            //    foreach (Accomplishment a in accomplishment)
            //    {
            //        context.Accomplishment.Add(a);
            //    }

            //    context.SaveChanges();


            //    var Employments = new Employment[]
            //    {
            //        new Employment{Current=false },
            //        new Employment{Current=false }
            //    };

            //    foreach (Employment e in Employments)
            //    {
            //        context.Employments.Add(e);
            //    }
            //    context.SaveChanges();


            //}


        }
    }
}
