import { IssuePriority, IssueStatus, IssueType } from "./enums"

export type Issue = {
    id : string,
    code: string,
    title: string,
    description : string,
    status :IssueStatus,
    priority : IssuePriority,
    type : IssueType,
    assigneeId : string,
    reporterId: string,
    projectId:  string,
    CreatedAt : Date
}


export type Issues = {
    issues: Issue[]
}

