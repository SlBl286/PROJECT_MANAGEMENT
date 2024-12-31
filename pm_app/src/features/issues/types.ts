export type Issue= {
    id : string,
    code: string,
    name: string,
    description : string,
    members : ProjectMember[],
}

export type ProjectMember= {
    id : string,
    code: string,
    name: string,
    description : number,
}