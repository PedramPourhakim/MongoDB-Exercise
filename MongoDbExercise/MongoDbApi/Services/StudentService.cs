﻿using MongoDB.Driver;
using MongoDbApi.Models;

namespace MongoDbApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMongoCollection<Student> _students;

        public StudentService
            (IStudentStoreDatabaseSettings settings,
            IMongoClient mongoClient)
        {
           var database =  mongoClient.GetDatabase
                (settings.DatabaseName);

            _students = database.GetCollection<Student>
                (settings.StudentCoursesCollectionName);
        }
        public Student Create(Student student)
        {
            _students.InsertOne(student);
            return student;
        }

        public List<Student> Get()
        {
            return _students.Find(Student => true).ToList();
        }

        public Student Get(string id)
        {
            return _students.Find
                (Student => Student.Id == id)
                .FirstOrDefault();
        }

        public void Remove(string id)
        {
            _students.DeleteOne
                (Student => Student.Id == id);
        }

        public void Update(string id, Student student)
        {
            _students.ReplaceOne
                (Student => Student.Id == id,student);
        }
    }
}