using System;
namespace DevFreela.Core.Exceptions
{
    public class ProjectAlreadyStartedExeption : Exception
    {
        public ProjectAlreadyStartedExeption() : base("Project is already in Started status")
        {
        }
    }
}
