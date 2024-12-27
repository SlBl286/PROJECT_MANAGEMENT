import { UserRole } from "@/enums"

export type Login= {
    username : string,
    password : string,
}

export type Register= {
    username : string,
    name: string,
    email : string | undefined,
    phoneNumber : string | undefined,
    avatar : string | undefined,
    password : string,
}
export type User= {
    id : string,
    name: string,
    token : string,
    username : string,
    email : string,
    phoneNumber : string,
    avatar : string,
    role : UserRole,
    refreshToken: string,
}