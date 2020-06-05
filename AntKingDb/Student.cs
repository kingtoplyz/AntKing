using AntKingDb.Entity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AntKingDb
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public Int32 SchoolId { get; set; }
    }

    public class School : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
