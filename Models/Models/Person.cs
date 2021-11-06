using System;
using CsvHelper.Configuration.Attributes;
using FluentValidation;

namespace Models.Models
{
    public class Person
    {
        [Ignore]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        
        public bool Married { get; set; }
        
        public string Phone { get; set; }
        
        public decimal Salary { get; set; }
    }
    
    public class PersonValidator: AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(person => person.Name).MaximumLength(20).WithMessage("Too long name");
            RuleFor(person => person.Phone).MaximumLength(10).WithMessage("Not correct number");
        }
    }
    
}