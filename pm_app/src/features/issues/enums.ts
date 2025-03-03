export enum IssuePriority {
    Low = 0,
    Medium,
    High,
    Critical
}

export const getPriorityProps= (priority: IssuePriority)=>{
    switch (priority) {
        case IssuePriority.Low:
            return {
                color: "bg-red-500",
                
            }
    
        default:
            return {
                color: "bg-red-500",
                
            }
    }
}


export enum IssueType{
    Bug,
    Task,
    Story,
    Epic
}
export enum IssueStatus{
    Open,
    InProcess,
    Resolve,
    Closed
}