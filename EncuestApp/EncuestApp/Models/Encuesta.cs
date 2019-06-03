using System;
using System.Collections.Generic;

namespace EncuestApp.Models
{
    public class Datos
    {
        public Datos()
        {
            valueDate=DateTime.Now;
        }

        public string fieldName { get; set; }
        public string fieldType { get; set; }
        public string value { get; set; }
        public DateTime valueDate { get; set; }
        public bool IsText => (fieldType == "entry");
        public bool IsDate => (fieldType == "DatePicker");
    }

    public class Encuesta
    {
        public int id { get; set; }
        public int numberOfStudents { get; set; }
        public int numberOfFields { get; set; }
        public List<Datos> fields { get; set; }
    }
}
