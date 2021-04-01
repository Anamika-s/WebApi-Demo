using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Demo.Models;

namespace WebApi_Demo.Controllers
{
    public class StudentsController : ApiController
    {
        static List<Student> _studentList = null;
        void Initialize()
        {
            _studentList = new List<Student>()
           {
               new Student() { StudentId=1, Name="Ajay" , Batch="B001", Marks=89, DateOfBirth=Convert.ToDateTime("12/12/2020")},

               new Student() { StudentId=2, Name="Deepak" , Batch="B002", Marks=78, DateOfBirth=Convert.ToDateTime("10/06/2020")},
           };

        }
        public StudentsController()
        {
            if (_studentList == null)
            {
                Initialize();
            }
        }

        // GET: api/Students
        public HttpResponseMessage Get()
        {
           // return Ok(_studentList);
            return Request.CreateResponse(HttpStatusCode.OK, _studentList);

        }

        // GET: api/Students/5
        public IHttpActionResult Get(int id)
        {
            Student student = _studentList.FirstOrDefault(x => x.StudentId == id);
            if (student == null)
            {
                return Content(HttpStatusCode.NotFound, "Not FOund");
               // return NotFound();
                //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found");
            }
            else
            {
                return Ok(student);
               // return Request.CreateResponse(HttpStatusCode.Found, student);
            }


        }

        // POST: api/Students
        public IHttpActionResult Post(Student student)
        {
            if (student != null)
            {
                _studentList.Add(student);
            }
          
            return Content(HttpStatusCode.Created, "Record Created");
            // return Request.CreateResponse(HttpStatusCode.Created, "Record inserted");
        }

        // PUT: api/Students/5
        public IHttpActionResult Put(int id, Student objStudent)
        {
            Student student = _studentList.Where(x => x.StudentId == id).FirstOrDefault();
            if (student == null)
            {
                return NotFound();
               // return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found");
            }
            else
            {
                if (student != null)
                {
                    foreach (Student temp in _studentList)
                    {
                        if (temp.StudentId == id)
                        {
                            temp.Name = objStudent.Name;
                            temp.DateOfBirth = objStudent.DateOfBirth;
                            temp.Batch = objStudent.Batch;
                            temp.Marks = objStudent.Marks;
                        }
                    }

                }
                return Content(HttpStatusCode.OK, "Record Modified");
               // return Request.CreateResponse(HttpStatusCode.OK, "Record modified");
            }
        }
    
        // DELETE: api/Students/5
        public IHttpActionResult Delete(int? id)
        {
            if (id != null)
            {
                Student student = _studentList.FirstOrDefault(x => x.StudentId == id);
                if (student == null)
                {
                    return NotFound();
                   // return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found");
                }

                else
                {

                    _studentList.Remove(student);
                    return Content(HttpStatusCode.OK, "Record deleted");
                    //  return Request.CreateResponse(HttpStatusCode.OK, "Record Deleted");
                }
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Please provide ID");
                  //  return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please provide id"); 
                }
            }
        }
        }

    

