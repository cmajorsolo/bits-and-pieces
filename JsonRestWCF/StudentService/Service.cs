using System.Web;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using StudentService.Models;
using System.ServiceModel;
using System.Collections.Generic;
using System;

namespace StudentService
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode
        = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service
    {
        [OperationContract]
        [WebGet(UriTemplate = "Service/GetDepartment")]
        public Department GetDepartment()
        {
            Department department = new Department
            {
                SchoolName = "School of Some Engineering",
                DepartmentName = "Department of Cool Rest WCF",
                Students = new List<Student>()
            };

            return department;
        }

        [OperationContract]
        [WebGet(UriTemplate = "Service/GetAStudent({id})")]
        public Student GetAStudent(string id)
        {
            Random rd = new Random();
            Student aStudent = new Student
                {
                    ID = System.Convert.ToInt16(id), 
                    Name = "Name No. " + id,
                    Score = Convert.ToInt16(60 + rd.NextDouble() * 40),
                    State = "GA"
                };

            return aStudent;
        }

        [OperationContract]
        [WebInvoke(Method ="POST", UriTemplate = "Service/AddStudentToDepartment",
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public Department
            AddStudentToDepartment(Department department, Student student)
        {
            List<Student> Students = department.Students;
            Students.Add(student);

            return department;
        }
    }
}