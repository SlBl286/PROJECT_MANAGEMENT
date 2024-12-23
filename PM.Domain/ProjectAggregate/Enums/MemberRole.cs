namespace PM.Domain.ProjectAggregate.Enums;
public enum MemerRole
{
    Viewer,
    Developer,
    ProjectManager
}  

static class MemerRoleExtensions 
{
  public static string From(this MemerRole role) 
  {
        return role switch
        {
            MemerRole.Viewer => "Viewer",
            MemerRole.Developer => "Developer",
            MemerRole.ProjectManager => "Project Manager",
            _ => throw new ArgumentOutOfRangeException("memberRole"),
        };
    }
}