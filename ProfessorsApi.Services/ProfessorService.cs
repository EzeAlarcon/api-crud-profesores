using ProfessorsApi.Models;
using System;
using System.Collections.Generic;

namespace ProfessorsApi.Services
{
    public interface IProfessorService
    {
        IEnumerable<Professor> GetAllProfessors();
        Professor? GetProfessorById(int id);
        void AddProfessor(Professor professor);
        void UpdateProfessor(int id, Professor professor);
        void DeleteProfessor(int id);
    }

    public class ProfessorService : IProfessorService
    {
        private List<Professor> _professors = new List<Professor>();

        public IEnumerable<Professor> GetAllProfessors()
        {
            return _professors;
        }

        public Professor? GetProfessorById(int id)
        {
            return _professors.Find(p => p.Id == id);
        }

        public void AddProfessor(Professor professor)
        {
            professor.Id = Guid.NewGuid().GetHashCode(); // Simple way to generate a unique ID
            _professors.Add(professor);
        }

        public void UpdateProfessor(int id, Professor professor)
        {
            var existingProfessor = _professors.Find(p => p.Id == id);
            if (existingProfessor != null)
            {
                existingProfessor.Name = professor.Name;
                existingProfessor.Department = professor.Department;
            }
        }

        public void DeleteProfessor(int id)
        {
            _professors.RemoveAll(p => p.Id == id);
        }
    }
}
