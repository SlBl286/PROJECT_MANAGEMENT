using ErrorOr;

namespace PM.Domain.Common.Errors;

public static partial class Errors
{
    public static class Project
    {
        public static Error DuplicateProject => Error.Validation(code: "Project.DuplicateProject",description: "Project đã tồn tại");
        public static Error NotFound => Error.Validation(code: "Project.NotFound",description: "Project không tồn tại");

    }
}