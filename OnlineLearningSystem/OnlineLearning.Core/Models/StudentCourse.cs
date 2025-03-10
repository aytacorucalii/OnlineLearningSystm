﻿namespace OnlineLearning.Core.Models;

public class StudentCourse
{
    public int StudentId { get; set; }
    public Student Student { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }

    public DateTime EnrollmentDate { get; set; } // Tələbənin kursa qoşulma tarixi
}
