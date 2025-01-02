import { MemberRole } from "./enum"

export type Project= {
    id : string,
    code: string,
    name: string,
    description : string,
    members : ProjectMember[],
}
export type Projects= {
    projects : Project[],
}

export type ProjectMember= {
    id : string,
    userId :string,
    role : MemberRole,
    username :  string,
}

export type Members= {
    members : ProjectMember[],
}