using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;

namespace DevFreela.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email, DateTime birthDate, bool active, IEnumerable<UserSkill> skills, IEnumerable<Project> ownedProjects, IEnumerable<Project> freelanceProjects)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Active = active;
            Skills = skills;
            OwnedProjects = ownedProjects;
            FreelanceProjects = freelanceProjects;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }
        public IEnumerable<UserSkill> Skills { get; private set; }
        public IEnumerable<Project> OwnedProjects { get; private set; }
        public IEnumerable<Project> FreelanceProjects { get; private set; }

    }
}
